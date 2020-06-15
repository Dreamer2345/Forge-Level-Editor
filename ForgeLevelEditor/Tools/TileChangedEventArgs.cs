using System;
using System.Drawing;

using ForgeLevelEditor.map.Component;

namespace ForgeLevelEditor.Tools
{
    public class TileChangedEventArgs : EventArgs
    {

        public Point Location;
        public Tile OrigTile;
        public Tile NewTile;

    }
}
