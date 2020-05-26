using RogueboyLevelEditor.map.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Point = System.Drawing.Point;

namespace RogueboyLevelEditor.map
{

    public class Map
    {
        float Zoom = 1.0f;
        public bool Saved { get; private set; }
        public string Filepath = "";
        int ViewWidth = 10;
        int ViewHeight = 10;
        const int BaseTileWidth = 16;
        const int BaseTileHeight = 16;
        int TileWidth = 16;
        int TileHeight = 16;
        int DrawOffsetX = 0;
        int DrawOffsetY = 0;
        public string Name;
        public bool ShowOutOfBounds = false;
        public bool ShowPlayerStart = false;
        public int Timer;
        int width, height;
        public Point PlayerStart = new Point(0, 0);
        public Point DrawPos = new Point(0, 0);
        public BaseMapComponent OutOfBoundsTile = new BaseMapComponent(-1);
        public BaseMapComponent[,] MapComponents;
        public List<SpriteComponent> Sprites;
        public List<EnviromentAffectComponent> Connectors;
        public Point Centre
        {
            get => new Point(this.Width / 2, this.Height / 2);
        }

        public float zoom
        {
            get => Zoom;
            set
            {
                Zoom = value;
                TileWidth = (int)(BaseTileWidth * Zoom);
                TileHeight = (int)(BaseTileHeight * Zoom);
            }
        }


        T[,] ResizeArray<T>(T[,] original, int rows, int cols)
        {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
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


        public static Map ParseMapArray(byte[] Array, string name, string FilePath)
        {
            if (Array.Length < 5)
            {
                return null;
            }


            int Pointer = 0;
            byte width = Array[Pointer];
            byte height = Array[++Pointer];

            if (Array.Length < width * height)
            {
                return null;
            }

            Point playerStart = new Point(Array[++Pointer], Array[++Pointer]);
            byte Timer = Array[++Pointer];
            BaseMapComponent outOfBoundsTile = new BaseMapComponent(Array[++Pointer]);
            Pointer++;
            Map newMap = new Map(outOfBoundsTile, name, width, height, Timer, 0, 0);
            newMap.PlayerStart = playerStart;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    newMap.SetTile(new Point(i, j), Array[(i + (j * width)) + Pointer]);
                }
            }

            Pointer += width * height;
            byte spriteCount = Array[Pointer++];
            for (int i = 0; i < spriteCount; i++)
            {
                byte id = Array[Pointer++];
                byte x = Array[Pointer++];
                byte y = Array[Pointer++];
                byte health = Array[Pointer++];
                newMap.AddSprite(x, y, id, health);
            }

            byte ConnectionCount = Array[Pointer++];
            for (int i = 0; i < ConnectionCount; i++)
            {
                byte X = Array[Pointer++];
                byte Y = Array[Pointer++];
                byte X1 = Array[Pointer++];
                byte Y1 = Array[Pointer++];
                newMap.AddConnection(new Point(X, Y), new Point(X1, Y1));
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

            for (int j = 0; j < this.height; j++)
            {
                writer.Write('\t');
                for (int i = 0; i < this.width; i++)
                {
                    writer.Write(Math.Max(MapComponents[i, j].tileID, 0));
                    writer.Write((i < (this.width - 1)) ? ", " : ",");
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

        public int drawOffsetX { get => DrawOffsetX; set => DrawOffsetX = value; }
        public int drawOffsetY { get => DrawOffsetY; set => DrawOffsetY = value; }
        public int viewWidth { get => ViewWidth; set => ViewWidth = value; }
        public int viewHeight { get => ViewHeight; set => ViewHeight = value; }


        public Point ToTileSpace(Point point)
        {
            return new Point(ToTileSpaceX(point.X), ToTileSpaceY(point.Y));
        }
        public int ToTileSpaceX(int X)
        {
            return ((int)Math.Floor((X - drawOffsetX) / (double)TileWidth)) + DrawPos.X;
        }
        public int ToTileSpaceY(int Y)
        {
            return ((int)Math.Floor((Y - drawOffsetY) / (double)TileHeight)) + DrawPos.Y;
        }
        public Point ToScreenSpace(Point point)
        {
            return new Point(ToScreenSpaceX(point.X), ToScreenSpaceY(point.Y));
        }
        public int ToScreenSpaceX(int X)
        {
            return (((X - DrawPos.X) * TileWidth) + DrawOffsetX);
        }
        public int ToScreenSpaceY(int Y)
        {
            return (((Y - DrawPos.Y) * TileHeight) + DrawOffsetY);
        }

        public bool CheckInRange(int x, int y)
        {
            return ((x >= 0) && (y >= 0)) && ((x < this.width) && (y < this.height));
        }

        void ResetComponents()
        {
            for (int i = 0; i < this.width; i++)
            {
                for (int j = 0; j < this.height; j++)
                {
                    MapComponents[i, j] = new BaseMapComponent(-1);
                }
            }
        }

        public Map(BaseMapComponent OutOfBounds, string Name = "Map", int xSize = 15, int ySize = 15, int timer = 255, int DrawOffsetX = 0, int DrawOffsetY = 0)
        {
            this.DrawOffsetX = DrawOffsetX;
            this.DrawOffsetY = DrawOffsetY;
            this.OutOfBoundsTile = OutOfBounds;
            this.Name = Name;
            Timer = timer;
            this.width = xSize;
            this.height = ySize;
            MapComponents = new BaseMapComponent[xSize, ySize];
            Sprites = new List<SpriteComponent>();
            Connectors = new List<EnviromentAffectComponent>();
            ResetComponents();
            this.CentreMap();
        }

        public void SetTile(Point pos, int ID)
        {
            if (CheckInRange(pos.X, pos.Y))
            {
                MapComponents[pos.X, pos.Y] = new BaseMapComponent(ID);
            }
        }

        public BaseMapComponent GetTile(Point pos)
        {
            if (CheckInRange(pos.X, pos.Y))
            {
                return MapComponents[pos.X, pos.Y];
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

        public void UpdateSprite(Point p, int ID, int NewHealth)
        {
            int found = Sprites.FindIndex(x => x.SpritePosition == p && x.Type == ID);
            if (found != -1)
            {
                Sprites[found].Health = NewHealth;
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
            for (int i = -ViewWidth; i < ViewWidth; i++)
            {
                for (int j = -ViewHeight; j < ViewHeight; j++)
                {
                    if (CheckInRange(i + DrawPos.X, j + DrawPos.Y))
                    {
                        if (ShowPlayerStart)
                        {
                            MapComponents[i + DrawPos.X, j + DrawPos.Y].Draw(graphics, ToScreenSpace(new Point(i + DrawPos.X, j + DrawPos.Y)), new Point(TileWidth, TileHeight));
                        }

                        if (MapComponents[i + DrawPos.X, j + DrawPos.Y] != null)
                        {
                            MapComponents[i + DrawPos.X, j + DrawPos.Y].Draw(graphics, ToScreenSpace(new Point(i + DrawPos.X, j + DrawPos.Y)), new Point(TileWidth, TileHeight));
                        }
                    }
                    else
                    {
                        if (ShowOutOfBounds)
                        {
                            OutOfBoundsTile.Draw(graphics, ToScreenSpace(new Point(i, j)), new Point(TileWidth, TileHeight));
                        }
                    }
                }
            }
        }

        public void DrawSprites(Graphics graphics)
        {
            foreach (SpriteComponent i in Sprites)
            {
                i.Draw(graphics, ToScreenSpace(new Point(i.SpritePosition.X, i.SpritePosition.Y)), new Point(TileWidth, TileHeight));
            }
        }

        public void DrawConnections(Graphics graphics)
        {
            foreach (EnviromentAffectComponent i in Connectors)
            {
                i.Draw(graphics, ToScreenSpace(new Point(i.Start.X, i.Start.Y)), new Point(TileWidth, TileHeight));
            }
        }

        public void DrawPlayer(Graphics graphics)
        {
            Pen pen = new Pen(Color.Blue);
            graphics.DrawRectangle(pen, ToScreenSpaceX(PlayerStart.X) - 1, ToScreenSpaceY(PlayerStart.Y) - 1, TileWidth, TileHeight);

        }

        public void CentreMap() => this.DrawPos = this.Centre;
    }
}
