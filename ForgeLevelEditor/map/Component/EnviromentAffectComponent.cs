using System.Drawing;

namespace ForgeLevelEditor.map.Component
{
    public class EnviromentAffectComponent
    {
        private Map parentMap;
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

        private void UpdateValid()
        {
            var p0 = parentMap.GetTile(Start);
            var p1 = parentMap.GetTile(End);
            this.IsValid = (TileManager.GetTile(p0.tileID).IsSender && TileManager.GetTile(p1.tileID).IsReceiver);
        }

        public void Draw(Graphics graphics, Point Pos, Point Size)
        {

            UpdateValid();

            Pen pen = new Pen(Color.LawnGreen);
            Point ScreenStart = new Point(parentMap.ToScreenSpaceX(Start.X), parentMap.ToScreenSpaceY(Start.Y));
            Point ScreenEnd = new Point(parentMap.ToScreenSpaceX(End.X), parentMap.ToScreenSpaceY(End.Y));
            graphics.DrawRectangle(pen, ScreenStart.X - 1, ScreenStart.Y - 1, Size.X + 1, Size.Y +1);
            pen.Color = Color.Red;
            graphics.DrawRectangle(pen, ScreenEnd.X - 1, ScreenEnd.Y - 1, Size.X+1, Size.Y+1);

            if (this.Highlight)
            {
                pen = new Pen(Color.Red);
                this.Highlight = false;
            }
            else
            {
                pen = new Pen(Color.Blue);
            }

            pen.Width = 2;
            graphics.DrawLine(pen, ScreenStart.X + (Size.X / 2), ScreenStart.Y + (Size.Y / 2), ScreenEnd.X + (Size.X / 2), ScreenEnd.Y + (Size.Y / 2));

        }

    }

}
