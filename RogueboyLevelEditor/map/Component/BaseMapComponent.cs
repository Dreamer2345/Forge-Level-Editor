using RogueboyLevelEditor.map.Component;
using RogueboyLevelEditor.TextureHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueboyLevelEditor.map.Component
{

    public class BaseMapComponent : DrawComponent
    {
        public int tileID = -1;

        public BaseMapComponent(int ID)
        {
            tileID = ID;
        }

        public override void Draw(Graphics graphics, Point Pos)
        {
            if (Pos == null)
                return;
            TextureManager Texture = new TextureManager();
            TileManager Tiles = new TileManager();
            Bitmap bitmap = Texture.GetTexture(Tiles.GetTile(tileID).TextureID);
            if((bitmap.Width != 16) || (bitmap.Height != 16))
                Console.WriteLine(bitmap.Width + ":" + bitmap.Height);
            graphics.DrawImage(bitmap, Pos.X, Pos.Y, 16, 16);
            
            
        }
    }
}
