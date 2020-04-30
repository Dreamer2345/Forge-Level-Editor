using System;
using System.Drawing;
using System.Windows.Forms;

using RogueboyLevelEditor.map;
using RogueboyLevelEditor.map.Component;
using RogueboyLevelEditor.mapCollection;
using RogueboyLevelEditor.Tools;
using RogueboyLevelEditor.TextureHandler;

namespace RogueboyLevelEditor.Controls
{
    public class MapEditorControl : Control
    {
        private readonly TextureManager textureManager = new TextureManager();
        private readonly TileManager tileManager = new TileManager();

        private MapCollection mapCollection = new MapCollection();
        private ITool<MapEditorControl> tool = null;
        private Point? tileCursor = null;
        private int selectedTileId = -1;
        private int selectedSpriteId = -1;

        public MapEditorControl()
        {
            this.DoubleBuffered = true;
        }

        public MapCollection MapCollection
        {
            get => this.mapCollection;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("MapCollection");

                this.mapCollection = value;
            }
        }

        public Map CurrentMap
        {
            get => this.mapCollection.CurrentMap;
            set => this.mapCollection.CurrentMap = value;
        }

        public ITool<MapEditorControl> Tool
        {
            get => this.tool;
            set
            {
                if (this.tool != null)
                    this.tool.Detach(this);

                this.tool = value;

                if (this.tool != null)
                    this.tool.Attach(this);
            }
        }

        public int SelectedTileId
        {
            get => this.selectedTileId;
            set
            {
                this.selectedTileId = value;
                this.Invalidate();
            }
        }

        public int SelectedSpriteId
        {
            get => selectedSpriteId;
            set
            {
                this.selectedSpriteId = value;
                this.Invalidate();
            }
        }

        private void DrawSelectedTile(Graphics graphics)
        {
            var textureId = this.tileManager.GetTile(this.SelectedTileId).TextureID;
            var bitmap = this.textureManager.GetTexture(textureId);

            // This colour seems arbitrary
            bitmap.MakeTransparent(Color.FromArgb(255, 119, 168));

            graphics.DrawImage(bitmap, 8, 8, 16, 16);
        }

        private void DrawTileCursor(Graphics graphics)
        {
            if (this.tileCursor.HasValue)
                graphics.DrawRectangle(Pens.Red, this.tileCursor.Value.X - 1, this.tileCursor.Value.Y - 1, 16 + 2, 16 + 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.mapCollection?.Draw(e.Graphics);

            this.DrawSelectedTile(e.Graphics);
            this.DrawTileCursor(e.Graphics);

            base.OnPaint(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            var map = this.MapCollection?.CurrentMap;

            if (map != null)
                this.tileCursor = map.ToScreenSpace(map.ToTileSpace(e.Location));

            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.tileCursor = null;

            this.Invalidate();
        }
    }
}
