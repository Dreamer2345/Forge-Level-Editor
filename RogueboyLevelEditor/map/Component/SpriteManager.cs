using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static RogueboyLevelEditor.TextureHandler.TextureManager;
using System.Xml.Linq;

namespace RogueboyLevelEditor.map.Component
{
    public class Sprite
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string TextureID { get; private set; }
        public int Health { get; private set; }

        public Sprite(int id, string name, string textureID, int health)
        {
            this.ID = id;
            this.Name = name;
            this.TextureID = textureID;
            this.Health = health;
        }
    }

    public class SpriteManager
    {
        static Dictionary<int, Sprite> Sprites;

        public ExceptionReport Load(string Filepath)
        {
            
            try
            {
                XDocument xmlDoc = XDocument.Load(Filepath);
                List<XElement> Nodes = (from element in xmlDoc.Descendants("sprites").Elements() where element.Name == "sprite" select element).ToList();
                foreach (XElement x in Nodes)
                {
                    List<XElement> daughters = x.Descendants().ToList();
                    int id = int.Parse(daughters.Find(o => o.Name == "id").Value);
                    string name = daughters.Find(o => o.Name == "name").Value;
                    string textureId = daughters.Find(o => o.Name == "texture").Value;
                    int health = int.Parse(daughters.Find(o => o.Name == "health").Value);

                    AddSprite(id, new Sprite(id, name, textureId, health));
                }
            }
            catch (Exception e)
            {
                return new ExceptionReport() { Failed = true, exception = e };
            }
            return new ExceptionReport() { Failed = false, exception = null };
        }

        public SpriteManager()
        {

            if (Sprites == null)
            {
                Sprites = new Dictionary<int, Sprite>();
            }

        }

        public List<Tuple<int, Sprite>> GetAllSprites()
        {
            List<Tuple<int, Sprite>> OutSprites = new List<Tuple<int, Sprite>>();
            foreach (KeyValuePair<int, Sprite> i in Sprites)
            {
                OutSprites.Add(new Tuple<int, Sprite>(i.Key, i.Value));
            }
            return OutSprites;
        }


        public void AddSprite(int ID, Sprite Sprite)
        {
            if (Sprites.ContainsKey(ID))
            {
                return;
            }
            Sprites.Add(ID, Sprite);
        }

        public Sprite GetSprite(int ID)
        {
            if (Sprites.ContainsKey(ID))
            {
                return Sprites[ID];
            }
            return new Sprite(-1, "Null", "Null", 0);
        }
    }
}
