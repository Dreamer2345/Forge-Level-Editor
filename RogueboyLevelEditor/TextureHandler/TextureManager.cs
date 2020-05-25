using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace RogueboyLevelEditor.TextureHandler
{
    public static class TextureManager
    {
        private static readonly Bitmap errorTexture = GenerateErrorTexture(16, 16);

        private static Dictionary<string, Bitmap> textures = new Dictionary<string, Bitmap>()
        {
            { "Null", errorTexture }
        };

        public static Bitmap ErrorTexture { get; private set; } = errorTexture;

        public static Bitmap GetTexture(string id)
        {
            return textures.TryGetValue(id, out Bitmap bitmap) ? bitmap : ErrorTexture;
        }

        private static void AddTexture(string id, Bitmap texture, Color transparentColour)
        {
            if (textures.ContainsKey(id))
                return;

            for (int y = 0; y < texture.Height; y++)
                for (int x = 0; x < texture.Width; x++)
                    if (texture.GetPixel(x, y) == transparentColour)
                        texture.SetPixel(x, y, Color.Transparent);

            textures.Add(id, texture);
        }

        private static Bitmap GenerateErrorTexture(int width, int height)
        {
            var result = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.FillRectangle(Brushes.Gray, 0, 0, width, height);
                graphics.DrawLine(Pens.Red, 0, 0, width, height);
                graphics.DrawRectangle(Pens.Black, 0, 0, width, height);
            }

            return result;
        }

        public static void Load(string filePath)
        {
            foreach (var tuple in LoadTextures(filePath))
                AddTexture(tuple.Item1, tuple.Item2, tuple.Item3);
        }

        private static IEnumerable<Tuple<string, Bitmap, Color>> LoadTextures(string filePath)
        {
            var xmlDoc = XDocument.Load(filePath);
            var nodes = xmlDoc.Descendants("textures").Elements().Where(element => element.Name == "texture");

            foreach (XElement xElement in nodes)
            {
                var children = xElement.Descendants().ToList();

                var textureID = children.Find(o => o.Name == "id").Value;
                var textureFilePath = children.Find(o => o.Name == "filepath").Value;
                var colour = children.Find(o => o.Name == "transparent");

                var alpha = int.Parse(colour.Attributes().Where(i => i.Name == "a").First().Value);
                var red = int.Parse(colour.Attributes().Where(i => i.Name == "r").First().Value);
                var green = int.Parse(colour.Attributes().Where(i => i.Name == "g").First().Value);
                var blue = int.Parse(colour.Attributes().Where(i => i.Name == "b").First().Value);

                var transparent = Color.FromArgb(alpha, red, green, blue);

                yield return Tuple.Create(textureID, (Bitmap)Bitmap.FromFile(textureFilePath), transparent);
            }
        }
    }
}
