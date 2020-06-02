using ForgeLevelEditor.map.Component;
using ForgeLevelEditor.TextureHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeLevelEditor.map.Component
{

    public class BaseMapComponent : DrawComponent
    {
        public int tileID = -1;

        public BaseMapComponent(int ID)
        {
            tileID = ID;
        }

        public override void Draw(Graphics graphics, Point Pos, Point Size)
        {
            if (Pos == null)
                return;

            Bitmap bitmap = TextureManager.GetTexture(TileManager.GetTile(tileID).TextureID);
            bitmap.MakeTransparent(Color.FromArgb(255, 119, 168));
            graphics.DrawImage(bitmap, Pos.X, Pos.Y, Size.X, Size.Y);
            
        }
    }
}
