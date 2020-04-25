using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueboyLevelEditor.map.Component
{
    class TileCursor
    {
        Point LastPosition;
        Point Position;
        int DrawOffsetX = 0;
        int DrawOffsetY = 0;
        public int drawOffsetX { get => DrawOffsetX; set => DrawOffsetX = value; }
        public int drawOffsetY { get => DrawOffsetY; set => DrawOffsetY = value; }


        public Point position { get => Position; set { LastPosition = Position; Position = value;} }

        public bool PositionChanged
        {
            get { return LastPosition != Position; }
        }
        private Font fnt = new Font("Arial", 10);
        public void Draw(Graphics graphics, Map map)
        {
            TileManager tm = new TileManager();
            Pen pen = new Pen(Color.Red);
            graphics.DrawRectangle(pen, map.ToScreenSpaceX(Position.X) - 1, map.ToScreenSpaceY(Position.Y) - 1, 17, 17);
            graphics.DrawString($"X:{Position.X} Y:{Position.Y}", fnt, System.Drawing.Brushes.Black, new PointF(0, 0));
            graphics.DrawString($"ID:{map.GetTile(new point.Point(Position.X, Position.Y)).tileID}", fnt, System.Drawing.Brushes.Black, new PointF(0, 16));
            graphics.DrawString($"Tile:{tm.GetTile(map.GetTile(new point.Point(Position.X, Position.Y)).tileID).Name}", fnt, System.Drawing.Brushes.Black, new PointF(0, 32));
        }
    }
}
