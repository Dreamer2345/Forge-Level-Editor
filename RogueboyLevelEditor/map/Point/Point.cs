namespace RogueboyLevelEditor.map.point
{


    public class Point
    {
        public int X = 0;
        public int Y = 0;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static System.Drawing.Point ToDrawingPoint(Point p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }

        public static Point ToPoint(System.Drawing.Point p)
        {
            return new Point(p.X, p.Y);
        }

        public override string ToString()
        {
            return "{" + X + ":" + Y + "}";
        }

        public static Point operator %(Point a, int b)
        {
            int x = a.X % b;
            int y = a.Y % b;
            return new Point(x, y);
        }

        public static Point operator %(Point a, Point b)
        {
            int x = a.X % b.X;
            int y = a.Y % b.Y;
            return new Point(x, y);
        }

        public static Point operator *(Point a, Point b)
        {
            int x = a.X * b.X;
            int y = a.Y * b.Y;
            return new Point(x, y);
        }

        public static Point operator /(Point a, Point b)
        {
            int x = a.X / b.X;
            int y = a.Y / b.Y;
            return new Point(x, y);
        }

        public static Point operator +(Point a, Point b)
        {
            int x = a.X + b.X;
            int y = a.Y + b.Y;
            return new Point(x, y);
        }

        public static Point operator -(Point a, Point b)
        {
            int x = a.X - b.X;
            int y = a.Y - b.Y;
            return new Point(x, y);
        }
    }
}
