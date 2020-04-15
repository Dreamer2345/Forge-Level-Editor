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

namespace RogueboyLevelEditor.Forms
{
    public delegate void Callback(NewMapForm form);
    public partial class NewMapForm : Form
    {
        public event Callback callback;
        public Map Output { get; private set; }
        string[] Taken;
        public bool Valid = false;
        string Filepath;
        public NewMapForm(string Filepath = "", string[] TakenNames = null)
        {
            Taken = TakenNames;
            this.Filepath = Filepath;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Value Cannot Be left Empty");
                return;
            }
            if(Taken != null)
                if(Taken.Contains(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "Two Maps cannot have the same name");
                    return;
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
            Output = new Map(new BaseMapComponent(-1),textBox1.Text, Filepath, (int)numericUpDown1.Value,(int)numericUpDown2.Value,(int)numericUpDown3.Value);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Valid = false;
            callback?.Invoke(this);
        }
    }
}
