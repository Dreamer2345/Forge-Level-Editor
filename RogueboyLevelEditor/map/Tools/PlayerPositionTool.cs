using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueboyLevelEditor.map.Tools
{
    class PlayerPositionTool : Tool
    {
        bool LastMouseDown = false;


        public PlayerPositionTool(Map map)
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
                MapToEdit.PlayerStart = Position;
                LastMouseDown = MouseDown;
                return true;
            }

            LastMouseDown = MouseDown;
            return false;

        }

    }

}
