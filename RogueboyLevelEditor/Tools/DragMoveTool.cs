using System;
using System.Drawing;
using System.Windows.Forms;

using RogueboyLevelEditor.Controls;

namespace RogueboyLevelEditor.Tools
{
    public class DragMoveTool : ITool<MapEditorControl>
    {
        private MapEditorControl control;
        private Point? startLocation;
        private Cursor oldCursor;

        public void Attach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != null)
                throw new ArgumentException("this tool is already attached to a control");

            this.control = control;
            this.control.MouseDown += this.Control_MouseDown;
            this.control.MouseUp += this.Control_MouseUp;
            this.control.MouseMove += this.Control_MouseMove;

            this.oldCursor = this.control.Cursor;
            this.control.Cursor = Cursors.SizeAll;
        }

        public void Detach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != control)
                throw new ArgumentException("control is not the attached control");

            this.control.MouseDown -= this.Control_MouseDown;
            this.control.MouseUp -= this.Control_MouseUp;
            this.control.MouseMove -= this.Control_MouseMove;

            this.control.Cursor = this.oldCursor;
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.startLocation.HasValue)
                this.startLocation = e.Location;
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.startLocation.HasValue)
            {
                var startLocation = this.startLocation.Value;
                var endLocation = e.Location;

                this.control.CurrentMap.drawOffsetX += (endLocation.X - startLocation.X);
                this.control.CurrentMap.drawOffsetY += (endLocation.Y - startLocation.Y);

                this.startLocation = null;
                this.control.CompleteSingleAction(this);

                this.control.Invalidate();
            }
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (startLocation.HasValue)
            {
                var startLocation = this.startLocation.Value;
                var endLocation = e.Location;

                this.control.CurrentMap.drawOffsetX += (endLocation.X - startLocation.X);
                this.control.CurrentMap.drawOffsetY += (endLocation.Y - startLocation.Y);

                this.startLocation = e.Location;

                this.control.Invalidate();
            }
        }
    }
}
