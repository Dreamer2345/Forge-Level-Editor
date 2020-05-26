using RogueboyLevelEditor.map.point;
using RogueboyLevelEditor.TextureHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;

namespace RogueboyLevelEditor.map.Component
{
    public class SpriteComponent : DrawComponent
    {
        public int Type;
        public Point SpritePosition;
        public int Health;

        public SpriteComponent(Point pos, int type, int health)
        {
            this.Type = type;
            this.SpritePosition = pos;
            this.Health = health;
        }

        public override void Draw(Graphics graphics, Point Pos, Point Size)
        {
            TextureManager Texture = new TextureManager();
            SpriteManager sm = new SpriteManager();
            Bitmap bitmap = Texture.GetTexture(sm.GetSprite(Type).TextureID);
            bitmap.MakeTransparent(Color.FromArgb(255, 119, 168));
            graphics.DrawImage(bitmap, Pos.X, Pos.Y, Size.X, Size.Y);
        }
    }
}
