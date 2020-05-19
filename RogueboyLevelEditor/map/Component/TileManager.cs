using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static RogueboyLevelEditor.TextureHandler.TextureManager;

namespace RogueboyLevelEditor.map.Component
{
    public class Tile
    {
        public int ID { get; private set; }
        public bool IsExit { get; private set; }
        public bool IsSender { get; private set; }
        public bool IsReceiver { get; private set; }
        public string Name { get; private set; }
        public string TextureID { get; private set; }

        public Tile(int ID, string Name, string TextureID, bool Exit = false, bool Sender = false, bool Receiver = false)
        {
            this.ID = ID;
            IsExit = Exit;
            IsSender = Sender;
            IsReceiver = Receiver;
            this.Name = Name;
            this.TextureID = TextureID;
        }
    }

    public class TileManager
    { 
        static Dictionary<int, Tile> Tiles;

        public ExceptionReport Load(string Filepath)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(Filepath);
                List<XElement> Nodes = (from element in xmlDoc.Descendants("tiles").Elements() where element.Name == "tile" select element).ToList();
                foreach (XElement x in Nodes)
                {
                    List<XElement> Daughters = x.Descendants().ToList();
                    int ID = int.Parse(Daughters.Find(o => o.Name == "id").Value);
                    string Name = Daughters.Find(o => o.Name == "name").Value;
                    string TextureID = Daughters.Find(o => o.Name == "texture").Value;
                    bool IsExit = false;
                    if (!bool.TryParse(Daughters.Find(o => o.Name == "exit").Value, out IsExit))
                        IsExit = false;

                    bool IsReciver = false;
                    int TileID = -1;
                    List<XElement> GateValues = Daughters.Find(o => o.Name == "gate").Descendants().ToList();
                    
                    if(GateValues.Find(i => i.Name == "activate") != null)
                    {
                        int.TryParse(GateValues.Find(i => i.Name == "activate").Value,out TileID);
                    }

                    if (GateValues.Find(i => i.Name == "value") != null)
                    {
                        bool.TryParse(GateValues.Find(i => i.Name == "value").Value, out IsReciver);
                    }

                    
                    bool IsSender = false;
                    List<XElement> SenderValues = Daughters.Find(o => o.Name == "switch").Descendants().ToList();
                    if (SenderValues.Find(i => i.Name == "value") != null)
                    {
                         bool.TryParse(SenderValues.Find(i => i.Name == "value").Value,out IsSender);
                    }


                    AddTile(ID, new Tile(ID, Name, TextureID, IsExit, IsSender, IsReciver));
                }
            }
            catch (Exception e)
            {
                return new ExceptionReport() { Failed = true, exception = e };
            }
            return new ExceptionReport() { Failed = false, exception = null };
        }

        public TileManager()
        {

            if (Tiles == null)
            {
                Tiles = new Dictionary<int, Tile>();
                Tiles.Add(-1, new Tile(-1, "Null", "Null"));
            }

        }

        public List<Tuple<int,Tile>> GetAllTiles()
        {
            List<Tuple<int, Tile>> OutTiles = new List<Tuple<int, Tile>>();
            foreach(KeyValuePair<int, Tile> i in Tiles)
            {
                OutTiles.Add(new Tuple<int, Tile>(i.Key, i.Value));
            }
            return OutTiles;
        }


        public void AddTile(int ID, Tile tile)
        {
            if (Tiles.ContainsKey(ID))
            {
                return;
            }
            Tiles.Add(ID, tile);
        }

        public Tile GetTile(int ID)
        {
            if (Tiles.ContainsKey(ID))
            {
                return Tiles[ID];
            }
            return new Tile(ID, "Null","Null");
        }
    }
}
