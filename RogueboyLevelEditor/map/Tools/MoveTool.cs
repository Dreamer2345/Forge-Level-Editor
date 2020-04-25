using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueboyLevelEditor.map.Tools
{
    class MoveTool : Tool
    {
        bool LastMouseDown = false;


        public MoveTool(Map map)
        {
            MapToEdit = map;
        }

        public override void Draw(Graphics graphics)
        {
            
        }

        public override bool Update()
        {
            if((LastMouseDown == false)&&(MouseDown == true))
            {
                MapToEdit.DrawPos = point.Point.ToPoint(Position);
                LastMouseDown = MouseDown;
                return true;
            }

            LastMouseDown = MouseDown;
            return false;
        }
    }
}
