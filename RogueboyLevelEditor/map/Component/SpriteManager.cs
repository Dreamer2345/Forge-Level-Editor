using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static RogueboyLevelEditor.TextureHandler.TextureManager;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace RogueboyLevelEditor.map.Component
{
    public class Sprite
    {
        public Sprite(int id, string name, string textureID, int health)
        {
            this.ID = id;
            this.Name = name;
            this.TextureID = textureID;
            this.Health = health;
        }

        public int ID
        {
            get; private set;
        }

        public string Name
        {
            get; private set;
        }

        public string TextureID
        {
            get; private set;
        }

        public int Health
        {
            get; private set;
        }

        public static Sprite Null { get; } = new Sprite(-1, "Null", "Null", 0);
    }

    public static class SpriteManager
    {
        private static readonly Dictionary<int, Sprite> sprites = new Dictionary<int, Sprite>();

        public static IEnumerable<Sprite> Sprites => sprites.Values;

        private static void AddSprite(int id, Sprite Sprite)
        {
            if (sprites.ContainsKey(id))
                return;

            sprites.Add(id, Sprite);
        }

        public static Sprite GetSprite(int id)
        {
            return sprites.TryGetValue(id, out Sprite sprite) ? sprite : Sprite.Null;
        }

        public static IEnumerable<KeyValuePair<int, Sprite>> EnumerateSprites()
        {
            return sprites;
        }

        public static void Load(string Filepath)
        {
            foreach(var sprite in LoadSprites(Filepath))
                AddSprite(sprite.ID, sprite);
        }

        public static IEnumerable<Sprite> LoadSprites(string Filepath)
        {
            var xmlDoc = XDocument.Load(Filepath);
            var nodes = xmlDoc.Descendants("sprites").Elements().Where(element => element.Name == "sprite");
            
            foreach (XElement xElement in nodes)
            {
                var children = xElement.Descendants().ToList();

                var id = int.Parse(children.Find(o => o.Name == "id").Value);
                var name = children.Find(o => o.Name == "name").Value;
                var textureID = children.Find(o => o.Name == "texture").Value;
                var health = int.Parse(children.Find(o => o.Name == "health").Value);

                yield return new Sprite(id, name, textureID, health);
            }
        }
    }
}
