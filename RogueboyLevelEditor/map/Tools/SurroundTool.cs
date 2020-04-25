using RogueboyLevelEditor.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueboyLevelEditor.map.Tools
{
    class SurroundTool : Tool
    {
        MapEditorForm form;
        bool BorderChanged = true;
        public SurroundTool(Map map, MapEditorForm form)
        {
            MapToEdit = map;
            this.form = form;
        }


        public override void SetBrush(int ID)
        {
            if (MapToEdit.OutOfBoundsTile.tileID != ID)
            {
                form.pictureBox1.Invalidate();
                MapToEdit.OutOfBoundsTile = new Component.BaseMapComponent(ID);
                BorderChanged = true;
            }
        }


        public override void Draw(Graphics graphics)
        {
            
        }

        public override bool Update()
        {
            if (BorderChanged)
            {
                BorderChanged = false;
                return true;
            }
            return false;
        }
    }
}
