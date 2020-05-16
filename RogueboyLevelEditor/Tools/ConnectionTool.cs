using System;
using System.Drawing;
using System.Windows.Forms;

using RogueboyLevelEditor.Controls;
using RogueboyLevelEditor.map.Component;

namespace RogueboyLevelEditor.Tools
{
    public class ConnectionTool : ITool<MapEditorControl>
    {
        private static readonly SpriteManager spriteManager = new SpriteManager();

        private MapEditorControl control;
        private ListView listView;

        private Point? startPoint = null;

        public ConnectionTool(ListView listView)
        {
            this.listView = listView;
        }

        public void Attach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != null)
                throw new ArgumentException("this tool is already attached to a control");

            this.control = control;
            this.control.MouseDown += this.Control_MouseDown;
            this.control.Paint += this.Control_Paint;
        }

        public void Detach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != control)
                throw new ArgumentException("control is not the attached control");

            this.control.MouseDown -= this.Control_MouseDown;
        }

        private void AddConnection(Point startPoint, Point endPoint)
        {
            var effectComponent = this.control.CurrentMap.AddConnection(startPoint, endPoint);

            var listViewItem = new ListViewItem(effectComponent.IsValid.ToString());

            _ = listViewItem.SubItems.Add(effectComponent.Start.X.ToString());
            _ = listViewItem.SubItems.Add(effectComponent.Start.Y.ToString());
            _ = listViewItem.SubItems.Add(effectComponent.End.X.ToString());
            _ = listViewItem.SubItems.Add(effectComponent.End.Y.ToString());

            this.listView.Items.Add(listViewItem);
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (!e.Button.HasFlag(MouseButtons.Left))
                return;

            var location = this.control.MapCollection.CurrentMap.ToTileSpace(e.Location);

            if (!this.control.CurrentMap.CheckInRange(location.X, location.Y))
                return;

            if (!this.startPoint.HasValue)
            {
                this.startPoint = location;
            }
            else
            {
                var startPoint = this.startPoint.Value;
                var endPoint = location;

                this.AddConnection(startPoint, endPoint);

                this.startPoint = null;
            }

            this.control.Invalidate();
        }

        private void Control_Paint(object sender, PaintEventArgs e)
        {
            if (this.startPoint.HasValue)
            {
                var map = this.control.CurrentMap;
                var tilePoint = this.startPoint.Value;

                var start = (map.ToScreenSpace(tilePoint) - new Size(1, 1));
                var end = map.ToScreenSpace(tilePoint + new Size(1, 1));

                var rectangle = Rectangle.FromLTRB(start.X, start.Y, end.X, end.Y);

                e.Graphics.DrawRectangle(Pens.LawnGreen, rectangle);
            }
        }
    }
}
