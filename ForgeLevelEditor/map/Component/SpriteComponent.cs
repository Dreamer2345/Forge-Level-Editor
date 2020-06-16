using System.Drawing;

using ForgeLevelEditor.TextureHandler;

namespace ForgeLevelEditor.map.Component
{
    public class SpriteComponent
    {
        public int Type;
        public Point SpritePosition;
        public int Health;

        public SpriteComponent(Point position, int type, int health)
        {
            this.Type = type;
            this.SpritePosition = position;
            this.Health = health;
        }

        public void Draw(Graphics graphics, Point position, Point size)
        {
            Bitmap bitmap = TextureManager.GetTexture(SpriteManager.GetSprite(Type).TextureID);
            bitmap.MakeTransparent(Color.FromArgb(255, 119, 168));
            graphics.DrawImage(bitmap, position.X, position.Y, size.X, size.Y);
        }
    }
}
