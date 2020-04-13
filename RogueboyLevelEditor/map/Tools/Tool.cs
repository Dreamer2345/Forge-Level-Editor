using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueboyLevelEditor.map.Tools
{
    public abstract class Tool
    {
        public Map MapToEdit;

        public bool MouseDown = false;
        public Point Position = new Point(0, 0);


        
        public virtual void SetBrush(int ID) { }

        public abstract bool Update();
        public abstract void Draw(Graphics graphics);
    }
}
