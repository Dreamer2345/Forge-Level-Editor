using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RogueboyLevelEditor.TextureHandler
{
    public class TextureManager
    {
        public static Bitmap Error { get; private set; }
        static Dictionary<string, Bitmap> Textures;


        public TextureManager()
        {
            if(Error == null)
            {
                Error = GenerateErrorTexture(16, 16);
            }

            if (Textures == null)
            {
                Textures = new Dictionary<string, Bitmap>();
                AddTexture("Null", Error,Color.Transparent);
            }

        }

        public struct ExceptionReport
        {
            public bool Failed;
            public Exception exception;
        }

        public ExceptionReport Load(string Filepath)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(Filepath);
                List<XElement> Nodes = (from element in xmlDoc.Descendants("textures").Elements() where element.Name == "texture" select element).ToList();
                foreach (XElement x in Nodes)
                {
                    List<XElement> Daughters = x.Descendants().ToList();
                    string TextureFilepath = Daughters.Find(o => o.Name == "filepath").Value;
                    string TextureID = Daughters.Find(o => o.Name == "id").Value;
                    XElement Colour = Daughters.Find(o => o.Name == "transparent");
                    int Red = int.Parse(Colour.Attributes().Where(i => i.Name == "r").ToList()[0].Value);
                    int Green = int.Parse(Colour.Attributes().Where(i => i.Name == "g").ToList()[0].Value);
                    int Blue = int.Parse(Colour.Attributes().Where(i => i.Name == "b").ToList()[0].Value);
                    int Alpha = int.Parse(Colour.Attributes().Where(i => i.Name == "a").ToList()[0].Value);
                    Color Transparant = Color.FromArgb(Alpha, Red, Green, Blue);
                   
                    

                    AddTexture(TextureID,(Bitmap)Bitmap.FromFile(TextureFilepath),Transparant);
                }
            }
            catch (Exception e)
            {
                return new ExceptionReport() { Failed = true, exception = e};
            }
            return new ExceptionReport() { Failed = false, exception = null};
        }

        public void AddTexture(string ID, Bitmap Texture,Color TransparantColor)
        {
            if (Textures.ContainsKey(ID))
            {
                return;
            }
            for (int i = 0; i < Texture.Width; i++)
                for (int j = 0; j < Texture.Height; j++)
                {
                    if(Texture.GetPixel(i,j) == TransparantColor)
                    {
                        Texture.SetPixel(i, j, Color.Transparent);
                    }
                }

            Textures.Add(ID, Texture);
        }

        static Bitmap GenerateErrorTexture(int x,int y)
        {
            Bitmap b = new Bitmap(x, y);
            for(int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    if ((i == 0) || (j == 0) || (i == x - 1) || (j == y - 1))
                        b.SetPixel(i, j, Color.Black);
                    else
                        if (i == j)
                            b.SetPixel(i, j, Color.Red);
                        else
                            b.SetPixel(i, j, Color.Gray);
                }
            return b;
        }

        public Bitmap GetTexture(string ID)
        {         
            if (Textures.ContainsKey(ID))
            {
                return (Bitmap)Textures[ID].Clone();
            }
            return (Bitmap)Error.Clone();
        }
    }
}
