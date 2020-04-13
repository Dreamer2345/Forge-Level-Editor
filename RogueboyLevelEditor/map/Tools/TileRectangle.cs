using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogueboyLevelEditor.map.Tools
{
    class TileRectangle : Tool
    {
        Form Parent;
        int DrawOffsetX = 0;
        int DrawOffsetY = 0;
        public int drawOffsetX { get => DrawOffsetX; set => DrawOffsetX = value; }
        public int drawOffsetY { get => DrawOffsetY; set => DrawOffsetY = value; }


        int TileID = -1;
        Point StartPoint;
        bool StartMade = false;
        bool LastMouseDown = false;

        public TileRectangle(Form Parent,int Tile,Map map,int Offx, int Offy)
        {
            this.Parent = Parent;
            
            DrawOffsetX = Offx;
            DrawOffsetY = Offy;
            TileID = Tile;
            MapToEdit = map;
        }

        public override void SetBrush(int ID)
        {
            TileID = ID;
        }
        public override void Draw(Graphics graphics)
        {
            if (StartMade)
            {
                graphics.FillRectangle(System.Drawing.Brushes.Green, MapToEdit.ToScreenSpaceX(StartPoint.X) - 1, MapToEdit.ToScreenSpaceY(StartPoint.Y) - 1, 17, 17);
                
            }
        }

        public override bool Update()
        {
            if ((LastMouseDown == false) && (MouseDown == true))
            {
                StartPoint = Position;
                StartMade = true;
            }

            if ((LastMouseDown == true) && (MouseDown == false))
            {
                Point EndPoint = Position;
                if(StartPoint.X > EndPoint.X)
                {
                    int temp = StartPoint.X;
                    StartPoint.X = EndPoint.X;
                    EndPoint.X = temp;
                }

                if (StartPoint.Y > EndPoint.Y)
                {
                    int temp = StartPoint.Y;
                    StartPoint.Y = EndPoint.Y;
                    EndPoint.Y = temp;
                }
                Parent.Cursor = Cursors.WaitCursor;
                for (int i = StartPoint.X; i < EndPoint.X+1; i++)
                    for (int j = StartPoint.Y; j < EndPoint.Y+1; j++)
                        MapToEdit.SetTile(new point.Point(i, j), TileID);
                Parent.Cursor = Cursors.Default;
                StartPoint = new Point(-1,-1);
                EndPoint = new Point(-1,-1);

                StartMade = false;
                LastMouseDown = MouseDown;
                return true;
            }

            LastMouseDown = MouseDown;
            return false;
        }
    }
}
