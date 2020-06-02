using System;
using System.Windows.Forms;

using ForgeLevelEditor.Controls;

namespace ForgeLevelEditor.Tools
{
    public class PlayerPlacementTool : ITool<MapEditorControl>
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
        }

        public void Detach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != control)
                throw new ArgumentException("control is not the attached control");

            this.control.MouseDown -= this.Control_MouseDown;
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            var location = this.control.MapCollection.CurrentMap.ToTileSpace(e.Location);

            this.control.CurrentMap.PlayerStart = location;

            this.control.Invalidate();
        }
    }
}
