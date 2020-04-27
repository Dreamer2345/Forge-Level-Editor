using System;
using System.Drawing;
using System.Windows.Forms;

using RogueboyLevelEditor.Controls;

namespace RogueboyLevelEditor.Tools
{
    public class TileTool : ITool<MapEditorControl>
    {
        private MapEditorControl control;

        public void Attach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != null)
                throw new ArgumentException("this tool is already attached to a control");

            this.control = control;
            this.control.MouseDown += this.Control_MouseDown;
            this.control.MouseMove += this.Control_MouseMove;
        }

        public void Detach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != control)
                throw new ArgumentException("control is not the attached control");

            this.control.MouseDown -= this.Control_MouseDown;
            this.control.MouseMove -= this.Control_MouseMove;
        }

        private void SetTile(Point point)
        {
            var location = this.control.MapCollection.CurrentMap.ToTileSpace(point);
            var tileId = this.control.SelectedTileId;

            this.control.MapCollection.CurrentMap.SetTile(map.point.Point.ToPoint(location), tileId);
            this.control.Invalidate();
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            SetTile(e.Location);
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                SetTile(e.Location);
        }
    }
}
