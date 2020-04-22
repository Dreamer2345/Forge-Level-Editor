using RogueboyLevelEditor.map.point;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;


namespace RogueboyLevelEditor.map.Component
{
    public class EnviromentAffectComponent : DrawComponent
    {
        Map parentMap;
        public Point Start;
        public Point End;
        public bool IsValid;
        public bool Highlight;

        public EnviromentAffectComponent(Point start, Point end, Map parent)
        {
            Start = start;
            End = end;
            parentMap = parent;

            UpdateValid();
        }

        void UpdateValid()
        {
            TileManager tm = new TileManager();
            BaseMapComponent p = parentMap.GetTile(point.Point.ToPoint(Start));
            BaseMapComponent p1 = parentMap.GetTile(point.Point.ToPoint(End));
            IsValid = false;
            if (tm.GetTile(p.tileID).IsSender)
                if (tm.GetTile(p1.tileID).IsReciver)
                    IsValid = true;
        }

        public override void Draw(Graphics graphics, Point Pos)
        {

            UpdateValid();

            Pen pen = new Pen(Color.LawnGreen);
            Point ScreenStart = new Point(parentMap.ToScreenSpaceX(Start.X), parentMap.ToScreenSpaceY(Start.Y));
            Point ScreenEnd = new Point(parentMap.ToScreenSpaceX(End.X), parentMap.ToScreenSpaceY(End.Y));
            graphics.DrawRectangle(pen, ScreenStart.X - 1, ScreenStart.Y - 1, 17, 17);
            pen.Color = Color.Red;
            graphics.DrawRectangle(pen, ScreenEnd.X - 1, ScreenEnd.Y - 1, 17, 17);

            if (this.Highlight) {
                pen = new Pen(Color.Red);
                this.Highlight = false;
            }
            else {
                pen = new Pen(Color.Blue);
            }

            pen.Width = 2;
            graphics.DrawLine(pen, ScreenStart.X + 8, ScreenStart.Y + 8, ScreenEnd.X + 8, ScreenEnd.Y + 8);

        }
        
    }

}
