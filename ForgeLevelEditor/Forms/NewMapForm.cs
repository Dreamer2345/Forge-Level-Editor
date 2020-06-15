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
using ForgeLevelEditor.map;
using ForgeLevelEditor.map.Component;
using ForgeLevelEditor.mapCollection;
using System.Text.RegularExpressions;

namespace ForgeLevelEditor.Forms
{
    public delegate void Callback(NewMapForm form);
    public partial class NewMapForm : Form
    {
        // Strictly speaking the range of valid characters is greater than this,
        // but restricting to just alphanumerics is probably wise for sensible map names.
        private static Regex identifierRegex = new Regex("^[_a-zA-Z][_a-zA-Z0-9]*$");

        public event Callback callback;
        public Map Output { get; private set; }
        private MapCollection mapCollection;
        public bool Valid = false;
        private string Filepath;

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
            if (string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                this.errorProvider1.SetError(this.textBox1, "Map name cannot be empty");
                return;
            }

            // Check to see if map name is taken (ignore if we are editing the matched record) ..

            foreach (Map map in this.mapCollection.GetMaps()) {

                if ((map.Name == textBox1.Text && Output == null) || (map.Name == textBox1.Text && map != Output)) {
                    errorProvider1.SetError(textBox1, "Two Maps cannot have the same name.");
                    return;

                }
            }

            if(!identifierRegex.IsMatch(textBox1.Text))
            {
                this.errorProvider1.SetError(this.textBox1, "Map name is not a valid identifier");
                return;
            }

            if (Output == null) {
                Output = new Map(new BaseMapComponent(-1), textBox1.Text, (int)mapWidthUpDown.Value, (int)mapHeightUpDown.Value, (int)mapTimerUpDown.Value);
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Valid = false;
            callback?.Invoke(this);
        }
    }
}
