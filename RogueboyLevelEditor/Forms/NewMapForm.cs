using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using RogueboyLevelEditor.map;
using RogueboyLevelEditor.map.Component;
using RogueboyLevelEditor.mapCollection;

namespace RogueboyLevelEditor.Forms
{
    public delegate void Callback(NewMapForm form);
    public partial class NewMapForm : Form
    {
        public event Callback callback;
        public Map Output { get; private set; }
        MapCollection mapCollection;
        public bool Valid = false;
        string Filepath;

        public NewMapForm(MapCollection mapCollection, Map mapToEdit = null, string Filepath = "")
        {
            Output = mapToEdit;
            this.Filepath = Filepath;
            this.mapCollection = mapCollection;
            InitializeComponent();

            if (mapToEdit == null) {
                this.Text = "Add a new Map";
            }
            else {
                this.Text = "Edit an Existing Map";
                this.textBox1.Text = Output.Name;
                this.mapWidthUpDown.Value = Output.Width;
                this.mapHeightUpDown.Value = Output.Height;
                this.mapTimerUpDown.Value = Output.Timer;
                this.createButton.Text = "Update";
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Value Cannot Be left Empty");
                return;
            }

            // Check to see if map name is taken (ignore if we are editing the matched record) ..

            foreach (Map map in this.mapCollection.GetMaps()) {

                if ((map.Name == textBox1.Text && Output == null) || (map.Name == textBox1.Text && map!= Output)) {
                    errorProvider1.SetError(textBox1, "Two Maps cannot have the same name");
                    return;
                }

            }

            //if (string.IsNullOrWhiteSpace(Filepath)||(Filepath == ""))
            //{
            //    folderBrowserDialog1.SelectedPath = Directory.GetCurrentDirectory() + "\\Maps";
            //    DialogResult result = folderBrowserDialog1.ShowDialog();

            //    if (result == DialogResult.Cancel)
            //    {
            //        return;
            //    }
            //    Filepath = folderBrowserDialog1.SelectedPath;
            //} 

            if (Output == null) {
                Output = new Map(new BaseMapComponent(-1), textBox1.Text, Filepath, (int)mapWidthUpDown.Value, (int)mapHeightUpDown.Value, (int)mapTimerUpDown.Value);
            }
            else {
                Output.Name = textBox1.Text;
                Output.Width = (int)mapWidthUpDown.Value;
                Output.Height = (int)mapHeightUpDown.Value;
                Output.Timer = (int)mapTimerUpDown.Value;
            }
            Valid = true;
            callback?.Invoke(this);
        }
        public void CloseForm()
        {
            this.Close();
        }

        private void NewMapForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += NewMapForm_FormClosing;
        }

        private void NewMapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    Valid = false;
            //    if (!Closing)
            //    {
            //        Closing = true;
            //        callback?.Invoke(this);
            //    }
            //}
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Valid = false;
            callback?.Invoke(this);
        }
    }
}
