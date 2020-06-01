﻿using ForgeLevelEditor.map.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeLevelEditor.Tools
{
    public class TileSelectedEventArgs : EventArgs
    {

        public Point Location;
        public Tile Tile;

    }
}
