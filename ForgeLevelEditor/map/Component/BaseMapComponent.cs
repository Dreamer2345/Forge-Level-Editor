using System.Drawing;

using ForgeLevelEditor.TextureHandler;

namespace ForgeLevelEditor.map.Component
{
    public class BaseMapComponent
    {
        public int tileID = -1;

        public BaseMapComponent(int ID)
        {
            tileID = ID;
        }

        public void Draw(Graphics graphics, Point Pos, Point Size)
        {
            if (Pos == null)
                return;

            Bitmap bitmap = TextureManager.GetTexture(TileManager.GetTile(tileID).TextureID);
            bitmap.MakeTransparent(Color.FromArgb(255, 119, 168));
            graphics.DrawImage(bitmap, Pos.X, Pos.Y, Size.X, Size.Y);
        }
    }
}
