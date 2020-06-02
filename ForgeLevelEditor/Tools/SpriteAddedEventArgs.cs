using ForgeLevelEditor.map.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeLevelEditor.Tools
{
    public class SpriteAddedEventArgs : EventArgs
    {

        public Point Location;
        public Sprite Sprite;

    }
}
