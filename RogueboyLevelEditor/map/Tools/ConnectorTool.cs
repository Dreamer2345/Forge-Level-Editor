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
    class ConnectorTool : Tool
    {
        bool First = false;
        Point FirstPosition = Point.Empty;
        bool LastMouse = false;
        MapEditorForm ParentForm;

        public ConnectorTool(Map map, MapEditorForm form)
        {
            ParentForm = form;
            MapToEdit = map;
        }


        public override void Draw(Graphics graphics)
        {
            if (First)
            {
                Pen pen = new Pen(Color.LawnGreen);
                graphics.DrawRectangle(pen, MapToEdit.ToScreenSpaceX(FirstPosition.X) - 1, MapToEdit.ToScreenSpaceY(FirstPosition.Y) - 1 , 17, 17);
            }
        }

        public override bool Update()
        {
            if (((MouseDown == true) && (LastMouse == false))&&(First == false))
            {
                LastMouse = MouseDown;
                if (!MapToEdit.CheckInRange(Position.X, Position.Y))
                    return false;

                First = true;
                FirstPosition = Position;
                return true;
            }
            else if (((MouseDown == true) && (LastMouse == false)) && (First == true))
            {
                LastMouse = MouseDown;
                if (!MapToEdit.CheckInRange(Position.X, Position.Y))
                {
                    First = false;
                    FirstPosition = Point.Empty;
                    return false;
                }

                EnviromentAffectComponent env = MapToEdit.AddConnection(FirstPosition, Position); 
                ListViewItem newItem = new ListViewItem(env.IsValid.ToString());
                newItem.SubItems.Add(env.Start.X.ToString());
                newItem.SubItems.Add(env.Start.Y.ToString());
                newItem.SubItems.Add(env.End.X.ToString());
                newItem.SubItems.Add(env.End.Y.ToString());
                ParentForm.ConnectionListView.Items.Add(newItem);

                
                First = false;
                FirstPosition = Point.Empty;
                return true;
            }


            LastMouse = MouseDown;
            return false;
        }
    }
}
