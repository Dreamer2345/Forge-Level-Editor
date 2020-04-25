using RogueboyLevelEditor.map.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueboyLevelEditor.map.Tools
{
    class TileBrush : Tool
    {
        int CurrentTile;

        public override void SetBrush(int ID)
        {
            CurrentTile = ID;
        }

        public TileBrush(int tile, Map map)
        {
            MapToEdit = map;
            CurrentTile = tile;
        }

        public override void Draw(Graphics graphics)
        {
            
        }

        public override bool Update()
        {
            if (MouseDown)
            {
                MapToEdit.SetTile(new point.Point(Position.X, Position.Y), CurrentTile);
                return true;
            }
            return false;
        }
    }
}
