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

        public SpriteComponent(Point pos, int Type)
        {
            this.Type = Type;
            this.SpritePosition = pos;
        }

        public override void Draw(Graphics graphics, Point Pos)
        {
            TextureManager Texture = new TextureManager();
            SpriteManager sm = new SpriteManager();
            Bitmap bitmap = Texture.GetTexture(sm.GetSprite(Type).TextureID);
            graphics.DrawImage(bitmap, Pos.X + 4, Pos.Y+4, 8, 8);
        }
    }
}
