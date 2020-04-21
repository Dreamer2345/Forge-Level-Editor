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
        const String keepOpen = "KeepOpen";
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

        public MapEditorForm() {
            mapCollection = new MapCollection();
            Map map = new Map(new BaseMapComponent(-1), "Map", "", 15, 15, 250);
            mapCollection.AddMap(map);
            cursor = new TileCursor();
            AddTextures();
            AddTiles();
            AddSprites();
            InitializeComponent();

            mapsMenu.DropDown.ItemClicked += (obj, args) =>
            {
                if (args.ClickedItem.Tag is string tag)
                    mapsMenu.DropDown.AutoClose = (tag != keepOpen);
                else
                    mapsMenu.DropDown.AutoClose = true;
            };

            foreach(var toolStrip in mapsMenu.DropDownItems.OfType<ToolStripMenuItem>().Where(x => (x.Tag is string tag) && (tag == keepOpen)))
                toolStrip.CheckedChanged +=
                    (obj, args) => mapsMenu.DropDown.AutoClose = true;

            mapsMenu.DropDown.MouseLeave += new System.EventHandler(this.mapsMenu_DropDown_MouseLeave);

        }
        public MapEditorForm(Map EditingMap)
        {
            mapCollection = new MapCollection();
            mapCollection.FilePath = EditingMap.Filepath;
            mapCollection.AddMap(EditingMap);
            currentFileLabel.Text = EditingMap.Filepath;
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
            spritesPlacedListView.Items.Clear();
            SpriteManager sm = new SpriteManager();
            foreach (SpriteComponent i in mapCollection.CurrentMap.Sprites)
            {
                Sprite sprite = sm.GetSprite(i.Type);
                ListViewItem newItem = new ListViewItem();
                newItem.SubItems.Add(i.Type.ToString());
                newItem.SubItems.Add(i.SpritePosition.X.ToString());
                newItem.SubItems.Add(i.SpritePosition.Y.ToString());
                newItem.SubItems.Add(i.Health.ToString());
                newItem.ImageKey = sprite.TextureID;
                spritesPlacedListView.Items.Add(newItem);
            }
        }
        void UpdateCurrentConnectors()
        {
            ConnectionListView.Items.Clear();
            foreach (EnviromentAffectComponent i in mapCollection.CurrentMap.Connectors)
            {
                EnviromentAffectComponent env = i;
                ListViewItem newItem = new ListViewItem(env.IsValid.ToString());
                newItem.SubItems.Add(env.Start.X.ToString());
                newItem.SubItems.Add(env.Start.Y.ToString());
                newItem.SubItems.Add(env.End.X.ToString());
                newItem.SubItems.Add(env.End.Y.ToString());
                ConnectionListView.Items.Add(newItem);
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

            tilesListView.SmallImageList = imageList;

            foreach (Tuple<int, Tile> i in Tiles)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.SubItems.Add(i.Item1.ToString());
                newItem.SubItems.Add(i.Item2.Name);
                newItem.SubItems.Add(i.Item2.IsExit.ToString());
                newItem.SubItems.Add(i.Item2.IsSender.ToString());
                newItem.SubItems.Add(i.Item2.IsReciver.ToString());
                newItem.ImageKey = i.Item2.TextureID;
                tilesListView.Items.Add(newItem);
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

            spritesListView.SmallImageList = imageList;
            spritesPlacedListView.SmallImageList = imageList;
            foreach (Tuple<int, Sprite> i in Tiles)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.SubItems.Add(i.Item1.ToString());
                newItem.SubItems.Add(i.Item2.Name);
                newItem.SubItems.Add(i.Item2.Health.ToString());
                newItem.ImageKey = i.Item2.TextureID;
                spritesListView.Items.Add(newItem);
            }
        }
        void AddMapToOpenWindows(Map map, Boolean selectMenuItem)
        {
            if (map == null) return;
            map.CentreMap();

            ToolStripMenuItem newMenuItem = new ToolStripMenuItem(map.Name);
            newMenuItem.Click += NewMenuButton_Click;
            newMenuItem.Tag = map;
            newMenuItem.Name = map.Name;
            mapsMenu.DropDownItems.Add(newMenuItem);

            if (selectMenuItem) {

                tickMapMenuItem(map.Name);
                enableMapMenuOptions(map.Name);

            }

        }
        private void NewMenuButton_Click(object sender, EventArgs e)
        {  
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            Map chosenMap = (Map)menu.Tag;

            if (mapCollection.ChangeMap(chosenMap)) {

                tickMapMenuItem(chosenMap.Name);
                enableMapMenuOptions(chosenMap.Name);

                tool.MapToEdit = chosenMap;
                UpdateCurrentSprites();
                UpdateCurrentConnectors();
                pictureBox1.Invalidate();
            }

        }

        private void MapEditorForm_Load(object sender, EventArgs e)
        {
            //this.FormClosing += MapEditorForm_FormClosing;
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


            if (mapCollection.OpenCount > 0) {

                for (int i = 0; i < mapCollection.GetMaps().Count(); i++) {
                    Map map = mapCollection.GetMaps()[i];
                    AddMapToOpenWindows(map, i == 0);
                }

                mapsMenu.DropDownItems[mapCollection.CurrentMap.Name].Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapMoveUpMenu.Image = RogueboyLevelEditor.Properties.Resources.ArrowUp;
                mapMoveDownMenu.Image = RogueboyLevelEditor.Properties.Resources.ArrowDown;
                mapMoveDownMenu.Enabled = mapCollection.OpenCount > 1;
                currentMapLabel.Text = mapCollection.GetMaps()[0].Name;

            }

            tilesListView.Items.Clear();
            spritesListView.Items.Clear();
            AddTilesToListView();
            AddSpritesToListView();

            viewOutOfBoundsMenu.Image = RogueboyLevelEditor.Properties.Resources.Tick;
            viewTileMenu.Image = RogueboyLevelEditor.Properties.Resources.Tick;
            viewSpritesMenu.Image = RogueboyLevelEditor.Properties.Resources.Tick;
            viewConnectionsMenu.Image = RogueboyLevelEditor.Properties.Resources.Tick; 
            viewPlayerStartMenu.Image = RogueboyLevelEditor.Properties.Resources.Tick;

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
                if (tilesListView.SelectedItems.Count > 0)
                    TileId = int.Parse(tilesListView.SelectedItems[0].SubItems[1].Text);
                tool = new TileBrush(TileId, mapCollection.CurrentMap);
                tilesListView.Visible = true;
            }
            else
            {
                tilesListView.Visible = false;
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

        private void centreMap_Click(object sender, EventArgs e)
        {
            mapCollection.CurrentMap.CentreMap();
            pictureBox1.Invalidate();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                int TileId = -1;
                if (tilesListView.SelectedItems.Count > 0)
                    TileId = int.Parse(tilesListView.SelectedItems[0].SubItems[1].Text);
                tool = new TileRectangle(this,TileId, mapCollection.CurrentMap, pictureBox1.Width / 2, pictureBox1.Height / 2);
                tilesListView.Visible = true;
            }
            else
            {
                tilesListView.Visible = false;
            }
            
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            if (radioButton7.Checked)
            {
                tool = new SurroundTool(mapCollection.CurrentMap,this);
                mapCollection.CurrentMap.ShowOutOfBounds = true;
                tilesListView.Visible = true;
            }
            else
            {
                mapCollection.CurrentMap.ShowOutOfBounds = false;
                tilesListView.Visible = false;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                tool = new ConnectorTool(mapCollection.CurrentMap,this);
                ConnectionListView.Visible = true;
                button3.Visible = true;
            }
            else
            {
                ConnectionListView.Visible = false;
                button3.Visible = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                tool = new SpriteTool(mapCollection.CurrentMap,this);
                spritesListView.Visible = true;
                spritesPlacedListView.Visible = true;
                button2.Visible = true;

                if (spritesListView.SelectedItems.Count > 0) {
                    tool.SetBrush(int.Parse(spritesListView.SelectedItems[0].SubItems[1].Text), int.Parse(spritesListView.SelectedItems[0].SubItems[3].Text));
                }

            }
            else
            {
                spritesListView.Visible = false;
                spritesPlacedListView.Visible = false;
                button2.Visible = false;
            }
        }
        //EndTools

        //Tile Tool Selection Pool Changed index
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tilesListView.SelectedItems.Count > 0)
                tool.SetBrush(int.Parse(tilesListView.SelectedItems[0].SubItems[1].Text));
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //errorProvider1.Clear();
            openFileDialog.FileName = "Maps.h";
            openFileDialog.InitialDirectory = "/Maps";

            DialogResult diag = openFileDialog.ShowDialog();

            if (diag == DialogResult.OK) {

                if (openFileDialog.CheckFileExists) {

                    mapCollection = new MapCollection();
                    mapCollection.FileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                    mapCollection.FilePath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                    mapCollection.AddMaps(MapCollection.LoadMaps(openFileDialog.FileName));
                    currentFileLabel.Text = openFileDialog.FileName;

                    mapCollection.drawOffsetX = (pictureBox1.Width / 2) - 8;
                    mapCollection.drawOffsetY = (pictureBox1.Height / 2) - 8;
                    mapCollection.viewWidth = (int)Math.Ceiling(pictureBox1.Width / 16d);
                    mapCollection.viewHeight = (int)Math.Ceiling(pictureBox1.Height / 16d);
                    cursor.drawOffsetX = (pictureBox1.Width / 2) - 8;
                    cursor.drawOffsetY = (pictureBox1.Height / 2) - 8;
                    tool = new TileBrush(-1, mapCollection.CurrentMap);


                    if (mapCollection.OpenCount == 0) {
                        MessageBox.Show("Error parsing map file.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mapCollection = new MapCollection();
                        return;
                    }


                    // Remove any existing menu items ..

                    for (int i = 6; i < mapsMenu.DropDownItems.Count; i++) {

                        mapsMenu.DropDownItems.RemoveAt(i);

                    }


                    // Load new maps into menu ..

                    if (mapCollection.OpenCount > 0) {

                        for (int i = 0; i < mapCollection.GetMaps().Count(); i++) {
                            Map map = mapCollection.GetMaps()[i];
                            AddMapToOpenWindows(map, i == 0);
                        }

                    }

                    mapMoveUpMenu.Image = RogueboyLevelEditor.Properties.Resources.ArrowUp;
                    mapMoveDownMenu.Image = RogueboyLevelEditor.Properties.Resources.ArrowDown;

                    tickMapMenuItem(mapCollection.CurrentMap.Name);
                    enableMapMenuOptions(mapCollection.CurrentMap.Name);

                    UpdateCurrentSprites();
                    pictureBox1.Invalidate();
                    pictureBox1.Refresh();

                }

            }

        }


        private void fileExistMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            NewMapForm form = new NewMapForm(mapCollection, null, mapCollection.FilePath);
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

                // Was this an existing map or a new one?

                if (mapCollection.GetMaps().Contains(newMap)) {

                    // Existing? Locate existing ticked map and change the name ..

                    for (int x = 6; x < mapsMenu.DropDownItems.Count; x++) {

                        ToolStripMenuItem menuItem = (ToolStripMenuItem)mapsMenu.DropDownItems[x];
                        if (menuItem.Image != null) {
                            menuItem.Name = newMap.Name;
                            menuItem.Text = newMap.Name;
                            break;

                        }

                    }

                }
                else {

                    // New?  Add the entry to the collection and menu ..

                    AddMapToOpenWindows(newMap, true);
                    mapCollection.AddMap(newMap);
                    newMap.CentreMap();

                }

                tickMapMenuItem(newMap.Name);
                enableMapMenuOptions(newMap.Name);

                tool.MapToEdit = newMap;
                mapCollection.CurrentMap = newMap;
                UpdateCurrentSprites();
                UpdateCurrentConnectors();
                pictureBox1.Invalidate();
                pictureBox1.Refresh();
                
            }

            form.CloseForm();
            this.Enabled = true;
            this.Focus();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (spritesPlacedListView.SelectedItems.Count > 0)
            {
                int ID = int.Parse(spritesPlacedListView.SelectedItems[0].SubItems[1].Text);
                int X = int.Parse(spritesPlacedListView.SelectedItems[0].SubItems[2].Text);
                int Y = int.Parse(spritesPlacedListView.SelectedItems[0].SubItems[3].Text);
                mapCollection?.CurrentMap.RemoveSprite(new Point(X, Y), ID);
                spritesPlacedListView.Items.Remove(spritesPlacedListView.SelectedItems[0]);
                pictureBox1.Invalidate();
            }
        }

        private void fileSaveMenu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mapCollection.FileName))
            {
                saveFileDialog1.InitialDirectory = mapCollection.FilePath;
                saveFileDialog1.FileName = "Maps.h";
                DialogResult result = saveFileDialog1.ShowDialog();
                if(result == DialogResult.OK)
                {
                    mapCollection.FileName = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                    mapCollection.FilePath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                    currentFileLabel.Text = saveFileDialog1.FileName;
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
            if (ConnectionListView.SelectedItems.Count > 0)
            {
                int X = int.Parse(ConnectionListView.SelectedItems[0].SubItems[1].Text);
                int Y = int.Parse(ConnectionListView.SelectedItems[0].SubItems[2].Text);
                int X1 = int.Parse(ConnectionListView.SelectedItems[0].SubItems[3].Text);
                int Y1 = int.Parse(ConnectionListView.SelectedItems[0].SubItems[4].Text);

                mapCollection?.CurrentMap.RemoveConnection(new Point(X, Y), new Point(X1, Y1));
                ConnectionListView.Items.Remove(ConnectionListView.SelectedItems[0]);
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

        private void spritesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (spritesListView.SelectedItems.Count > 0)
            {
                tool.SetBrush(int.Parse(spritesListView.SelectedItems[0].SubItems[1].Text), int.Parse(spritesListView.SelectedItems[0].SubItems[3].Text));
            }
        }

        private void mapAddMenu_Click(object sender, EventArgs e) {

            NewMapForm form = new NewMapForm(mapCollection, null, mapCollection.FilePath);
            form.Owner = this;
            form.callback += Form_callback;
            form.Show();
            this.Enabled = false;

        }

        private void mapDeleteMenu_Click(object sender, EventArgs e) {

            if (mapCollection.OpenCount == 1) {
                MessageBox.Show("You cannot delete the last map.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            mapsMenu.DropDownItems.RemoveByKey(mapCollection.CurrentMap.Name);
            mapCollection.RemoveMap(mapCollection.CurrentMap);

            if (mapCollection.OpenCount > 0) {

                ToolStripMenuItem menuItem = (ToolStripMenuItem)mapsMenu.DropDownItems[mapCollection.CurrentMap.Name];
                tickMapMenuItem(mapCollection.CurrentMap.Name);
                enableMapMenuOptions(mapCollection.CurrentMap.Name);

                tool.MapToEdit = (Map)menuItem.Tag;
                UpdateCurrentSprites();
                UpdateCurrentConnectors();
                pictureBox1.Invalidate();
                return;

            }

            this.Close();

        }

        private void mapMoveUpMenu_Click(object sender, EventArgs e) {

            ToolStripMenuItem menu = (ToolStripMenuItem)mapsMenu.DropDownItems[mapCollection.CurrentMap.Name];
            int menuIndex = mapsMenu.DropDownItems.IndexOfKey(mapCollection.CurrentMap.Name);
            mapsMenu.DropDownItems.RemoveByKey(menu.Name);
            mapsMenu.DropDownItems.Insert(menuIndex - 1, menu);
            mapCollection.MoveCurrentMapUp();

            enableMapMenuOptions(menu.Name);

        }

        private void mapMoveDownMenu_Click(object sender, EventArgs e) {

            ToolStripMenuItem menu = (ToolStripMenuItem)mapsMenu.DropDownItems[mapCollection.CurrentMap.Name];
            int menuIndex = mapsMenu.DropDownItems.IndexOfKey(mapCollection.CurrentMap.Name);
            mapsMenu.DropDownItems.RemoveByKey(menu.Name);
            mapsMenu.DropDownItems.Insert(menuIndex + 1, menu);
            mapCollection.MoveCurrentMapDown();

            enableMapMenuOptions(menu.Name);

        }

        private void tickMapMenuItem(String mapName) {


            // Remove other tick marks from menu items ..

            for (int x = 6; x < mapsMenu.DropDownItems.Count; x++) {
                ToolStripMenuItem otherMenuItem = (ToolStripMenuItem)mapsMenu.DropDownItems[x];
                otherMenuItem.ImageKey = null;
            }


            // Tick the new map and reload ..

            ToolStripMenuItem menuItem = (ToolStripMenuItem)mapsMenu.DropDownItems[mapName];
            menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;

        }

        private void enableMapMenuOptions(String mapName) {

            mapMoveUpMenu.Enabled = (mapsMenu.DropDownItems.IndexOfKey(mapName) != 6);
            mapMoveDownMenu.Enabled = (mapsMenu.DropDownItems.IndexOfKey(mapName) != mapsMenu.DropDownItems.Count - 1);
            currentMapLabel.Text = mapName;

        }

        private void fileSaveAsMenu_Click(object sender, EventArgs e) {

            saveFileDialog1.InitialDirectory = mapCollection.FilePath;
            saveFileDialog1.FileName = (string.IsNullOrWhiteSpace(mapCollection.FileName) ? "Maps.h" : mapCollection.FileName);

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK) {
                mapCollection.FileName = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                mapCollection.FilePath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                mapCollection.SaveMaps();
                currentFileLabel.Text = saveFileDialog1.FileName;
            }

        }

        private void mapPropertysToolStripMenuItem_Click(object sender, EventArgs e) {

            NewMapForm form = new NewMapForm(mapCollection, mapCollection.CurrentMap, mapCollection.FilePath);
            form.Owner = this;
            form.callback += Form_callback;
            form.Show();
            this.Enabled = false;

        }

        private void viewTileMenu_Click(object sender, EventArgs e) {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null) {

                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawBackground = true;
                pictureBox1.Invalidate();

            }
            else {

                menuItem.Image = null;
                mapCollection.drawBackground = false;
                pictureBox1.Invalidate();

            }

        }

        private void viewSpritesMenu_Click(object sender, EventArgs e) {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null) {

                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawSprites = true;
                pictureBox1.Invalidate();

            }
            else {

                menuItem.Image = null;
                mapCollection.drawSprites = false;
                pictureBox1.Invalidate();

            }

        }

        private void viewConnectionsMenu_Click(object sender, EventArgs e) {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null) {

                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawConnections = true;
                pictureBox1.Invalidate();

            }
            else {

                menuItem.Image = null;
                mapCollection.drawConnections = false;
                pictureBox1.Invalidate();

            }

        }

        private void viewPlayerStartMenu_Click(object sender, EventArgs e) {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null) {

                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawPlayer = true;
                pictureBox1.Invalidate();

            }
            else {

                menuItem.Image = null;
                mapCollection.drawPlayer = false;
                pictureBox1.Invalidate();

            }

        }

        private void viewOutOfBoundsMenu_Click(object sender, EventArgs e) {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null) {

                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.CurrentMap.ShowOutOfBounds = true;
                pictureBox1.Invalidate();

            }
            else {

                menuItem.Image = null;
                mapCollection.CurrentMap.ShowOutOfBounds = false;
                pictureBox1.Invalidate();

            }

        }

        private void playerStartButton_CheckedChanged(object sender, EventArgs e) {
            if (playerStartButton.Checked) {
                tool = new PlayerPositionTool(mapCollection.CurrentMap);
            }
        }

        private void mapsMenu_DropDown_MouseLeave(object sender, EventArgs e) {
            mapsMenu.DropDown.Close();

        }

    }

}
