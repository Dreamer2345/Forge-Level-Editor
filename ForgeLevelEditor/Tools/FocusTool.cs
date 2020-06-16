using System;
using System.Windows.Forms;

using ForgeLevelEditor.Controls;

namespace ForgeLevelEditor.Tools
{
    public class FocusTool : ITool<MapEditorControl>
    {
        private MapEditorControl control;

        public void Attach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != null)
                throw new ArgumentException("this tool is already attached to a control");

            this.control = control;
            this.control.MouseUp += this.Control_MouseUp;
        }

        public void Detach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != control)
                throw new ArgumentException("control is not the attached control");

            this.control.MouseUp -= this.Control_MouseUp;
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            this.control.MapCollection.CurrentMap.DrawPosition = this.control.MapCollection.CurrentMap.ToTileSpace(e.Location);
            this.control.CompleteSingleAction(this);
            this.control.Invalidate();
        }
    }
}
