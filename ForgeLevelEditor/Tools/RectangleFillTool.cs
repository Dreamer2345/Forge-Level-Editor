using System;
using System.Drawing;
using System.Windows.Forms;

using ForgeLevelEditor.Controls;

namespace ForgeLevelEditor.Tools
{
    public class RectangleFillTool : ITool<MapEditorControl>
    {
        // Half-transparent green
        private static readonly Color defaultColor = Color.FromArgb(127, 0, 255, 0);

        private MapEditorControl control;
        private Point? startPoint;
        private Point? endPoint;

        public Color Colour { get; set; } = defaultColor;

        public void Attach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != null)
                throw new ArgumentException("this tool is already attached to a control");

            this.control = control;
            this.control.MouseUp += this.Control_MouseUp;
            this.control.MouseMove += this.Control_MouseMove;
            this.control.MouseDown += this.Control_MouseDown;
            this.control.Paint += this.Control_Paint;
        }

        public void Detach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != control)
                throw new ArgumentException("control is not the attached control");

            this.control.MouseUp -= this.Control_MouseUp;
            this.control.MouseMove -= this.Control_MouseMove;
            this.control.MouseDown -= this.Control_MouseDown;
            this.control.Paint -= this.Control_Paint;
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                if (!this.startPoint.HasValue)
                {
                    this.startPoint = e.Location;
                    this.endPoint = e.Location;
                    this.control.Invalidate();
                }
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                if (this.startPoint.HasValue)
                {
                    this.endPoint = e.Location;
                    this.control.Invalidate();
                }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                if (this.startPoint.HasValue && this.endPoint.HasValue)
                {
                    // Cache the map
                    var map = this.control.MapCollection.CurrentMap;

                    // Get the start and end tiles
                    var startLocation = map.ToTileSpace(this.startPoint.Value);
                    var endLocation = map.ToTileSpace(e.Location);

                    // Ensure the points go from low coordinates to high coordinates
                    var startX = Math.Min(startLocation.X, endLocation.X);
                    var startY = Math.Min(startLocation.Y, endLocation.Y);
                    var endX = Math.Max(startLocation.X, endLocation.X);
                    var endY = Math.Max(startLocation.Y, endLocation.Y);

                    // Cache the tile id
                    var tileId = this.control.SelectedTileId;

                    // Set the tiles
                    for (int y = startY; y <= endY; ++y)
                        for (int x = startX; x <= endX; ++x)
                            map.SetTile(new Point(x, y), tileId);

                    // Nullify the start and end points
                    this.startPoint = null;
                    this.endPoint = null;

                    // Request a redraw
                    this.control.Invalidate();
                }
        }

        private void Control_Paint(object sender, PaintEventArgs e)
        {
            if (this.startPoint.HasValue && this.endPoint.HasValue)
            {
                // Cache the map
                var map = this.control.MapCollection.CurrentMap;

                // Get the start and end points
                var startLocation = map.ToTileSpace(this.startPoint.Value);
                var endLocation = map.ToTileSpace(this.endPoint.Value);

                // Ensure the points go from low coordinates to high coordinates
                var startX = Math.Min(startLocation.X, endLocation.X);
                var startY = Math.Min(startLocation.Y, endLocation.Y);
                var endX = Math.Max(startLocation.X, endLocation.X);
                var endY = Math.Max(startLocation.Y, endLocation.Y);

                // Adjust the coordinates to be tile-aligned
                startX = map.ToScreenSpaceX(startX);
                startY = map.ToScreenSpaceY(startY);
                endX = map.ToScreenSpaceX(endX + 1);
                endY = map.ToScreenSpaceY(endY + 1);

                // Create the rectangle
                var rectangle = Rectangle.FromLTRB(startX, startY, endX, endY);

                // Draw the rectangle
                using (var brush = new SolidBrush(this.Colour))
                    e.Graphics.FillRectangle(brush, rectangle);
            }
        }
    }
}
