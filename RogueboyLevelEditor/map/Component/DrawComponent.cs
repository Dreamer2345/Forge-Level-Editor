using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueboyLevelEditor.map.Component
{
    public abstract class DrawComponent
    {
        public abstract void Draw(Graphics graphics, Point Pos);
    }
}
