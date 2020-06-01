using System;
using System.Drawing;
using System.Windows.Forms;

using ForgeLevelEditor.Controls;
using ForgeLevelEditor.map.Component;

namespace ForgeLevelEditor.Tools
{
    public class SpritePlacementTool : ITool<MapEditorControl>
    {
        private MapEditorControl control;
        private readonly ListView listView;

        public SpritePlacementTool(ListView listView)
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
        }

        public void Detach(MapEditorControl control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            if (this.control != control)
                throw new ArgumentException("control is not the attached control");

            this.control.MouseDown -= this.Control_MouseDown;
        }

        private Sprite AddSprite(Point point)
        {
            var spriteId = this.control.SelectedSpriteId;

            if (spriteId == -1)
                return null;

            var sprite = SpriteManager.GetSprite(spriteId);
            _ = this.control.CurrentMap.AddSprite(point.X, point.Y, spriteId, sprite.Health);
            this.control.AddSprite(point, sprite);

            var listViewItem = new ListViewItem();

            _ = listViewItem.SubItems.Add(spriteId.ToString());
            _ = listViewItem.SubItems.Add(sprite.Name);
            _ = listViewItem.SubItems.Add(point.X.ToString());
            _ = listViewItem.SubItems.Add(point.Y.ToString());
            _ = listViewItem.SubItems.Add(sprite.Health == 0 ? "" : sprite.Health.ToString());

            listViewItem.ImageKey = sprite.TextureID;

            _ = this.listView.Items.Add(listViewItem);

            return sprite;
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (!e.Button.HasFlag(MouseButtons.Left))
                return;

            var location = this.control.CurrentMap.ToTileSpace(e.Location);

            if (!this.control.CurrentMap.CheckInRange(location.X, location.Y))
                return;

            _ = this.AddSprite(location);
            this.control.Invalidate();
        }
    }
}
