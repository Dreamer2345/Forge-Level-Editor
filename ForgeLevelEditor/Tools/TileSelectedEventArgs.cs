using System;
using System.Drawing;

using ForgeLevelEditor.map.Component;

namespace ForgeLevelEditor.Tools
{
    public class TileSelectedEventArgs : EventArgs
    {

        public Point Location;
        public Tile Tile;

    }
}
