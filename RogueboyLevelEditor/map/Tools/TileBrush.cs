using System.Drawing;

namespace RogueboyLevelEditor.map.Tools
{
    class TileBrush : Tool
    {
        int CurrentTile;

        public override void SetBrush(int ID)
        {
            CurrentTile = ID;
        }

        public TileBrush(int tile, Map map)
        {
            MapToEdit = map;
            CurrentTile = tile;
        }

        public override void Draw(Graphics graphics)
        {

        }

        public override bool Update()
        {
            if (MouseDown)
            {
                MapToEdit.SetTile(new Point(Position.X, Position.Y), CurrentTile);
                return true;
            }
            return false;
        }
    }
}
