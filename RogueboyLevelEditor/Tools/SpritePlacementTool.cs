using System;
using System.Windows.Forms;

using RogueboyLevelEditor.Controls;
using RogueboyLevelEditor.map.Component;

namespace RogueboyLevelEditor.Tools
{
    public class SpritePlacementTool : ITool<MapEditorControl>
    {
        private static readonly SpriteManager spriteManager = new SpriteManager();

        private MapEditorControl control;
        private ListView listView;

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

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (!e.Button.HasFlag(MouseButtons.Left))
                return;

            var location = this.control.MapCollection.CurrentMap.ToTileSpace(e.Location);

            if (!this.control.CurrentMap.CheckInRange(location.X, location.Y))
                return;

            var spriteId = this.control.SelectedSpriteId;
            var sprite = spriteManager.GetSprite(spriteId);
            this.control.CurrentMap.AddSprite(location.X, location.Y, spriteId, sprite.Health);

            var listViewItem = new ListViewItem();

            listViewItem.SubItems.Add(spriteId.ToString());
            listViewItem.SubItems.Add(location.X.ToString());
            listViewItem.SubItems.Add(location.Y.ToString());
            listViewItem.SubItems.Add(sprite.Health.ToString());

            listViewItem.ImageKey = sprite.TextureID;

            this.listView.Items.Add(listViewItem);

            this.control.Invalidate();
        }
    }
}
