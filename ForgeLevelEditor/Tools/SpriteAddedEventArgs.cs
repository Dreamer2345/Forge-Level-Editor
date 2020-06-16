using System;
using System.Drawing;

using ForgeLevelEditor.map.Component;

namespace ForgeLevelEditor.Tools
{
    public class SpriteAddedEventArgs : EventArgs
    {

        public Point Location;
        public Sprite Sprite;

    }
}
