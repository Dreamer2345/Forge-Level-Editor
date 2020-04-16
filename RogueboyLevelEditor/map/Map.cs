using RogueboyLevelEditor.map.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using Point = System.Drawing.Point;

namespace RogueboyLevelEditor.map
{

    public class Map
    {
        public bool Saved { get; private set; }
        public string Filepath = "";
        int ViewWidth = 10;
        int ViewHeight = 10;
        const int TileWidth = 16;
        const int TileHeight = 16;
        int DrawOffsetX = 0;
        int DrawOffsetY = 0;
        public string Name;
        public bool ShowOutOfBounds = false;
        public bool ShowPlayerStart = false;
        public int Timer, Width, Height;
        point.Point PlayerStart = new point.Point(0, 0);
        public point.Point DrawPos = new point.Point(0, 0);
        public BaseMapComponent OutOfBoundsTile = new BaseMapComponent(-1);
        public BaseMapComponent[,] MapComponents;
        public List<SpriteComponent> Sprites;
        public List<EnviromentAffectComponent> Connectors;
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

            point.Point playerStart = new point.Point(Array[++Pointer], Array[++Pointer]);
            byte Timer = Array[++Pointer];
            BaseMapComponent outOfBoundsTile = new BaseMapComponent(Array[++Pointer]);
            Pointer++;
            Map newMap = new Map(outOfBoundsTile, name, FilePath, width, height, Timer, 0, 0);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    newMap.SetTile(new point.Point(i, j), Array[(i + (j * width)) + Pointer]);
                }
            }

            Pointer += width * height;
            byte SpriteCount = Array[Pointer++];
            for (int i = 0; i < SpriteCount; i++)
            {
                byte SpriteID = Array[Pointer++];
                byte SpriteX = Array[Pointer++];
                byte SpriteY = Array[Pointer++];
                newMap.AddSprite(SpriteX, SpriteY, SpriteID);
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

        public string GetMap()
        {
            string Head = "const uint8_t " + Name + "[] = {\n";
            Head += Width + ", /*Width*/\n";
            Head += Height + ", /*Height*/\n";
            Head += PlayerStart.X + ", /*PlayerStart X*/\n";
            Head += PlayerStart.Y + ", /*PlayerStart Y*/\n";
            Head += Timer + ", /*Timer*/\n";
            Head += Math.Max(OutOfBoundsTile.tileID, 0) + ", /*Out of bounds Tile ID*/\n";
            for (int j = 0; j < Height; j++)
            {
                string Accumalator = "";
                for (int i = 0; i < Width; i++)
                {
                    Accumalator += Math.Max(MapComponents[i, j].tileID, 0) + ",";
                }
                Accumalator += "\n";
                Head += Accumalator;
            }
            Head += Sprites.Count + ",\n";
            foreach (SpriteComponent i in Sprites)
            {
                Head += $"{i.Type},{i.SpritePosition.X},{i.SpritePosition.Y},\n";
            }
            Head += Connectors.Count + ",\n";
            foreach (EnviromentAffectComponent i in Connectors)
            {
                Head += $"{i.Start.X},{i.Start.Y},{i.End.X},{i.End.Y},\n";
            }
            Head += "};\n";
            return Head;
        }

        public int drawOffsetX { get => DrawOffsetX; set => DrawOffsetX = value; }
        public int drawOffsetY { get => DrawOffsetY; set => DrawOffsetY = value; }
        public int viewWidth { get => ViewWidth; set => ViewWidth = value; }
        public int viewHeight { get => ViewHeight; set => ViewHeight = value; }


        public System.Drawing.Point ToTileSpace(System.Drawing.Point point)
        {
            return new System.Drawing.Point(ToTileSpaceX(point.X), ToTileSpaceY(point.Y));
        }
        public int ToTileSpaceX(int X)
        {
            return ((int)Math.Floor((X - drawOffsetX) / 16d)) + DrawPos.X;
        }
        public int ToTileSpaceY(int Y)
        {
            return ((int)Math.Floor((Y - drawOffsetY) / 16d)) + DrawPos.Y;
        }
        public System.Drawing.Point ToScreenSpace(System.Drawing.Point point)
        {
            return new System.Drawing.Point(ToScreenSpaceX(point.X), ToScreenSpaceY(point.Y));
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
            return ((x >= 0) && (y >= 0)) && ((x < Width) && (y < Height));
        }

        void ResetComponents()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    MapComponents[i, j] = new BaseMapComponent(-1);
                }
            }
        }

        public Map(BaseMapComponent OutOfBounds, string Name = "Map", string Filepath = "", int xSize = 15, int ySize = 15, int timer = 255, int DrawOffsetX = 0, int DrawOffsetY = 0)
        {
            this.DrawOffsetX = DrawOffsetX;
            this.DrawOffsetY = DrawOffsetY;
            this.OutOfBoundsTile = OutOfBounds;
            this.Name = Name;
            this.Filepath = Filepath;
            Timer = timer;
            Width = xSize;
            Height = ySize;
            MapComponents = new BaseMapComponent[xSize, ySize];
            Sprites = new List<SpriteComponent>();
            Connectors = new List<EnviromentAffectComponent>();
            ResetComponents();
        }

        public void SetTile(point.Point pos, int ID)
        {
            if (CheckInRange(pos.X, pos.Y))
            {
                MapComponents[pos.X, pos.Y] = new BaseMapComponent(ID);
            }
        }

        public BaseMapComponent GetTile(point.Point pos)
        {
            if (CheckInRange(pos.X, pos.Y))
            {
                return MapComponents[pos.X, pos.Y];
            }
            return new BaseMapComponent(-1);
        }

        public void AddSprite(int TileX, int TileY, int Type)
        {
            if (CheckInRange(TileX, TileY))
            {
                Sprites.Add(new SpriteComponent(new Point(TileX, TileY), Type));
            }
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
                            MapComponents[i + DrawPos.X, j + DrawPos.Y].Draw(graphics, ToScreenSpace(new Point(i + DrawPos.X, j + DrawPos.Y)));
                        }

                        if (MapComponents[i + DrawPos.X, j + DrawPos.Y] != null)
                        {
                            MapComponents[i + DrawPos.X, j + DrawPos.Y].Draw(graphics, ToScreenSpace(new Point(i + DrawPos.X, j + DrawPos.Y)));
                        }
                    }
                    else
                    {
                        if (ShowOutOfBounds)
                        {
                            OutOfBoundsTile.Draw(graphics, ToScreenSpace(new Point(i, j)));
                        }
                    }
                }
            }
        }

        public void DrawSprites(Graphics graphics)
        {
            foreach (SpriteComponent i in Sprites)
            {
                i.Draw(graphics, ToScreenSpace(new Point(i.SpritePosition.X, i.SpritePosition.Y)));
            }
        }

        public void DrawConnections(Graphics graphics)
        {
            foreach (EnviromentAffectComponent i in Connectors)
            {
                i.Draw(graphics, ToScreenSpace(new Point(i.Start.X, i.Start.Y)));
            }
        }

        public void DrawPlayer(Graphics graphics)
        {

        }
    }
}
