﻿using RogueboyLevelEditor.map;
using RogueboyLevelEditor.map.Component;
using RogueboyLevelEditor.map.Tools;
using RogueboyLevelEditor.mapCollection;
using RogueboyLevelEditor.TextureHandler;
using RogueboyLevelEditor.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static RogueboyLevelEditor.TextureHandler.TextureManager;

namespace RogueboyLevelEditor.Forms
{
    public partial class MapEditorForm : Form
    {
        const String keepOpen = "KeepOpen";
        const int spacing = 6;

        MapCollection mapCollection;
        TileManager tileManager = new TileManager();
        TileCursor cursor = new TileCursor();
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

        public MapEditorForm()
        {
            AddTextures();
            AddTiles();
            AddSprites();
            InitializeComponent();

            this.mapEditorControl.Tool = new TileTool();
            this.mapCollection = this.mapEditorControl.MapCollection;
            this.mapCollection.AddMap(new Map(new BaseMapComponent(-1), "Map", "", 15, 15, 250));

            mapsMenu.DropDown.ItemClicked += (obj, args) =>
            {
                if (args.ClickedItem.Tag is string tag)
                    mapsMenu.DropDown.AutoClose = (tag != keepOpen);
                else
                    mapsMenu.DropDown.AutoClose = true;
            };

            foreach (var toolStrip in mapsMenu.DropDownItems.OfType<ToolStripMenuItem>().Where(x => (x.Tag is string tag) && (tag == keepOpen)))
                toolStrip.CheckedChanged +=
                    (obj, args) => mapsMenu.DropDown.AutoClose = true;

            mapsMenu.DropDown.MouseLeave += new System.EventHandler(this.mapsMenu_DropDown_MouseLeave);
            HealthNumericUpDown.Visible = false;
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
                newItem.SubItems.Add(i.Health == 0 ? "" : i.Health.ToString());
                newItem.SubItems.Add(sprite.Name);
                newItem.ImageKey = sprite.TextureID;
                spritesPlacedListView.Items.Add(newItem);
            }
        }

        void UpdateCurrentConnectors()
        {
            connectionListView.Items.Clear();
            foreach (EnviromentAffectComponent i in mapCollection.CurrentMap.Connectors)
            {
                EnviromentAffectComponent env = i;
                ListViewItem newItem = new ListViewItem(env.IsValid.ToString());
                newItem.SubItems.Add(env.Start.X.ToString());
                newItem.SubItems.Add(env.Start.Y.ToString());
                newItem.SubItems.Add(env.End.X.ToString());
                newItem.SubItems.Add(env.End.Y.ToString());
                connectionListView.Items.Add(newItem);
            }
        }

        void AddTilesToListView()
        {

            TextureManager textureManager = new TextureManager();
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
                newItem.SubItems.Add(i.Item2.Health == 0 ? "" : i.Item2.Health.ToString());
                newItem.ImageKey = i.Item2.TextureID;
                spritesListView.Items.Add(newItem);
            }
        }
        void AddMapToOpenWindows(Map map, Boolean selectMenuItem)
        {
            if (map == null) return;
            map.CentreMap();

            ToolStripMenuItem newMenuItem = new ToolStripMenuItem(map.Name);
            newMenuItem.Click += changeMap_Click;
            newMenuItem.Tag = map;
            newMenuItem.Name = map.Name;
            mapsMenu.DropDownItems.Add(newMenuItem);

            if (selectMenuItem)
            {

                tickMapMenuItem(map.Name);
                enableMapMenuOptions(map.Name);

            }

        }
        private void changeMap_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            Map chosenMap = (Map)menu.Tag;

            if (mapCollection.ChangeMap(chosenMap))
            {

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

            if (mapCollection.OpenCount > 0)
            {

                for (int i = 0; i < mapCollection.GetMaps().Count(); i++)
                {
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

            if (tool != null && e.Button == MouseButtons.Left)
            {

                tool.MouseDown = true;
                if (tool.Update())
                    pictureBox1.Invalidate();


                // Add the selected item to the context menu ..

                if (tool is TileBrush && tilesListView.SelectedItems.Count > 0)
                {

                    int tileId = Int32.Parse(tilesListView.SelectedItems[0].SubItems[1].Text);
                    String tileName = tilesListView.SelectedItems[0].SubItems[2].Text;
                    addTileToMenu(tileId, tileName);

                }

                if (tool is SpriteTool && spritesListView.SelectedItems.Count > 0)
                {

                    String spriteName = spritesListView.SelectedItems[0].SubItems[2].Text;

                    for (int i = 3; i < spriteContextMenu.Items.Count; i++)
                    {

                        ToolStripMenuItem menuItem = (ToolStripMenuItem)spriteContextMenu.Items[i];

                        if (menuItem.Text == spriteName)
                        {

                            spriteContextMenu.Items.Remove(menuItem);
                            break;

                        }

                    }


                    ToolStripMenuItem newMenuItem = new ToolStripMenuItem();
                    newMenuItem.Text = spriteName;
                    newMenuItem.Image = spritesListView.SmallImageList.Images[spritesListView.SelectedItems[0].ImageKey];
                    newMenuItem.Tag = spritesListView.SelectedItems[0].Index;
                    newMenuItem.Click += new System.EventHandler(spritesContextMenu_Item_Click);
                    spriteContextMenu.Items.Insert(3, newMenuItem);

                    if (spriteContextMenu.Items.Count > 11) { spriteContextMenu.Items.RemoveAt(10); }

                }

            }

            if (tool is TileBrush && e.Button == MouseButtons.Right)
            {

                cursor.position = mapCollection.CurrentMap.ToTileSpace(e.Location);
                tilesContextMenu_EnableOptions();
                tilesContextMenu.Show(Cursor.Position);

                tilesContextMenu_Column.Enabled = true;
                tilesContextMenu_ColumnInsert.Enabled = (mapCollection.CurrentMap.Width < 40);
                tilesContextMenu_ColumnDelete.Enabled = (mapCollection.CurrentMap.Width > 1);
                tilesContextMenu_Row.Enabled = true;
                tilesContextMenu_RowInsert.Enabled = (mapCollection.CurrentMap.Height < 40);
                tilesContextMenu_RowDelete.Enabled = (mapCollection.CurrentMap.Height > 1);

            }

            if (tool is SpriteTool && e.Button == MouseButtons.Right)
            {

                cursor.position = mapCollection.CurrentMap.ToTileSpace(e.Location);
                spriteContextMenu_EnableOptions();
                spriteContextMenu.Show(Cursor.Position);

            }

            if (tool is ConnectorTool && e.Button == MouseButtons.Right)
            {

                cursor.position = mapCollection.CurrentMap.ToTileSpace(e.Location);
                connectionContextMenu_EnableOptions();
                connectionContextMenu.Show(Cursor.Position);

            }

        }
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            HealthNumericUpDown.Visible = false;
            cursor.position = mapCollection.CurrentMap.ToTileSpace(e.Location);
            if (tool != null)
            {
                tool.Position = cursor.position;
                if (tool.Update())
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
            cursor.Draw(g, mapCollection.CurrentMap);
            toolStatusLabel.Text = $"X:{ cursor.position.X} Y: { cursor.position.Y}, ID : {mapCollection.CurrentMap.GetTile(cursor.position).tileID}, Tile :{tileManager.GetTile(mapCollection.CurrentMap.GetTile(cursor.position).tileID).Name}";
            tool?.Draw(g);
            ControlPaint.DrawBorder(g, pictureBox1.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        //Tools
        private void tileToolRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.mapEditorControl.Tool = new TileTool();

            showTileTools();
        }

        private void connectionToolRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            showConnectionTool();
        }

        private void spriteToolRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            showSpritesTool();
        }
        //EndTools

        //Tile Tool Selection Pool Changed index
        private void tilesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tilesListView.SelectedItems.Count > 0)
            {
                this.mapEditorControl.SelectedTileId = int.Parse(tilesListView.SelectedItems[0].SubItems[1].Text);

                tool.SetBrush(int.Parse(tilesListView.SelectedItems[0].SubItems[1].Text));
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog.FileName = "Maps.h";
            openFileDialog.InitialDirectory = "/Maps";

            DialogResult diag = openFileDialog.ShowDialog();

            if (diag == DialogResult.OK)
            {

                if (openFileDialog.CheckFileExists)
                {

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


                    if (mapCollection.OpenCount == 0)
                    {
                        MessageBox.Show("Error parsing map file.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mapCollection = new MapCollection();
                        return;
                    }


                    // Remove any existing menu items ..

                    while (mapsMenu.DropDownItems.Count > 6)
                    {

                        mapsMenu.DropDownItems.RemoveAt(6);

                    }


                    // Load new maps into menu ..

                    if (mapCollection.OpenCount > 0)
                    {

                        for (int i = 0; i < mapCollection.GetMaps().Count(); i++)
                        {
                            Map map = mapCollection.GetMaps()[i];
                            AddMapToOpenWindows(map, i == 0);
                        }

                    }

                    mapMoveUpMenu.Image = RogueboyLevelEditor.Properties.Resources.ArrowUp;
                    mapMoveDownMenu.Image = RogueboyLevelEditor.Properties.Resources.ArrowDown;

                    tickMapMenuItem(mapCollection.CurrentMap.Name);
                    enableMapMenuOptions(mapCollection.CurrentMap.Name);

                    UpdateCurrentSprites();
                    UpdateCurrentConnectors();
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

                if (mapCollection.GetMaps().Contains(newMap))
                {

                    // Existing? Locate existing ticked map and change the name ..

                    for (int x = 6; x < mapsMenu.DropDownItems.Count; x++)
                    {

                        ToolStripMenuItem menuItem = (ToolStripMenuItem)mapsMenu.DropDownItems[x];
                        if (menuItem.Image != null)
                        {
                            menuItem.Name = newMap.Name;
                            menuItem.Text = newMap.Name;
                            break;

                        }

                    }

                }
                else
                {

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

        private void removeSprite_Click(object sender, EventArgs e)
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
                if (result == DialogResult.OK)
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

        private void removeConnection_Click(object sender, EventArgs e)
        {
            if (connectionListView.SelectedItems.Count > 0)
            {
                int X = int.Parse(connectionListView.SelectedItems[0].SubItems[1].Text);
                int Y = int.Parse(connectionListView.SelectedItems[0].SubItems[2].Text);
                int X1 = int.Parse(connectionListView.SelectedItems[0].SubItems[3].Text);
                int Y1 = int.Parse(connectionListView.SelectedItems[0].SubItems[4].Text);

                mapCollection?.CurrentMap.RemoveConnection(new Point(X, Y), new Point(X1, Y1));
                connectionListView.Items.Remove(connectionListView.SelectedItems[0]);
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
                this.mapEditorControl.SelectedSpriteId = int.Parse(spritesListView.SelectedItems[0].SubItems[1].Text);

                tool.SetBrush(int.Parse(spritesListView.SelectedItems[0].SubItems[1].Text), (spritesListView.SelectedItems[0].SubItems[3].Text == "" ? 0 : int.Parse(spritesListView.SelectedItems[0].SubItems[3].Text)));
            }
        }

        private void mapAddMenu_Click(object sender, EventArgs e)
        {

            NewMapForm form = new NewMapForm(mapCollection, null, mapCollection.FilePath);
            form.Owner = this;
            form.callback += Form_callback;
            form.Show();
            this.Enabled = false;

        }

        private void mapDeleteMenu_Click(object sender, EventArgs e)
        {

            if (mapCollection.OpenCount == 1)
            {
                MessageBox.Show("You cannot delete the last map.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            mapsMenu.DropDownItems.RemoveByKey(mapCollection.CurrentMap.Name);
            mapCollection.RemoveMap(mapCollection.CurrentMap);

            if (mapCollection.OpenCount > 0)
            {

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

        private void mapMoveUpMenu_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menu = (ToolStripMenuItem)mapsMenu.DropDownItems[mapCollection.CurrentMap.Name];
            int menuIndex = mapsMenu.DropDownItems.IndexOfKey(mapCollection.CurrentMap.Name);
            mapsMenu.DropDownItems.RemoveByKey(menu.Name);
            mapsMenu.DropDownItems.Insert(menuIndex - 1, menu);
            mapCollection.MoveCurrentMapUp();

            enableMapMenuOptions(menu.Name);

        }

        private void mapMoveDownMenu_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menu = (ToolStripMenuItem)mapsMenu.DropDownItems[mapCollection.CurrentMap.Name];
            int menuIndex = mapsMenu.DropDownItems.IndexOfKey(mapCollection.CurrentMap.Name);
            mapsMenu.DropDownItems.RemoveByKey(menu.Name);
            mapsMenu.DropDownItems.Insert(menuIndex + 1, menu);
            mapCollection.MoveCurrentMapDown();

            enableMapMenuOptions(menu.Name);

        }

        private void tickMapMenuItem(String mapName)
        {


            // Remove other tick marks from menu items ..

            for (int x = 6; x < mapsMenu.DropDownItems.Count; x++)
            {
                ToolStripMenuItem otherMenuItem = (ToolStripMenuItem)mapsMenu.DropDownItems[x];
                otherMenuItem.ImageKey = null;
            }


            // Tick the new map and reload ..

            ToolStripMenuItem menuItem = (ToolStripMenuItem)mapsMenu.DropDownItems[mapName];
            menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;

        }

        private void enableMapMenuOptions(String mapName)
        {

            mapMoveUpMenu.Enabled = (mapsMenu.DropDownItems.IndexOfKey(mapName) != 6);
            mapMoveDownMenu.Enabled = (mapsMenu.DropDownItems.IndexOfKey(mapName) != mapsMenu.DropDownItems.Count - 1);
            currentMapLabel.Text = mapName;

        }

        private void fileSaveAsMenu_Click(object sender, EventArgs e)
        {

            saveFileDialog1.InitialDirectory = mapCollection.FilePath;
            saveFileDialog1.FileName = (string.IsNullOrWhiteSpace(mapCollection.FileName) ? "Maps.h" : mapCollection.FileName);

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                mapCollection.FileName = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                mapCollection.FilePath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                mapCollection.SaveMaps();
                currentFileLabel.Text = saveFileDialog1.FileName;
            }

        }

        private void mapPropertysToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NewMapForm form = new NewMapForm(mapCollection, mapCollection.CurrentMap, mapCollection.FilePath);
            form.Owner = this;
            form.callback += Form_callback;
            form.Show();
            this.Enabled = false;

        }

        private void viewTileMenu_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null)
            {

                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawBackground = true;
                pictureBox1.Invalidate();

            }
            else
            {

                menuItem.Image = null;
                mapCollection.drawBackground = false;
                pictureBox1.Invalidate();

            }

        }

        private void viewSpritesMenu_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null)
            {

                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawSprites = true;
                pictureBox1.Invalidate();

            }
            else
            {

                menuItem.Image = null;
                mapCollection.drawSprites = false;
                pictureBox1.Invalidate();

            }

        }

        private void viewConnectionsMenu_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null)
            {

                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawConnections = true;
                pictureBox1.Invalidate();

            }
            else
            {

                menuItem.Image = null;
                mapCollection.drawConnections = false;
                pictureBox1.Invalidate();

            }

        }

        private void viewPlayerStartMenu_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null)
            {

                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawPlayer = true;
                pictureBox1.Invalidate();

            }
            else
            {

                menuItem.Image = null;
                mapCollection.drawPlayer = false;
                pictureBox1.Invalidate();

            }

        }

        private void viewOutOfBoundsMenu_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null)
            {

                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.CurrentMap.ShowOutOfBounds = true;
                pictureBox1.Invalidate();

            }
            else
            {

                menuItem.Image = null;
                mapCollection.CurrentMap.ShowOutOfBounds = false;
                pictureBox1.Invalidate();

            }

        }



        private void mapsMenu_DropDown_MouseLeave(object sender, EventArgs e)
        {
            mapsMenu.DropDown.Close();
        }

        private void spritesPlacedListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (spritesPlacedListView.SelectedItems.Count == 0)
                this.HealthNumericUpDown.Visible = false;

            var selectedItem = e.Item;
            var point = new Point()
            {
                X = int.Parse(selectedItem.SubItems[3].Text),
                Y = int.Parse(selectedItem.SubItems[4].Text),
            };

            this.cursor.position = point;
            this.pictureBox1.Invalidate();

            this.mapEditorControl.TileCursor = this.mapEditorControl.CurrentMap.ToScreenSpace(point);
        }

        private void connectionListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            ListViewItem selectedItem = e.Item;

            foreach (EnviromentAffectComponent connection in mapCollection.CurrentMap.Connectors)
            {

                if (connection.Start.X == Int32.Parse(selectedItem.SubItems[1].Text) &&
                    connection.Start.Y == Int32.Parse(selectedItem.SubItems[2].Text) &&
                    connection.End.X == Int32.Parse(selectedItem.SubItems[3].Text) &&
                    connection.End.Y == Int32.Parse(selectedItem.SubItems[4].Text))
                {

                    connection.Highlight = true;
                    pictureBox1.Invalidate();

                }
                else
                {

                    connection.Highlight = false;

                }

            }

        }

        private void spriteContextMenu_EnableOptions()
        {

            bool isSprite = false;

            foreach (SpriteComponent sprite in mapCollection.CurrentMap.Sprites)
            {

                if (sprite.SpritePosition == cursor.position)
                {
                    isSprite = true;
                    break;
                }

            }

            spriteContextMenu_FindInList.Enabled = isSprite;
            spriteContextMenu_Remove.Enabled = isSprite;

        }

        private void spriteContextMenu_FindInList_Click(object sender, EventArgs e)
        {

            SpriteComponent foundSprite = null;

            foreach (SpriteComponent sprite in mapCollection.CurrentMap.Sprites)
            {

                if (sprite.SpritePosition == cursor.position)
                {
                    foundSprite = sprite;
                    break;
                }

            }

            foreach (ListViewItem item in spritesPlacedListView.Items)
            {

                if (foundSprite.SpritePosition.X == Int32.Parse(item.SubItems[3].Text) &&
                    foundSprite.SpritePosition.Y == Int32.Parse(item.SubItems[4].Text))
                {

                    item.Selected = true;
                    item.EnsureVisible();
                    spritesPlacedListView.Focus();
                    break;

                }

            }

        }

        private void spriteContextMenu_Remove_Click(object sender, EventArgs e)
        {

            SpriteComponent foundSprite = null;

            foreach (SpriteComponent sprite in mapCollection.CurrentMap.Sprites)
            {

                if (sprite.SpritePosition == cursor.position)
                {
                    foundSprite = sprite;
                    mapCollection.CurrentMap.Sprites.Remove(sprite);
                    pictureBox1.Invalidate();
                    break;
                }

            }

            foreach (ListViewItem item in spritesPlacedListView.Items)
            {

                if (foundSprite.SpritePosition.X == Int32.Parse(item.SubItems[2].Text) &&
                    foundSprite.SpritePosition.Y == Int32.Parse(item.SubItems[3].Text))
                {

                    spritesPlacedListView.Items.Remove(item);
                    spritesPlacedListView.Focus();
                    break;

                }

            }

        }

        private void spritesContextMenu_Item_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            spritesListView.Items[(int)item.Tag].Selected = true;
            spritesListView.Items[(int)item.Tag].EnsureVisible();

        }


        private void connectionContextMenu_EnableOptions()
        {

            bool isConnection = false;

            foreach (EnviromentAffectComponent connector in mapCollection.CurrentMap.Connectors)
            {

                if (connector.Start == cursor.position || connector.End == cursor.position)
                {
                    isConnection = true;
                    break;
                }

            }

            connectionContextMenu_FindInList.Enabled = isConnection;
            connectionContextMenu_Remove.Enabled = isConnection;

        }

        private void connectionContextMenu_FindInList_Click(object sender, EventArgs e)
        {

            EnviromentAffectComponent foundConnector = null;

            foreach (EnviromentAffectComponent connector in mapCollection.CurrentMap.Connectors)
            {

                if ((connector.Start == cursor.position) || (connector.End == cursor.position))
                {
                    foundConnector = connector;
                    break;
                }

            }

            foreach (ListViewItem item in connectionListView.Items)
            {

                if (
                    (foundConnector.Start.X == Int32.Parse(item.SubItems[1].Text) &&
                     foundConnector.Start.Y == Int32.Parse(item.SubItems[2].Text) &&
                     foundConnector.End.X == Int32.Parse(item.SubItems[3].Text) &&
                     foundConnector.End.Y == Int32.Parse(item.SubItems[4].Text)) ||

                     (foundConnector.End.X == Int32.Parse(item.SubItems[1].Text) &&
                     foundConnector.End.Y == Int32.Parse(item.SubItems[2].Text) &&
                     foundConnector.Start.X == Int32.Parse(item.SubItems[3].Text) &&
                     foundConnector.Start.Y == Int32.Parse(item.SubItems[4].Text))
                   )
                {

                    item.Selected = true;
                    item.EnsureVisible();
                    connectionListView.Focus();
                    break;

                }

            }

        }


        private void connectionContextMenu_Remove_Click(object sender, EventArgs e)
        {

            EnviromentAffectComponent foundConnector = null;

            foreach (EnviromentAffectComponent connector in mapCollection.CurrentMap.Connectors)
            {

                if ((connector.Start == cursor.position) || (connector.End == cursor.position))
                {
                    foundConnector = connector;
                    mapCollection.CurrentMap.Connectors.Remove(connector);
                    break;
                }

            }

            foreach (ListViewItem item in connectionListView.Items)
            {

                if (
                    (foundConnector.Start.X == Int32.Parse(item.SubItems[1].Text) &&
                     foundConnector.Start.Y == Int32.Parse(item.SubItems[2].Text) &&
                     foundConnector.End.X == Int32.Parse(item.SubItems[3].Text) &&
                     foundConnector.End.Y == Int32.Parse(item.SubItems[4].Text)) ||

                     (foundConnector.End.X == Int32.Parse(item.SubItems[1].Text) &&
                     foundConnector.End.Y == Int32.Parse(item.SubItems[2].Text) &&
                     foundConnector.Start.X == Int32.Parse(item.SubItems[3].Text) &&
                     foundConnector.Start.Y == Int32.Parse(item.SubItems[4].Text))
                   )
                {

                    connectionListView.Items.Remove(item);
                    connectionListView.Focus();
                    break;

                }

            }

        }

        private void tilesContextMenu_EnableOptions()
        {

            bool isTile = false;
            BaseMapComponent tile = mapCollection.CurrentMap.GetTile(cursor.position);

            if (tile.tileID != -1)
            {
                isTile = true;
            }

            tilesContextMenu_FindInList.Enabled = isTile;
            tilesContextMenu_Remove.Enabled = isTile;

        }

        private void tilesContextMenu_Item_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            tilesListView.Items[(int)item.Tag].Selected = true;
            tilesListView.Items[(int)item.Tag].EnsureVisible();

        }

        private void tilesContextMenu_FindInList_Click(object sender, EventArgs e)
        {
            BaseMapComponent foundTile = mapCollection.CurrentMap.GetTile(cursor.position);

            foreach (ListViewItem item in tilesListView.Items)
            {

                if (foundTile.tileID == Int32.Parse(item.SubItems[1].Text))
                {

                    item.Selected = true;
                    item.EnsureVisible();
                    tilesListView.Focus();
                    break;

                }

            }

        }

        private void tilesContextMenu_Remove_Click(object sender, EventArgs e)
        {
            mapCollection.CurrentMap.SetTile(cursor.position, 0);
        }

        private void overallTableLayout_SizeChanged(object sender, EventArgs e)
        {
            mapCollection.drawOffsetX = (pictureBox1.Width / 2) - 8;
            mapCollection.drawOffsetY = (pictureBox1.Height / 2) - 8;
            pictureBox1.Invalidate();
            this.mapEditorControl.Invalidate();
        }

        private void tilesContextMenu_ColumnInsert_Click(object sender, EventArgs e)
        {

            mapCollection.CurrentMap.Width = mapCollection.CurrentMap.Width + 1;
            tiles_ColumnInsert();


        }

        private void tilesContextMenu_ColumnMove_Click(object sender, EventArgs e)
        {

            tiles_ColumnInsert();

        }

        private void tiles_ColumnInsert()
        {

            int xPos = cursor.position.X;

            for (int x = mapCollection.CurrentMap.Width - 1; x >= xPos; x--)
            {

                for (int y = 0; y < mapCollection.CurrentMap.Height; y++)
                {

                    Point point = new Point(x, y);
                    int id = mapCollection.CurrentMap.GetTile(point).tileID;
                    point.X = point.X + 1;

                    mapCollection.CurrentMap.SetTile(point, id);

                }

            }

            for (int y = 0; y < mapCollection.CurrentMap.Height; y++)
            {

                Point point = new Point(xPos, y);
                mapCollection.CurrentMap.SetTile(point, -1);

            }


            // Update sprites ..

            foreach (SpriteComponent sprite in mapCollection.CurrentMap.Sprites)
            {

                if (sprite.SpritePosition.X >= xPos)
                {

                    sprite.SpritePosition.X++;

                }

            }


            // Update connections ..

            foreach (EnviromentAffectComponent connector in mapCollection.CurrentMap.Connectors)
            {

                if (connector.Start.X >= xPos)
                {

                    connector.Start.X++;

                }

                if (connector.End.X >= xPos)
                {

                    connector.End.X++;

                }

            }


            // Refresh form ..

            pictureBox1.Invalidate();
            UpdateCurrentSprites();
            UpdateCurrentConnectors();

        }

        private void tilesContextMenu_ColumnDelete_Click(object sender, EventArgs e)
        {

            tiles_ColumnDelete();
            mapCollection.CurrentMap.Width = mapCollection.CurrentMap.Width - 1;

        }

        private void tilesContextMenu_ColumnMoveLeft_Click(object sender, EventArgs e)
        {

            tiles_ColumnDelete();

            for (int y = 0; y < mapCollection.CurrentMap.Height; y++)
            {

                Point point = new Point(mapCollection.CurrentMap.Width - 1, y);
                mapCollection.CurrentMap.SetTile(point, -1);

            }

        }

        private void tiles_ColumnDelete()
        {

            int xPos = cursor.position.X;

            for (int x = xPos + 1; x < mapCollection.CurrentMap.Width; x++)
            {

                for (int y = 0; y < mapCollection.CurrentMap.Height; y++)
                {

                    Point point = new Point(x, y);

                    int id = mapCollection.CurrentMap.GetTile(point).tileID;
                    point.X = point.X - 1;

                    mapCollection.CurrentMap.SetTile(point, id);

                }

            }


            // Update sprites ..

            for (int i = mapCollection.CurrentMap.Sprites.Count - 1; i >= 0; i--)
            {

                SpriteComponent sprite = mapCollection.CurrentMap.Sprites[i];

                if (sprite.SpritePosition.X == xPos)
                {

                    mapCollection.CurrentMap.Sprites.RemoveAt(i);

                }

                if (sprite.SpritePosition.X > xPos)
                {

                    sprite.SpritePosition.X--;

                }

            }


            // Update connections ..

            for (int i = mapCollection.CurrentMap.Connectors.Count - 1; i >= 0; i--)
            {

                EnviromentAffectComponent connector = mapCollection.CurrentMap.Connectors[i];

                if (connector.Start.X == xPos || connector.End.X == xPos)
                {

                    mapCollection.CurrentMap.Connectors.RemoveAt(i);

                }

                if (connector.Start.X > xPos)
                {

                    connector.Start.X--;

                }

                if (connector.End.X > xPos)
                {

                    connector.End.X--;

                }

            }


            // Refresh form ..

            pictureBox1.Invalidate();
            UpdateCurrentSprites();
            UpdateCurrentConnectors();

        }


        private void tilesContextMenu_RowInsert_Click(object sender, EventArgs e)
        {

            mapCollection.CurrentMap.Height = mapCollection.CurrentMap.Height + 1;
            tiles_RowInsert();


        }

        private void tilesContextMenu_RowMoveDown_Click(object sender, EventArgs e)
        {

            tiles_RowInsert();

        }

        private void tiles_RowInsert()
        {

            int yPos = cursor.position.Y;

            for (int y = mapCollection.CurrentMap.Height - 1; y >= yPos; y--)
            {

                for (int x = 0; x < mapCollection.CurrentMap.Width; x++)
                {

                    Point point = new Point(x, y);

                    int id = mapCollection.CurrentMap.GetTile(point).tileID;
                    point.Y = point.Y + 1;

                    mapCollection.CurrentMap.SetTile(point, id);

                }

            }


            // Fill new line with blanks ..

            for (int x = 0; x < mapCollection.CurrentMap.Width; x++)
            {

                Point point = new Point(x, yPos);
                mapCollection.CurrentMap.SetTile(point, -1);

            }


            // Update sprites ..

            foreach (SpriteComponent sprite in mapCollection.CurrentMap.Sprites)
            {

                if (sprite.SpritePosition.Y >= yPos)
                {

                    sprite.SpritePosition.Y++;

                }

            }

            // Update connections ..

            foreach (EnviromentAffectComponent connector in mapCollection.CurrentMap.Connectors)
            {

                if (connector.Start.Y >= yPos)
                {

                    connector.Start.Y++;

                }

                if (connector.End.Y >= yPos)
                {

                    connector.End.Y++;

                }

            }


            // Refresh form ..

            pictureBox1.Invalidate();
            UpdateCurrentSprites();
            UpdateCurrentConnectors();

        }

        private void tilesContextMenu_RowDelete_Click(object sender, EventArgs e)
        {

            tiles_RowDelete();
            mapCollection.CurrentMap.Height = mapCollection.CurrentMap.Height - 1;

        }

        private void tilesContextMenu_RowMoveUp_Click(object sender, EventArgs e)
        {

            tiles_RowDelete();

            for (int x = 0; x < mapCollection.CurrentMap.Width; x++)
            {

                Point point = new Point(x, mapCollection.CurrentMap.Height - 1);
                mapCollection.CurrentMap.SetTile(point, -1);

            }

        }

        private void tiles_RowDelete()
        {

            int yPos = cursor.position.Y;

            for (int y = yPos + 1; y < mapCollection.CurrentMap.Height; y++)
            {

                for (int x = 0; x < mapCollection.CurrentMap.Width; x++)
                {

                    Point point = new Point(x, y);

                    int id = mapCollection.CurrentMap.GetTile(point).tileID;
                    point.Y = point.Y - 1;

                    mapCollection.CurrentMap.SetTile(point, id);

                }

            }



            // Update sprites ..

            for (int i = mapCollection.CurrentMap.Sprites.Count - 1; i >= 0; i--)
            {

                SpriteComponent sprite = mapCollection.CurrentMap.Sprites[i];

                if (sprite.SpritePosition.Y == yPos)
                {

                    mapCollection.CurrentMap.Sprites.RemoveAt(i);

                }

                if (sprite.SpritePosition.Y > yPos)
                {

                    sprite.SpritePosition.X--;

                }

            }


            // Update connections ..

            for (int i = mapCollection.CurrentMap.Connectors.Count - 1; i >= 0; i--)
            {

                EnviromentAffectComponent connector = mapCollection.CurrentMap.Connectors[i];

                if (connector.Start.Y == yPos || connector.End.Y == yPos)
                {

                    mapCollection.CurrentMap.Connectors.RemoveAt(i);

                }

                if (connector.Start.Y > yPos)
                {

                    connector.Start.Y--;

                }

                if (connector.End.Y > yPos)
                {

                    connector.End.Y--;

                }

            }


            // Refresh form ..

            pictureBox1.Invalidate();
            UpdateCurrentSprites();
            UpdateCurrentConnectors();

        }

        private void showTileTools()
        {
            this.mapEditorControl.Tool = new TileTool();

            int TileId = -1;
            if (tilesListView.SelectedItems.Count > 0)
                TileId = int.Parse(tilesListView.SelectedItems[0].SubItems[1].Text);
            tool = new TileBrush(TileId, mapCollection.CurrentMap);
            tabPages.SelectTab(0);

            tilesListView.Visible = true;
            eraseMenu.Enabled = true;
            eraseMenuItem.Enabled = true;
            rectangleMenu.Enabled = true;
            rectangleMenuItem.Enabled = true;

        }

        private void showSpritesTool()
        {
            this.mapEditorControl.Tool = new SpritePlacementTool(this.spritesPlacedListView);

            tool = new SpriteTool(mapCollection.CurrentMap, this);
            tabPages.SelectTab(1);
            spritesListView.Visible = true;
            spritesPlacedListView.Visible = true;
            removeSprite.Visible = true;

            if (spritesListView.SelectedItems.Count > 0)
            {
                tool.SetBrush(int.Parse(spritesListView.SelectedItems[0].SubItems[1].Text), int.Parse(spritesListView.SelectedItems[0].SubItems[3].Text));
            }

            eraseMenu.Enabled = false;
            eraseMenuItem.Enabled = false;
            rectangleMenu.Enabled = false;
            rectangleMenuItem.Enabled = false;

        }

        private void showConnectionTool()
        {
            this.mapEditorControl.Tool = new ConnectionTool(this.connectionListView);

            tool = new ConnectorTool(mapCollection.CurrentMap, this);
            tabPages.SelectTab(2);
            connectionListView.Visible = true;
            removeConnection.Visible = true;

            eraseMenu.Enabled = false;
            eraseMenuItem.Enabled = false;
            rectangleMenu.Enabled = false;
            rectangleMenuItem.Enabled = false;

        }

        private void tabPages_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (tabPages.SelectedIndex)
            {

                case 0:
                    showTileTools();
                    break;

                case 1:
                    showSpritesTool();
                    break;

                case 2:
                    showConnectionTool();
                    break;

                case 3:
                    this.mapEditorControl.Tool = new PlayerPlacementTool();

                    tool = new PlayerPositionTool(mapCollection.CurrentMap);

                    eraseMenu.Enabled = false;
                    eraseMenuItem.Enabled = false;
                    rectangleMenu.Enabled = false;
                    rectangleMenuItem.Enabled = false;
                    break;

            }

        }

        private void tileToolMenu_Click(object sender, EventArgs e)
        {
            showTileTools();
        }

        private void spriteToolMenu_Click(object sender, EventArgs e)
        {
            showSpritesTool();
        }

        private void connectionToolMenu_Click(object sender, EventArgs e)
        {
            showConnectionTool();
        }

        private void eraseMenu_Click(object sender, EventArgs e)
        {
            this.mapEditorControl.Tool = new TileTool();
            this.mapEditorControl.SelectedTileId = -1;

            tool = new TileBrush(-1, mapCollection.CurrentMap);
        }

        private void moveToMenu_Click(object sender, EventArgs e)
        {
            this.mapEditorControl.Tool = new FocusTool();

            tool = new MoveTool(mapCollection.CurrentMap);
        }

        private void playerStartMenu_Click(object sender, EventArgs e)
        {
            if (!(tool is PlayerPositionTool))
            {
                this.mapEditorControl.Tool = new PlayerPlacementTool();

                tool = new PlayerPositionTool(mapCollection.CurrentMap);
                tabPages.SelectTab(3);
                eraseMenu.Enabled = false;
                rectangleMenu.Enabled = false;
            }
        }

        private void centreMenu_Click(object sender, EventArgs e)
        {
            this.mapCollection.CurrentMap.CentreMap();
            this.pictureBox1.Invalidate();
            this.mapEditorControl.Invalidate();
        }

        private void rectangleMenu_Click(object sender, EventArgs e)
        {
            showTileTools();

            int tileId = -1;
            if (tilesListView.SelectedItems.Count > 0)
                tileId = int.Parse(tilesListView.SelectedItems[0].SubItems[1].Text);
            tool = new TileRectangle(this, tileId, mapCollection.CurrentMap, pictureBox1.Width / 2, pictureBox1.Height / 2);
            tilesListView.Visible = true;

            this.mapEditorControl.Tool = new RectangleFillTool();
        }

        private void eraseMenuItem_Click(object sender, EventArgs e)
        {
            this.mapEditorControl.SelectedTileId = -1;
            this.mapEditorControl.Tool = new TileTool();
            tool = new TileBrush(-1, mapCollection.CurrentMap);
        }

        private void rectangleMenuItem_Click(object sender, EventArgs e)
        {
            showTileTools();

            int tileId = -1;
            if (tilesListView.SelectedItems.Count > 0)
                tileId = int.Parse(tilesListView.SelectedItems[0].SubItems[1].Text);
            tool = new TileRectangle(this, tileId, mapCollection.CurrentMap, pictureBox1.Width / 2, pictureBox1.Height / 2);
            tilesListView.Visible = true;

            this.mapEditorControl.Tool = new RectangleFillTool();
        }

        private void moveToMenuItem_Click(object sender, EventArgs e)
        {
            this.mapEditorControl.Tool = new FocusTool();
            tool = new MoveTool(mapCollection.CurrentMap);
        }

        private void centreMenuItem_Click(object sender, EventArgs e)
        {
            mapCollection.CurrentMap.CentreMap();
            pictureBox1.Invalidate();
        }

        private void useTileTypeContextMenu_Click(object sender, EventArgs e)
        {

            Point point = new Point(cursor.position.X, cursor.position.Y);
            int tileId = mapCollection.CurrentMap.GetTile(point).tileID;
            String tileName = tileManager.GetTile(mapCollection.CurrentMap.GetTile(point).tileID).Name;

            tool.SetBrush(tileId);
            addTileToMenu(tileId, tileName);

            foreach (ListViewItem item in tilesListView.Items)
            {

                if (tileId == Int32.Parse(item.SubItems[1].Text))
                {

                    item.Selected = true;
                    item.EnsureVisible();
                    tilesListView.Focus();
                    break;

                }

            }

        }

        private void addTileToMenu(int id, String tileName)
        {

            for (int i = 7; i < tilesContextMenu.Items.Count; i++)
            {

                ToolStripMenuItem menuItem = (ToolStripMenuItem)tilesContextMenu.Items[i];

                if (menuItem.Text == tileName)
                {

                    tilesContextMenu.Items.Remove(menuItem);
                    break;

                }

            }

            Tile tile = tileManager.GetTile(id);
            ToolStripMenuItem newMenuItem = new ToolStripMenuItem();
            newMenuItem.Text = tileName;
            newMenuItem.Image = tilesListView.SmallImageList.Images[tile.TextureID];
            newMenuItem.Tag = id;
            newMenuItem.Click += new System.EventHandler(tilesContextMenu_Item_Click);
            tilesContextMenu.Items.Insert(7, newMenuItem);

            if (tilesContextMenu.Items.Count > 15) { tilesContextMenu.Items.RemoveAt(14); }

        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void spritesPlacedListView_Scroll(object sender, ScrollEventArgs e) {

            HealthNumericUpDown.Visible = false;

        }

        private void spritesPlacedListView_SelectedIndexChanged(object sender, EventArgs e) {

            HealthNumericUpDown.Visible = false;

        }

        private void spritesPlacedListView_MouseDoubleClick(object sender, MouseEventArgs e) {

            if (spritesPlacedListView.SelectedItems.Count > 0 && spritesPlacedListView.SelectedItems[0].SubItems[4].Text != "") {

                HealthNumericUpDown.Left = tabPages.Left + spritesPlacedListView.Left + spritesPlacedListView_IDColumn.Width + spritesPlacedListView_Name.Width + spritesPlacedListView_XColumn.Width + spritesPlacedListView_YColumn.Width + 42;
                HealthNumericUpDown.Top = spritesPlacedListView.Top + 108 + ((spritesPlacedListView.SelectedIndices[0] - spritesPlacedListView.TopItem.Index) * 17);
                HealthNumericUpDown.Width = spritesPlacedListView_HealthColumn.Width;
                HealthNumericUpDown.Value = Int32.Parse(spritesPlacedListView.SelectedItems[0].SubItems[4].Text);
                HealthNumericUpDown.Visible = true;
                HealthNumericUpDown.Tag = spritesPlacedListView.SelectedItems[0].Index;

            }

        }

        private void HealthNumericUpDown_Leave(object sender, EventArgs e) {

            HealthNumericUpDown.Visible = false;
        }

        private void MapEditorForm_Resize(object sender, EventArgs e) {

            HealthNumericUpDown.Visible = false;

        }
        
        private void tabPages_MouseEnter(object sender, EventArgs e) {

            HealthNumericUpDown.Visible = false;

        }

        private void HealthNumericUpDown_ValueChanged(object sender, EventArgs e) {

            if (spritesPlacedListView.SelectedItems.Count > 0 && HealthNumericUpDown.Tag != null && (((int)HealthNumericUpDown.Tag) == spritesPlacedListView.SelectedIndices[0])) {

                if (spritesPlacedListView.Items[(int)HealthNumericUpDown.Tag].SubItems[4].Text != HealthNumericUpDown.Value.ToString()) {

                    spritesPlacedListView.Items[(int)HealthNumericUpDown.Tag].SubItems[4].Text = HealthNumericUpDown.Value.ToString();

                    SpriteComponent sprite = this.mapCollection.CurrentMap.Sprites[(int)HealthNumericUpDown.Tag];

                    sprite.Health = (int)HealthNumericUpDown.Value;

                }

            }

        }

        private void HealthNumericUpDown_KeyDown(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Enter) {

                HealthNumericUpDown.Visible = false;

            }

        }

        private void spritesPlacedListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e) {

            int colIndex = e.ColumnIndex;

            if (spritesPlacedListView.Columns[colIndex].Width != Int32.Parse(spritesPlacedListView.Columns[colIndex].Tag.ToString())) {
                spritesPlacedListView.Columns[colIndex].Width = Int32.Parse(spritesPlacedListView.Columns[colIndex].Tag.ToString());
            }

        }

        private void spritesListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e) {

            int colIndex = e.ColumnIndex;

            if (spritesListView.Columns[colIndex].Width != Int32.Parse(spritesListView.Columns[colIndex].Tag.ToString())) {
                spritesListView.Columns[colIndex].Width = Int32.Parse(spritesListView.Columns[colIndex].Tag.ToString());
            }

        }

        #region Map Context Menu Events
        private void mapEditorContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is ContextMenuStrip contextMenu)
            {
                var map = this.mapEditorControl.CurrentMap;

                var menuPosition = this.mapEditorControl.PointToClient(contextMenu.Location);
                var tilePosition = map.ToTileSpace(menuPosition);
                this.mapEditorControl.TileCursor = tilePosition;

                this.addColumnToolStripMenuItem.Enabled = (map.Width < 40);
                this.removeColumnToolStripMenuItem.Enabled = (map.Width > 1);

                this.addRowToolStripMenuItem.Enabled = (map.Height < 40);
                this.removeRowToolStripMenuItem.Enabled = (map.Height > 1);

                var foundSprite = map.Sprites.FindIndex(sprite => (sprite.SpritePosition == tilePosition));
                this.spriteToolStripMenuItem.Enabled = (foundSprite != -1);

                var foundConnector = map.Connectors.FindIndex(connector => ((connector.Start == tilePosition) || (connector.End == tilePosition)));
                this.connectionToolStripMenuItem.Enabled = (foundConnector != -1);
            }
        }

        private void addColumnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menu)
            {
                var menuPosition = this.mapEditorControl.PointToClient(this.mapEditorContextMenu.Location);
                var column = this.mapEditorControl.CurrentMap.ToTileSpaceX(menuPosition.X);

                this.InsertColumn(column);
            }
        }

        private void removeColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var menuPosition = this.mapEditorControl.PointToClient(this.mapEditorContextMenu.Location);
                var column = this.mapEditorControl.CurrentMap.ToTileSpaceX(menuPosition.X);

                this.RemoveColumn(column);
            }
        }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var menuPosition = this.mapEditorControl.PointToClient(this.mapEditorContextMenu.Location);
                var row = this.mapEditorControl.CurrentMap.ToTileSpaceY(menuPosition.Y);

                this.InsertRow(row);
            }
        }

        private void removeRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var menuPosition = this.mapEditorControl.PointToClient(this.mapEditorContextMenu.Location);
                var row = this.mapEditorControl.CurrentMap.ToTileSpaceY(menuPosition.Y);

                this.RemoveRow(row);
            }
        }

        private void selectTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var menuPosition = this.mapEditorControl.PointToClient(this.mapEditorContextMenu.Location);
                var tilePosition = this.mapEditorControl.CurrentMap.ToTileSpace(menuPosition);
                var tileId = this.mapEditorControl.CurrentMap.GetTile(tilePosition).tileID;

                this.SelectTileInListView(tileId);
            }
        }

        private void eraseTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var menuPosition = this.mapEditorControl.PointToClient(this.mapEditorContextMenu.Location);
                var tilePosition = this.mapEditorControl.CurrentMap.ToTileSpace(menuPosition);
                
                this.mapEditorControl.CurrentMap.SetTile(tilePosition, -1);
            }
        }

        private void selectSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var map = this.mapEditorControl.CurrentMap;

                var menuPosition = this.mapEditorControl.PointToClient(this.mapEditorContextMenu.Location);
                var tilePosition = map.ToTileSpace(menuPosition);

                this.SelectSpriteInListView(tilePosition);
            }
        }

        private void removeSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menu)
            {
                var map = this.mapEditorControl.CurrentMap;

                var menuPosition = this.mapEditorControl.PointToClient(this.mapEditorContextMenu.Location);
                var tilePosition = map.ToTileSpace(menuPosition);

                this.RemoveSpriteInListView(tilePosition);
            }
        }

        private void selectConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menu)
            {
                var map = this.mapEditorControl.CurrentMap;

                var menuPosition = this.mapEditorControl.PointToClient(this.mapEditorContextMenu.Location);
                var tilePosition = map.ToTileSpace(menuPosition);

                this.SelectConnectionInListView(tilePosition);
            }
        }

        private void removeConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menu)
            {
                var map = this.mapEditorControl.CurrentMap;
                var menuPosition = this.mapEditorControl.PointToClient(this.mapEditorContextMenu.Location);
                var tilePosition = map.ToTileSpace(menuPosition);

                this.RemoveConnectionInListView(tilePosition);
            }
        }
        #endregion

        #region Map Context Menu Helpers

        private void SelectTileInListView(int tileId)
        {
            var tileAsText = tileId.ToString();

            var targetItem = this.tilesListView.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(item => (tileAsText == item.SubItems[1].Text));

            if (targetItem == null)
                return;

            targetItem.Selected = true;
            targetItem.EnsureVisible();
            targetItem.Focused = true;
            _ = this.tilesListView.Focus();
        }

        private void SelectSpriteInListView(Point tilePosition)
        {
            var map = this.mapEditorControl.CurrentMap;

            var targetSprite = map.Sprites.Find(sprite => sprite.SpritePosition == tilePosition);

            if (targetSprite == null)
                return;

            var x = targetSprite.SpritePosition.X.ToString();
            var y = targetSprite.SpritePosition.Y.ToString();

            var targetItem = this.spritesPlacedListView.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(item => (x == item.SubItems[3].Text) && (y == item.SubItems[4].Text));

            if (targetItem == null)
                return;

            targetItem.Selected = true;
            targetItem.EnsureVisible();
            targetItem.Focused = true;
            _ = this.spritesPlacedListView.Focus();
        }

        private void RemoveSpriteInListView(Point tilePosition)
        {
            var map = this.mapEditorControl.CurrentMap;

            var spriteIndex = map.Sprites.FindIndex(sprite => sprite.SpritePosition == tilePosition);

            if (spriteIndex == -1)
                return;

            var targetSprite = map.Sprites[spriteIndex];
            map.Sprites.RemoveAt(spriteIndex);

            this.mapEditorControl.Invalidate();

            var x = targetSprite.SpritePosition.X.ToString();
            var y = targetSprite.SpritePosition.Y.ToString();

            var targetItem = this.spritesPlacedListView.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(item => (x == item.SubItems[3].Text) && (y == item.SubItems[4].Text));

            if (targetItem == null)
                return;

            this.spritesPlacedListView.Items.Remove(targetItem);
            _ = this.spritesPlacedListView.Focus();
        }

        private void SelectConnectionInListView(Point tilePosition)
        {
            var map = this.mapEditorControl.CurrentMap;

            var targetConnection = map.Connectors.Find(connection => ((connection.Start == tilePosition) || (connection.End == tilePosition)));

            if (targetConnection == null)
                return;

            var startX = targetConnection.Start.X.ToString();
            var startY = targetConnection.Start.Y.ToString();
            var endX = targetConnection.End.X.ToString();
            var endY = targetConnection.End.Y.ToString();

            var targetItem = this.connectionListView.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(item => ((startX == item.SubItems[1].Text) && (startY == item.SubItems[2].Text)) && ((endX == item.SubItems[3].Text) && (endY == item.SubItems[4].Text)));

            if (targetItem == null)
                return;

            targetItem.Selected = true;
            targetItem.EnsureVisible();
            targetItem.Focused = true;
            _ = this.connectionListView.Focus();
        }

        private void RemoveConnectionInListView(Point tilePosition)
        {
            var map = this.mapEditorControl.CurrentMap;

            var connectionIndex = map.Connectors.FindIndex(connection => ((connection.Start == tilePosition) || (connection.End == tilePosition)));

            if (connectionIndex == -1)
                return;

            var targetConnection = map.Connectors[connectionIndex];
            map.Connectors.RemoveAt(connectionIndex);

            var startX = targetConnection.Start.X.ToString();
            var startY = targetConnection.Start.Y.ToString();
            var endX = targetConnection.End.X.ToString();
            var endY = targetConnection.End.Y.ToString();

            var targetItem = this.connectionListView.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(item => ((startX == item.SubItems[1].Text) && (startY == item.SubItems[2].Text)) && ((endX == item.SubItems[3].Text) && (endY == item.SubItems[4].Text)));

            if (targetItem == null)
                return;

            targetItem.Selected = true;
            targetItem.EnsureVisible();
            _ = this.connectionListView.Focus();

            this.connectionListView.Items.Remove(targetItem);
            _ = this.connectionListView.Focus();
        }

        private void RefreshMap()
        {
            this.mapEditorControl.Invalidate();
            this.UpdateCurrentSprites();
            this.UpdateCurrentConnectors();
        }

        private void InsertColumn(int column)
        {
            var map = this.mapEditorControl.CurrentMap;

            map.Width += 1;

            for (int x = map.Width - 1; x >= column; --x)
                for (int y = 0; y < map.Height; ++y)
                {
                    Point point = new Point(x, y);
                    int id = map.GetTile(point).tileID;
                    point.X += 1;

                    map.SetTile(point, id);
                }

            for (int y = 0; y < map.Height; ++y)
                map.SetTile(new Point(column, y), -1);

            // Update sprites
            foreach (var sprite in map.Sprites)
                if (sprite.SpritePosition.X >= column)
                    sprite.SpritePosition.X++;

            // Update connections
            foreach (var connector in map.Connectors)
            {
                if (connector.Start.X >= column)
                    connector.Start.X++;

                if (connector.End.X >= column)
                    connector.End.X++;
            }

            this.RefreshMap();
        }

        private void RemoveColumn(int column)
        {
            var map = this.mapEditorControl.CurrentMap;

            for (int x = column + 1; x < map.Width; ++x)
                for (int y = 0; y < map.Height; ++y)
                {
                    Point point = new Point(x, y);

                    int id = map.GetTile(point).tileID;
                    point.X -= 1;

                    map.SetTile(point, id);
                }

            map.Width -= 1;

            // Update sprites
            for (int index = map.Sprites.Count - 1; index >= 0; --index)
            {
                SpriteComponent sprite = map.Sprites[index];

                if (sprite.SpritePosition.X == column)
                    map.Sprites.RemoveAt(index);

                if (sprite.SpritePosition.X > column)
                    sprite.SpritePosition.X--;
            }


            // Update connections
            for (int index = map.Connectors.Count - 1; index >= 0; --index)
            {
                EnviromentAffectComponent connector = map.Connectors[index];

                if ((connector.Start.X == column) || (connector.End.X == column))
                    map.Connectors.RemoveAt(index);

                if (connector.Start.X > column)
                    connector.Start.X--;

                if (connector.End.X > column)
                    connector.End.X--;
            }

            this.RefreshMap();
        }

        private void InsertRow(int row)
        {
            var map = this.mapEditorControl.CurrentMap;

            map.Height += 1;

            for (int y = map.Height - 1; y >= row; --y)
                for (int x = 0; x < map.Width; ++x)
                {
                    Point point = new Point(x, y);

                    int id = map.GetTile(point).tileID;
                    point.Y = point.Y + 1;

                    map.SetTile(point, id);
                }

            // Fill new line with blanks
            for (int x = 0; x < map.Width; x++)
                map.SetTile(new Point(x, row), -1);


            // Update sprites
            foreach (var sprite in map.Sprites)
                if (sprite.SpritePosition.Y >= row)
                    sprite.SpritePosition.Y++;

            // Update connections
            foreach (var connector in map.Connectors)
            {
                if (connector.Start.Y >= row)
                    connector.Start.Y++;

                if (connector.End.Y >= row)
                    connector.End.Y++;
            }

            this.RefreshMap();
        }

        private void RemoveRow(int row)
        {
            var map = this.mapEditorControl.CurrentMap;

            for (int y = row + 1; y < map.Height; ++y)
                for (int x = 0; x < map.Width; ++x)
                {
                    Point point = new Point(x, y);

                    int id = map.GetTile(point).tileID;
                    point.Y -= 1;

                    map.SetTile(point, id);
                }

            map.Height -= 1;

            // Update sprites
            for (int index = map.Sprites.Count - 1; index >= 0; --index)
            {
                var sprite = map.Sprites[index];

                if (sprite.SpritePosition.Y == row)
                    map.Sprites.RemoveAt(index);

                if (sprite.SpritePosition.Y > row)
                    sprite.SpritePosition.X--;
            }

            // Update connections
            for (int index = map.Connectors.Count - 1; index >= 0; --index)
            {
                var connector = map.Connectors[index];

                if ((connector.Start.Y == row) || (connector.End.Y == row))
                    map.Connectors.RemoveAt(index);

                if (connector.Start.Y > row)
                    connector.Start.Y--;

                if (connector.End.Y > row)
                    connector.End.Y--;
            }

            this.RefreshMap();
        }

        #endregion
    }
}
