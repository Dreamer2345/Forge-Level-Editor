using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RogueboyLevelEditor.Forms;
using RogueboyLevelEditor.map;
using RogueboyLevelEditor.mapCollection;

namespace RogueboyLevelEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            openFileDialog1.FileName = "Map";
            openFileDialog1.InitialDirectory = "/Maps";
            openFileDialog1.DefaultExt = ".h";
            openFileDialog1.Filter = "C++ Header|*.h";
            DialogResult diag = openFileDialog1.ShowDialog();
            if(diag == DialogResult.OK)
            {
                if (openFileDialog1.CheckFileExists)
                {
                    MapCollection maps = new MapCollection();
                    maps.FileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                    maps.FilePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                    maps.AddMaps(MapCollection.LoadMaps(openFileDialog1.FileName));

                    if (maps.OpenCount == 0)
                    {
                        errorProvider1.SetError(button1, "Error parsing map File");
                        return;
                    }
                    MapEditorForm mapform = new MapEditorForm(maps);
                    mapform.Owner = this;
                    mapform.Show();
                    this.Hide();
                }
                else
                {
                    errorProvider1.SetError(button1, "File Does not Exist");
                }
            }
            else
            {
                if(diag != DialogResult.Cancel)
                    errorProvider1.SetError(button1, "File Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            NewMapForm form = new NewMapForm();
            form.Owner = this;
            form.callback += Form_callback;
            form.Show();
            this.Hide();
        }

        private void Form_callback(NewMapForm form)
        {
            if (form.Valid)
            {
                Map newMap = form.Output;
                MapEditorForm mapform = new MapEditorForm(newMap);
                mapform.Owner = this;
                mapform.Show();
            }
            else
            {
                this.Show();
            }
            form.CloseForm();
        }

    }
}
