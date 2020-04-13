using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RogueboyLevelEditor.map;
using RogueboyLevelEditor.TextureHandler;
using RogueboyLevelEditor.map.Component;
using static RogueboyLevelEditor.TextureHandler.TextureManager;
using RogueboyLevelEditor.map.Tools;
using RogueboyLevelEditor.mapCollection;

namespace RogueboyLevelEditor.Forms
{
    public partial class MapEditorForm : Form
    {
        MapCollection mapCollection;
        TileCursor cursor;
        Tool tool;

        void AddTextures()
        {
            TextureManager textureManager = new TextureManager();
            ExceptionReport exception = textureManager.Load(Directory.GetCurrentDirectory() + "/Config/TextureAssignments.xml");
            if (exception.Failed)
            {
                MessageBox.Show(exception.exception.ToString(), "Error loading Textures", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void AddTiles()
        {
            TileManager tileManager = new TileManager();
            ExceptionReport exception = tileManager.Load(Directory.GetCurrentDirectory() + "/Config/TileAssignments.xml");
            if (exception.Failed)
            {
                MessageBox.Show(exception.exception.ToString(), "Error loading Tiles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        void AddSprites()
        {
            SpriteManager spriteManager = new SpriteManager();
            ExceptionReport exception = spriteManager.Load(Directory.GetCurrentDirectory() + "/Config/SpriteAssignments.xml");
            if (exception.Failed)
            {
                MessageBox.Show(exception.exception.ToString(), "Error loading Sprites", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public MapEditorForm(Map EditingMap)
        {
            mapCollection = new MapCollection();
            mapCollection.FilePath = EditingMap.Filepath;
            mapCollection.AddMap(EditingMap);
            cursor = new TileCursor();
            AddTextures();
            AddTiles();
            AddSprites();
            InitializeComponent();
        }
        public MapEditorForm(MapCollection EditingMaps)
        {
            mapCollection = EditingMaps;
            cursor = new TileCursor();
            AddTextures();
            AddTiles();
            AddSprites();
            InitializeComponent();
            
            if(mapCollection.CurrentMap != null)
            {
                UpdateCurrentSprites();
                UpdateCurrentConnectors();
            }
        }
        void UpdateCurrentSprites()
        {
            listView3.Items.Clear();
            SpriteManager sm = new SpriteManager();
            foreach (SpriteComponent i in mapCollection.CurrentMap.Sprites)
            {
                Sprite sprite = sm.GetSprite(i.Type);
                ListViewItem newItem = new ListViewItem();
                newItem.SubItems.Add(i.Type.ToString());
                newItem.SubItems.Add(i.SpritePosition.X.ToString());
                newItem.SubItems.Add(i.SpritePosition.Y.ToString());
                newItem.ImageKey = sprite.TextureID;
                listView3.Items.Add(newItem);
            }
        }
        void UpdateCurrentConnectors()
        {
            listView4.Items.Clear();
            foreach (EnviromentAffectComponent i in mapCollection.CurrentMap.Connectors)
            {
                EnviromentAffectComponent env = i;
                ListViewItem newItem = new ListViewItem(env.IsValid.ToString());
                newItem.SubItems.Add(env.Start.X.ToString());
                newItem.SubItems.Add(env.Start.Y.ToString());
                newItem.SubItems.Add(env.End.X.ToString());
                newItem.SubItems.Add(env.End.Y.ToString());
                listView4.Items.Add(newItem);
            }
        }
        void AddTilesToListView()
        {
            TextureManager textureManager = new TextureManager();
            TileManager tileManager = new TileManager();
            List<Tuple<int, Tile>> Tiles = tileManager.GetAllTiles();
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.FromArgb(255, 119, 168);

            foreach (Tuple<int, Tile> i in Tiles)
            {
                imageList.Images.Add(i.Item2.TextureID, textureManager.GetTexture(i.Item2.TextureID));
            }

            listView1.SmallImageList = imageList;

            foreach (Tuple<int, Tile> i in Tiles)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.SubItems.Add(i.Item1.ToString());
                newItem.SubItems.Add(i.Item2.Name);
                newItem.SubItems.Add(i.Item2.IsExit.ToString());
                newItem.SubItems.Add(i.Item2.IsSender.ToString());
                newItem.SubItems.Add(i.Item2.IsReciver.ToString());
                newItem.ImageKey = i.Item2.TextureID;
                listView1.Items.Add(newItem);
            }
        }
        void AddSpritesToListView()
        {
            TextureManager textureManager = new TextureManager();
            SpriteManager SpriteManager = new SpriteManager();
            List<Tuple<int, Sprite>> Tiles = SpriteManager.GetAllSprites();
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.FromArgb(255, 119, 168);

            foreach (Tuple<int, Sprite> i in Tiles)
            {
                imageList.Images.Add(i.Item2.TextureID, textureManager.GetTexture(i.Item2.TextureID));
            }

            listView2.SmallImageList = imageList;
            listView3.SmallImageList = imageList;
            foreach (Tuple<int, Sprite> i in Tiles)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.SubItems.Add(i.Item1.ToString());
                newItem.SubItems.Add(i.Item2.Name);
                newItem.ImageKey = i.Item2.TextureID;
                listView2.Items.Add(newItem);
            }
        }
        void AddMapToOpenWindows(Map map)
        {
            if (map == null)
                return;
            ToolStripMenuItem WindowsMenuButton = (ToolStripMenuItem)menuStrip1.Items["windowsToolStripMenuItem"];
            ToolStripMenuItem newMenuButton = new ToolStripMenuItem(map.Name);
            newMenuButton.Click += NewMenuButton_Click;
            newMenuButton.Tag = map;
            WindowsMenuButton.DropDownItems.Add(newMenuButton); 
        }
        private void NewMenuButton_Click(object sender, EventArgs e)
        {  
            ToolStripMenuItem MenuButton = (ToolStripMenuItem)sender;
            Map Chosen = (Map)MenuButton.Tag;
            if (mapCollection.ChangeMap(Chosen))
            {
                tool.MapToEdit = Chosen;
                UpdateCurrentSprites();
                UpdateCurrentConnectors();
                pictureBox1.Invalidate();
            }
        }
        private void MapEditorForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += MapEditorForm_FormClosing;
            pictureBox1.Paint += PictureBox1_Paint;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            mapCollection.drawOffsetX = (pictureBox1.Width / 2) - 8;
            mapCollection.drawOffsetY = (pictureBox1.Height / 2) - 8;
            mapCollection.viewWidth = (int)Math.Ceiling(pictureBox1.Width / 16d);
            mapCollection.viewHeight = (int)Math.Ceiling(pictureBox1.Height / 16d);
            cursor.drawOffsetX = (pictureBox1.Width / 2) - 8;
            cursor.drawOffsetY = (pictureBox1.Height / 2) - 8;
            tool = new TileBrush(-1, mapCollection.CurrentMap);
            
            
            if(mapCollection.OpenCount > 0)
                foreach(Map i in mapCollection.GetMaps())
                    AddMapToOpenWindows(i);

            listView1.Items.Clear();
            listView2.Items.Clear();
            AddTilesToListView();
            AddSpritesToListView();
        }
        private void MapEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (tool != null)
            {
                tool.MouseDown = false;
                if (tool.Update())
                    pictureBox1.Invalidate();
            }
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool != null)
            {
                tool.MouseDown = true;
                if (tool.Update())
                    pictureBox1.Invalidate();
            }
        }
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cursor.position = mapCollection.CurrentMap.ToTileSpace(e.Location);
            if (tool != null)
            {
                tool.Position = cursor.position;
                if(tool.Update())
                    pictureBox1.Invalidate();
            }

            if (cursor.PositionChanged)
            {
                pictureBox1.Invalidate();
            }
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            mapCollection.Draw(g);
            cursor.Draw(g,mapCollection.CurrentMap);
            tool?.Draw(g);
            ControlPaint.DrawBorder(g, pictureBox1.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }     
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        //Tools
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                int TileId = -1;
                if (listView1.SelectedItems.Count > 0)
                    TileId = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                tool = new TileBrush(TileId, mapCollection.CurrentMap);
                listView1.Visible = true;
            }
            else
            {
                listView1.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                tool = new TileBrush(-1, mapCollection.CurrentMap);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                tool = new MoveTool(mapCollection.CurrentMap);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mapCollection.CurrentMap.DrawPos = new map.point.Point(0, 0);
            pictureBox1.Invalidate();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                int TileId = -1;
                if (listView1.SelectedItems.Count > 0)
                    TileId = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                tool = new TileRectangle(this,TileId, mapCollection.CurrentMap, pictureBox1.Width / 2, pictureBox1.Height / 2);
                listView1.Visible = true;
            }
            else
            {
                listView1.Visible = false;
            }
            
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            if (radioButton7.Checked)
            {
                tool = new SurroundTool(mapCollection.CurrentMap,this);
                mapCollection.CurrentMap.ShowOutOfBounds = true;
                listView1.Visible = true;
            }
            else
            {
                mapCollection.CurrentMap.ShowOutOfBounds = false;
                listView1.Visible = false;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                tool = new ConnectorTool(mapCollection.CurrentMap,this);
                listView4.Visible = true;
                button3.Visible = true;
            }
            else
            {
                listView4.Visible = false;
                button3.Visible = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                tool = new SpriteTool(mapCollection.CurrentMap,this);
                listView2.Visible = true;
                listView3.Visible = true;
                button2.Visible = true;
            }
            else
            {
                listView2.Visible = false;
                listView3.Visible = false;
                button2.Visible = false;
            }
        }
        //EndTools

        //Tile Tool Selection Pool Changed index
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
                tool.SetBrush(int.Parse(listView1.SelectedItems[0].SubItems[1].Text));
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapCollection.CurrentMap.ShowOutOfBounds = true;
            pictureBox1.Invalidate();
        }
        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapCollection.CurrentMap.ShowOutOfBounds = false;
            pictureBox1.Invalidate();
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            NewMapForm form = new NewMapForm(mapCollection.FilePath, mapCollection.GetNames());
            form.Owner = this;
            form.callback += Form_callback;
            form.Show();
            this.Enabled = false;
        }

        private void Form_callback(NewMapForm form)
        {
            if (form.Valid)
            {
                Map newMap = form.Output;
                AddMapToOpenWindows(newMap);
                mapCollection.AddMap(newMap);
            }

            form.CloseForm();
            this.Enabled = true;
            this.Focus();
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapCollection.drawBackground = true;
            pictureBox1.Invalidate();
        }

        private void hideToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapCollection.drawBackground = false;
            pictureBox1.Invalidate();
        }

        private void showToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            mapCollection.drawSprites = true;
            pictureBox1.Invalidate();
        }

        private void hideToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            mapCollection.drawSprites = false;
            pictureBox1.Invalidate();
        }

        private void showToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            mapCollection.drawConnections = true;
            pictureBox1.Invalidate();
        }

        private void hideToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            mapCollection.drawConnections = false;
            pictureBox1.Invalidate();
        }

        private void showToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            mapCollection.drawPlayer = true;
            pictureBox1.Invalidate();
        }

        private void hideToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            mapCollection.drawPlayer = false;
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                int ID = int.Parse(listView3.SelectedItems[0].SubItems[1].Text);
                int X = int.Parse(listView3.SelectedItems[0].SubItems[2].Text);
                int Y = int.Parse(listView3.SelectedItems[0].SubItems[3].Text);
                mapCollection?.CurrentMap.RemoveSprite(new Point(X, Y), ID);
                listView3.Items.Remove(listView3.SelectedItems[0]);
                pictureBox1.Invalidate();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mapCollection.FileName))
            {
                saveFileDialog1.InitialDirectory = mapCollection.FilePath;
                saveFileDialog1.Filter = "C++ Header|*.h";
                saveFileDialog1.DefaultExt = ".h";
                saveFileDialog1.FileName = "Map.h";
                DialogResult result = saveFileDialog1.ShowDialog();
                if(result == DialogResult.OK)
                {
                    mapCollection.FileName = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                    mapCollection.FilePath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                    mapCollection.SaveMaps();
                }
            }
            else
            {
                mapCollection.SaveMaps();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                int X = int.Parse(listView4.SelectedItems[0].SubItems[1].Text);
                int Y = int.Parse(listView4.SelectedItems[0].SubItems[2].Text);
                int X1 = int.Parse(listView4.SelectedItems[0].SubItems[3].Text);
                int Y1 = int.Parse(listView4.SelectedItems[0].SubItems[4].Text);

                mapCollection?.CurrentMap.RemoveConnection(new Point(X, Y), new Point(X1, Y1));
                listView4.Items.Remove(listView4.SelectedItems[0]);
                pictureBox1.Invalidate();
            }
        }

        private void deleteMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapCollection.RemoveMap(mapCollection.CurrentMap);
            if (mapCollection.OpenCount > 0)
                return;

            Owner.Show();
            this.Close();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                tool.SetBrush(int.Parse(listView2.SelectedItems[0].SubItems[1].Text));
            }
        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
