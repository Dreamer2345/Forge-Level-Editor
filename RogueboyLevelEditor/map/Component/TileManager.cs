using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RogueboyLevelEditor.map.Component
{
    public class Tile
    {
        public Tile(int ID, string Name, string TextureID, bool Exit = false, bool Sender = false, bool Receiver = false)
        {
            this.ID = ID;
            this.Name = Name;
            this.TextureID = TextureID;
            this.IsExit = Exit;
            this.IsSender = Sender;
            this.IsReceiver = Receiver;
        }

        public int ID { get; private set; }

        public bool IsExit { get; private set; }

        public bool IsSender { get; private set; }

        public bool IsReceiver { get; private set; }

        public string Name { get; private set; }

        public string TextureID { get; private set; }

        public static Tile Null { get; } = new Tile(-1, "Null", "Null");
    }

    public static class TileManager
    {
        private static readonly Dictionary<int, Tile> tiles = new Dictionary<int, Tile>()
        {
            { Tile.Null.ID, Tile.Null }
        };

        public static IEnumerable<Tile> Tiles => tiles.Values;

        public static IEnumerable<KeyValuePair<int, Tile>> EnumerateTiles()
        {
            return tiles;
        }

        public static Tile GetTile(int id)
        {
            return tiles.TryGetValue(id, out Tile tile) ? tile : Tile.Null;
        }

        private static void AddTile(int ID, Tile tile)
        {
            if (tiles.ContainsKey(ID))
                return;

            tiles.Add(ID, tile);
        }

        public static void Load(string filePath)
        {
            foreach (var tile in LoadTiles(filePath))
                AddTile(tile.ID, tile);
        }

        private static IEnumerable<Tile> LoadTiles(string filePath)
        {
            var xmlDoc = XDocument.Load(filePath);
            var nodes = xmlDoc.Descendants("tiles").Elements().Where(element => element.Name == "tile");

            // TODO: Find a better way to handle missing data
            foreach (XElement xElement in nodes)
            {
                var children = xElement.Descendants().ToList();

                var id = int.Parse(children.Find(o => o.Name == "id").Value);
                var name = children.Find(o => o.Name == "name").Value;
                var textureID = children.Find(o => o.Name == "texture").Value;

                bool isExit = false;
                if (!bool.TryParse(children.Find(o => o.Name == "exit").Value, out isExit))
                    isExit = false;

                var gateValues = children.Find(o => o.Name == "gate").Descendants().ToList();

                int tileID = -1;
                if (gateValues.Find(i => i.Name == "activate") != null)
                    if (!int.TryParse(gateValues.Find(i => i.Name == "activate").Value, out tileID))
                        tileID = -1;

                bool isReceiver = false;
                if (gateValues.Find(i => i.Name == "value") != null)
                    if (!bool.TryParse(gateValues.Find(i => i.Name == "value").Value, out isReceiver))
                        isReceiver = false;

                var senderValues = children.Find(o => o.Name == "switch").Descendants();

                bool isSender = false;
                if (senderValues.First(i => i.Name == "value") != null)
                    if (!bool.TryParse(senderValues.First(i => i.Name == "value").Value, out isSender))
                        isSender = false;

                yield return new Tile(id, name, textureID, isExit, isSender, isReceiver);
            }
        }
    }
}
