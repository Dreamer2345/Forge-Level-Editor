using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using ForgeLevelEditor.map.Component;

namespace ForgeLevelEditor.map
{

    public class Map
    {
        public const int DefaultTileWidth = 16;
        public const int DefaultTileHeight = 16;

        public bool Saved { get; private set; }
        public string Filepath = "";
        private int viewWidth = 10;
        private int viewHeight = 10;
        private int drawOffsetX = 0;
        private int drawOffsetY = 0;
        public string Name;
        public bool ShowOutOfBounds = false;
        public bool ShowPlayerStart = false;
        public int Timer;
        private int width;
        private int height;
        public Point PlayerStart = new Point(0, 0);
        public Point DrawPosition = new Point(0, 0);
        public BaseMapComponent OutOfBoundsTile = new BaseMapComponent(-1);
        public BaseMapComponent[,] MapComponents;
        public List<SpriteComponent> Sprites;
        public List<EnviromentAffectComponent> Connectors;

        public Point Centre
        {
            get => new Point(this.Width / 2, this.Height / 2);
        }

        public Size TileSize { get; set; } = new Size(DefaultTileWidth, DefaultTileHeight);

        private T[,] ResizeArray<T>(T[,] original, int rows, int columns)
        {
            var newArray = new T[rows, columns];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minColumns = Math.Min(columns, original.GetLength(1));
            for (int y = 0; y < minRows; y++)
                for (int x = 0; x < minColumns; x++)
                    newArray[y, x] = original[y, x];
            return newArray;
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                this.height = value;
                MapComponents = ResizeArray<BaseMapComponent>(MapComponents, MapComponents.GetLength(0), value);

                for (int y = 0; y < MapComponents.GetLength(1); y++)
                {

                    for (int x = 0; x < MapComponents.GetLength(0); x++)
                    {

                        if (MapComponents[x, y] == null) MapComponents[x, y] = new BaseMapComponent(-1);

                    }

                }
            }
        }

        public int Width
        {
            get { return this.width; }
            set
            {
                this.width = value;
                MapComponents = ResizeArray<BaseMapComponent>(MapComponents, value, MapComponents.GetLength(1));

                for (int y = 0; y < MapComponents.GetLength(1); y++)
                {

                    for (int x = 0; x < MapComponents.GetLength(0); x++)
                    {

                        if (MapComponents[x, y] == null) MapComponents[x, y] = new BaseMapComponent(-1);

                    }

                }

            }

        }


        public static Map ParseMapArray(byte[] array, string name)
        {
            if (array.Length < 5)
            {
                return null;
            }


            int index = 0;
            byte width = array[index];
            byte height = array[++index];

            if (array.Length < width * height)
            {
                return null;
            }

            Point playerStart = new Point(array[++index], array[++index]);
            byte timer = array[++index];
            BaseMapComponent outOfBoundsTile = new BaseMapComponent(array[++index]);
            index++;
            Map newMap = new Map(outOfBoundsTile, name, width, height, timer, 0, 0);
            newMap.PlayerStart = playerStart;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    newMap.SetTile(new Point(x, y), array[(x + (y * width)) + index]);
                }
            }

            index += width * height;
            byte spriteCount = array[index++];
            for (int i = 0; i < spriteCount; i++)
            {
                byte id = array[index++];
                byte x = array[index++];
                byte y = array[index++];
                byte health = array[index++];
                newMap.AddSprite(x, y, id, health);
            }

            byte ConnectionCount = array[index++];
            for (int i = 0; i < ConnectionCount; i++)
            {
                byte startX = array[index++];
                byte startY = array[index++];
                byte endX = array[index++];
                byte endY = array[index++];
                newMap.AddConnection(new Point(startX, startY), new Point(endX, endY));
            }

            return newMap;
        }

        public void WriteMap(TextWriter writer)
        {
            writer.WriteLine("constexpr const uint8_t {0}[] = ", this.Name);
            writer.WriteLine("{");

            writer.WriteLine("\t{0}, /*Width*/", this.Width);

            writer.WriteLine("\t{0}, /*Height*/", this.Height);

            writer.WriteLine("\t{0}, /*Player Start X*/", this.PlayerStart.X);

            writer.WriteLine("\t{0}, /*Player Start Y*/", this.PlayerStart.Y);

            writer.WriteLine("\t{0}, /*Timer*/", this.Timer);

            writer.WriteLine("\t{0}, /*Out of Bounds Tile ID*/", this.OutOfBoundsTile.tileID);

            for (int y = 0; y < this.height; y++)
            {
                writer.Write('\t');
                for (int x = 0; x < this.width; x++)
                {
                    writer.Write(Math.Max(MapComponents[x, y].tileID, 0));
                    writer.Write((x < (this.width - 1)) ? ", " : ",");
                }
                writer.WriteLine();
            }

            writer.Write('\t');
            writer.Write(this.Sprites.Count);
            writer.WriteLine(", ");

            foreach (var sprite in this.Sprites)
            {
                writer.Write('\t');
                writer.Write(sprite.Type);
                writer.Write(", ");

                writer.Write(sprite.SpritePosition.X);
                writer.Write(", ");

                writer.Write(sprite.SpritePosition.Y);
                writer.Write(", ");

                writer.Write(sprite.Health);
                writer.WriteLine(",");
            }

            writer.Write('\t');
            writer.Write(this.Connectors.Count);
            writer.WriteLine(",");

            foreach (var connector in this.Connectors)
            {
                writer.Write('\t');
                writer.Write(connector.Start.X);
                writer.Write(", ");

                writer.Write(connector.Start.Y);
                writer.Write(", ");

                writer.Write(connector.End.X);
                writer.Write(", ");

                writer.Write(connector.End.Y);
                writer.WriteLine(",");
            }

            writer.WriteLine("};");
        }

        public int DrawOffsetX { get => drawOffsetX; set => drawOffsetX = value; }
        public int DrawOffsetY { get => drawOffsetY; set => drawOffsetY = value; }
        public int ViewWidth { get => viewWidth; set => viewWidth = value; }
        public int ViewHeight { get => viewHeight; set => viewHeight = value; }

        public Point ToTileSpace(Point point)
        {
            return new Point(ToTileSpaceX(point.X), ToTileSpaceY(point.Y));
        }
        public int ToTileSpaceX(int X)
        {
            return ((int)Math.Floor((X - DrawOffsetX) / (double)TileSize.Width)) + DrawPosition.X;
        }
        public int ToTileSpaceY(int Y)
        {
            return ((int)Math.Floor((Y - DrawOffsetY) / (double)TileSize.Height)) + DrawPosition.Y;
        }
        public Point ToScreenSpace(Point point)
        {
            return new Point(ToScreenSpaceX(point.X), ToScreenSpaceY(point.Y));
        }
        public int ToScreenSpaceX(int X)
        {
            return (((X - DrawPosition.X) * TileSize.Width) + drawOffsetX);
        }
        public int ToScreenSpaceY(int Y)
        {
            return (((Y - DrawPosition.Y) * TileSize.Height) + drawOffsetY);
        }

        public bool CheckInRange(int x, int y)
        {
            return ((x >= 0) && (y >= 0)) && ((x < this.width) && (y < this.height));
        }

        void ResetComponents()
        {
            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    MapComponents[x, y] = new BaseMapComponent(-1);
                }
            }
        }

        public Map(BaseMapComponent outOfBounds, string name = "Map", int width = 15, int height = 15, int timer = 255, int drawOffsetX = 0, int drawOffsetY = 0)
        {
            this.drawOffsetX = drawOffsetX;
            this.drawOffsetY = drawOffsetY;
            this.OutOfBoundsTile = outOfBounds;
            this.Name = name;
            Timer = timer;
            this.width = width;
            this.height = height;
            MapComponents = new BaseMapComponent[width, height];
            Sprites = new List<SpriteComponent>();
            Connectors = new List<EnviromentAffectComponent>();
            ResetComponents();
            this.CentreMap();
        }

        public void SetTile(Point position, int id)
        {
            if (CheckInRange(position.X, position.Y))
            {
                MapComponents[position.X, position.Y] = new BaseMapComponent(id);
            }
        }

        public BaseMapComponent GetTile(Point position)
        {
            if (CheckInRange(position.X, position.Y))
            {
                return MapComponents[position.X, position.Y];
            }
            return new BaseMapComponent(-1);
        }

        public SpriteComponent AddSprite(int tileX, int tileY, int type, int health)
        {
            if (CheckInRange(tileX, tileY))
            {
                SpriteComponent sprite = new SpriteComponent(new Point(tileX, tileY), type, health);
                Sprites.Add(sprite);
                return sprite;
            }

            return null;
        }

        public void RemoveSprite(Point p, int ID)
        {
            SpriteComponent found = Sprites.Find(x => x.SpritePosition == p);
            if (found != null)
            {
                if (found.Type == ID)
                {
                    Sprites.Remove(found);
                }
            }
        }

        public void UpdateSprite(Point position, int id, int health)
        {
            int found = Sprites.FindIndex(x => x.SpritePosition == position && x.Type == id);
            if (found != -1)
            {
                Sprites[found].Health = health;
            }

        }

        public EnviromentAffectComponent AddConnection(Point start, Point end)
        {
            EnviromentAffectComponent env = new EnviromentAffectComponent(start, end, this);
            Connectors.Add(env);
            return env;
        }

        public void RemoveConnection(Point start, Point end)
        {
            EnviromentAffectComponent found = Connectors.Find(x => (x.Start == start) && (x.End == end));
            if (found != null)
            {
                Connectors.Remove(found);
            }
        }

        public void DrawBackground(Graphics graphics)
        {
            for (int x = -viewWidth; x < viewWidth; x++)
            {
                for (int y = -viewHeight; y < viewHeight; y++)
                {
                    if (CheckInRange(x + DrawPosition.X, y + DrawPosition.Y))
                    {
                        if (ShowPlayerStart)
                        {
                            MapComponents[x + DrawPosition.X, y + DrawPosition.Y].Draw(graphics, ToScreenSpace(new Point(x + DrawPosition.X, y + DrawPosition.Y)), new Point(TileSize.Width, TileSize.Height));
                        }

                        if (MapComponents[x + DrawPosition.X, y + DrawPosition.Y] != null)
                        {
                            MapComponents[x + DrawPosition.X, y + DrawPosition.Y].Draw(graphics, ToScreenSpace(new Point(x + DrawPosition.X, y + DrawPosition.Y)), new Point(TileSize.Width, TileSize.Height));
                        }
                    }
                    else
                    {
                        if (ShowOutOfBounds)
                        {
                            OutOfBoundsTile.Draw(graphics, ToScreenSpace(new Point(x, y)), new Point(TileSize.Width, TileSize.Height));
                        }
                    }
                }
            }
        }

        public void DrawSprites(Graphics graphics)
        {
            foreach (SpriteComponent sprite in Sprites)
            {
                sprite.Draw(graphics, ToScreenSpace(new Point(sprite.SpritePosition.X, sprite.SpritePosition.Y)), new Point(TileSize.Width, TileSize.Height));
            }
        }

        public void DrawConnections(Graphics graphics)
        {
            foreach (EnviromentAffectComponent connector in Connectors)
            {
                connector.Draw(graphics, ToScreenSpace(new Point(connector.Start.X, connector.Start.Y)), new Point(TileSize.Width, TileSize.Height));
            }
        }

        public void DrawPlayer(Graphics graphics)
        {
            Pen pen = new Pen(Color.Blue);
            graphics.DrawRectangle(pen, ToScreenSpaceX(PlayerStart.X) - 1, ToScreenSpaceY(PlayerStart.Y) - 1, TileSize.Width, TileSize.Height);

        }

        public void CentreMap() => this.DrawPosition = this.Centre;
    }
}
