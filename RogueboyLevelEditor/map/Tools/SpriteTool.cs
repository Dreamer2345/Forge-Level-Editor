using RogueboyLevelEditor.Forms;
using RogueboyLevelEditor.map.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogueboyLevelEditor.map.Tools
{
    class SpriteTool : Tool
    {
        bool LastMouse = false; 
        int currentSprite = -1;
        MapEditorForm ParentForm;

        public SpriteTool(Map map, MapEditorForm form)
        {
            MapToEdit = map;
            ParentForm = form;
        }


        public override void SetBrush(int ID)
        {
            currentSprite = ID;
        }

        public override void Draw(Graphics graphics)
        {
            
        }

        public override bool Update()
        {
            if ((MouseDown == true) && (LastMouse == false))
            {
                LastMouse = MouseDown;
                if (!MapToEdit.CheckInRange(Position.X, Position.Y))
                    return false;
                SpriteManager sm = new SpriteManager();
                MapToEdit.AddSprite(Position.X, Position.Y, currentSprite);
                Sprite sprite = sm.GetSprite(currentSprite);
                ListViewItem newItem = new ListViewItem();
                newItem.SubItems.Add(currentSprite.ToString());
                newItem.SubItems.Add(Position.X.ToString());
                newItem.SubItems.Add(Position.Y.ToString());
                newItem.ImageKey = sprite.TextureID;
                ParentForm.listView3.Items.Add(newItem);
                //ParentForm.listBox1.Items.Add(currentSprite + ":"+Position.X+":"+Position.Y+":" + sm.GetSprite(currentSprite).Name);
                return true;
            }
            LastMouse = MouseDown;


            return false;
        }
    }
}
