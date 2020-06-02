using System;
using System.Drawing;
using System.Windows.Forms;

using ForgeLevelEditor.Controls;

namespace ForgeLevelEditor.Tools
{
    public class TileSelectTool : ITool<MapEditorControl>
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

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            this.SelectTileAt(e.Location);
            this.control.SelectTile(e.Location);
            this.control.CompleteSingleAction(this);
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                this.SelectTileAt(e.Location);
        }

        private void SelectTileAt(Point clientLocation)
        {
            var location = this.control.MapCollection.CurrentMap.ToTileSpace(clientLocation);
            var mapComponent = this.control.MapCollection.CurrentMap.GetTile(location);

            this.control.SelectedTileId = mapComponent.tileID;

            this.control.Invalidate();
        }
    }
}
