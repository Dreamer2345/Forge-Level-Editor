using ForgeLevelEditor.TextureHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeLevelEditor.map.Component
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
            Bitmap bitmap = TextureManager.GetTexture(SpriteManager.GetSprite(Type).TextureID);
            bitmap.MakeTransparent(Color.FromArgb(255, 119, 168));
            graphics.DrawImage(bitmap, Pos.X, Pos.Y, Size.X, Size.Y);
        }
    }
}
