using RogueboyLevelEditor.map.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueboyLevelEditor.Tools
{
    public class TileChangedEventArgs : EventArgs
    {

        public Point Location;
        public Object OrigItem;
        public Object NewItem;

    }
}
