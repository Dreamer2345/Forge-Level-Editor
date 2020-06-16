using System.Drawing;

using ForgeLevelEditor.TextureHandler;

namespace ForgeLevelEditor.map.Component
{
    public class BaseMapComponent
    {
        public int tileID = -1;

        public BaseMapComponent(int id)
        {
            tileID = id;
        }

        public void Draw(Graphics graphics, Point position, Point size)
        {
            if (position == null)
                return;

            Bitmap bitmap = TextureManager.GetTexture(TileManager.GetTile(tileID).TextureID);
            bitmap.MakeTransparent(Color.FromArgb(255, 119, 168));
            graphics.DrawImage(bitmap, position.X, position.Y, size.X, size.Y);
        }
    }
}
