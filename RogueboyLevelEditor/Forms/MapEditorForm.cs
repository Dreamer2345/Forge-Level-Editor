using RogueboyLevelEditor.map;
using RogueboyLevelEditor.map.Component;
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
        private const string keepOpen = "KeepOpen";

        private MapCollection mapCollection;
        private readonly TileManager tileManager = new TileManager();

        void AddTextures()
        {
            TextureManager textureManager = new TextureManager();
            ExceptionReport exception = textureManager.Load(Directory.GetCurrentDirectory() + "/Config/TextureAssignments.xml");

            if (exception.Failed)
                MessageBox.Show(exception.exception.ToString(), "Error loading Textures", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void AddTiles()
        {
            TileManager tileManager = new TileManager();
            ExceptionReport exception = tileManager.Load(Directory.GetCurrentDirectory() + "/Config/TileAssignments.xml");

            if (exception.Failed)
                MessageBox.Show(exception.exception.ToString(), "Error loading Tiles", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        void AddSprites()
        {
            SpriteManager spriteManager = new SpriteManager();
            ExceptionReport exception = spriteManager.Load(Directory.GetCurrentDirectory() + "/Config/SpriteAssignments.xml");

            if (exception.Failed)
                MessageBox.Show(exception.exception.ToString(), "Error loading Sprites", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            showTileTools();

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
            mapEditorControl.TileChanged += new EventHandler<TileChangedEventArgs>(mapEditorControl_onTileChanged);
            mapEditorControl.TileSelected += new EventHandler<TileSelectedEventArgs>(mapEditorControl_onTileSelected);
            mapEditorControl.SpriteAdded += new EventHandler<SpriteAddedEventArgs>(mapEditorControl_onSpriteAdded);
            mapEditorControl.SingleActionComplete += new EventHandler<SingleActionEventArgs>(mapEditorControl_onSingleActionComplete);

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
                newItem.SubItems.Add(i.Item2.IsReceiver.ToString());
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

                UpdateCurrentSprites();
                UpdateCurrentConnectors();
            }

        }

        private void MapEditorForm_Load(object sender, EventArgs e)
        {
            mapCollection.drawOffsetX = (this.mapEditorControl.Width / 2) - 8;
            mapCollection.drawOffsetY = (this.mapEditorControl.Height / 2) - 8;
            mapCollection.viewWidth = (int)Math.Ceiling(this.mapEditorControl.Width / 16d);
            mapCollection.viewHeight = (int)Math.Ceiling(this.mapEditorControl.Height / 16d);

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
                this.mapEditorControl.SelectedTileId = int.Parse(tilesListView.SelectedItems[0].SubItems[1].Text);
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

                    mapCollection.drawOffsetX = (this.mapEditorControl.Width / 2) - 8;
                    mapCollection.drawOffsetY = (this.mapEditorControl.Height / 2) - 8;
                    mapCollection.viewWidth = (int)Math.Ceiling(this.mapEditorControl.Width / 16d);
                    mapCollection.viewHeight = (int)Math.Ceiling(this.mapEditorControl.Height / 16d);

                    if (mapCollection.OpenCount == 0)
                    {
                        MessageBox.Show("Error parsing map file.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mapCollection = new MapCollection();
                        return;
                    }


                    // Remove any existing menu items ..

                    while (mapsMenu.DropDownItems.Count > 6)
                        mapsMenu.DropDownItems.RemoveAt(6);


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

                mapCollection.CurrentMap = newMap;
                UpdateCurrentSprites();
                UpdateCurrentConnectors();

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
                this.mapEditorControl.Invalidate();
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
                this.mapEditorControl.Invalidate();
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
                this.mapEditorControl.SelectedSpriteId = int.Parse(spritesListView.SelectedItems[0].SubItems[1].Text);
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

                UpdateCurrentSprites();
                UpdateCurrentConnectors();
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

        // To Do: reduce the amount of code duplication in the following 5 functions
        private void viewTileMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null)
            {
                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawBackground = true;
            }
            else
            {
                menuItem.Image = null;
                mapCollection.drawBackground = false;
            }

            this.mapEditorControl.Invalidate();
        }

        private void viewSpritesMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null)
            {
                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawSprites = true;
            }
            else
            {
                menuItem.Image = null;
                mapCollection.drawSprites = false;
            }

            this.mapEditorControl.Invalidate();
        }

        private void viewConnectionsMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null)
            {
                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawConnections = true;

            }
            else
            {
                menuItem.Image = null;
                mapCollection.drawConnections = false;
            }

            this.mapEditorControl.Invalidate();
        }

        private void viewPlayerStartMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null)
            {
                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.drawPlayer = true;
            }
            else
            {
                menuItem.Image = null;
                mapCollection.drawPlayer = false;
            }

            this.mapEditorControl.Invalidate();
        }

        private void viewOutOfBoundsMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Image == null)
            {
                menuItem.Image = RogueboyLevelEditor.Properties.Resources.Tick;
                mapCollection.CurrentMap.ShowOutOfBounds = true;
            }
            else
            {
                menuItem.Image = null;
                mapCollection.CurrentMap.ShowOutOfBounds = false;
            }

            this.mapEditorControl.Invalidate();
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

            this.mapEditorControl.TileCursor = this.mapEditorControl.CurrentMap.ToScreenSpace(point);
        }

        private void connectionListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListViewItem selectedItem = e.Item;

            foreach (EnviromentAffectComponent connection in mapCollection.CurrentMap.Connectors)
                connection.Highlight =
                    (connection.Start.X == int.Parse(selectedItem.SubItems[1].Text) &&
                    connection.Start.Y == int.Parse(selectedItem.SubItems[2].Text) &&
                    connection.End.X == int.Parse(selectedItem.SubItems[3].Text) &&
                    connection.End.Y == int.Parse(selectedItem.SubItems[4].Text));

            this.mapEditorControl.Invalidate();
        }

        private void overallTableLayout_SizeChanged(object sender, EventArgs e)
        {
            mapCollection.drawOffsetX = (this.mapEditorControl.Width / 2) - 8;
            mapCollection.drawOffsetY = (this.mapEditorControl.Height / 2) - 8;
            this.mapEditorControl.Invalidate();
        }

        private void showTileTools()
        {
            this.mapEditorControl.Tool = new TileTool();

            tabPages.SelectTab(0);

            tilesListView.Visible = true;
            eraseMenu.Enabled = true;
            eraseMenuItem.Enabled = true;
            rectangleMenu.Enabled = true;
            rectangleMenuItem.Enabled = true;
            selectTileButton.Enabled = true;
            pickTileMenuItem.Enabled = true;

            moveButton.Enabled = true;
            moveMenuItem.Enabled = true;
            moveToMenu.Enabled = true;
            moveToMenuItem.Enabled = true;
            centreMenu.Enabled = true;
            centreMenuItem.Enabled = true;

        }

        private void showSpritesTool()
        {
            this.mapEditorControl.Tool = new SpritePlacementTool(this.spritesPlacedListView);

            tabPages.SelectTab(1);

            spritesListView.Visible = true;
            spritesPlacedListView.Visible = true;
            removeSprite.Visible = true;

            eraseMenu.Enabled = false;
            eraseMenuItem.Enabled = false;
            rectangleMenu.Enabled = false;
            rectangleMenuItem.Enabled = false;
            selectTileButton.Enabled = false;
            pickTileMenuItem.Enabled = false;

            moveButton.Enabled = true;
            moveMenuItem.Enabled = true;
            moveToMenu.Enabled = true;
            moveToMenuItem.Enabled = true;
            centreMenu.Enabled = true;
            centreMenuItem.Enabled = true;
        }

        private void showConnectionTool()
        {
            this.mapEditorControl.Tool = new ConnectionTool(this.connectionListView);

            tabPages.SelectTab(2);
            connectionListView.Visible = true;
            removeConnection.Visible = true;

            eraseMenu.Enabled = false;
            eraseMenuItem.Enabled = false;
            rectangleMenu.Enabled = false;
            rectangleMenuItem.Enabled = false;
            selectTileButton.Enabled = false;
            pickTileMenuItem.Enabled = false;

            moveButton.Enabled = true;
            moveMenuItem.Enabled = true;
            moveToMenu.Enabled = true;
            moveToMenuItem.Enabled = true;
            centreMenu.Enabled = true;
            centreMenuItem.Enabled = true;
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

                    eraseMenu.Enabled = false;
                    eraseMenuItem.Enabled = false;
                    rectangleMenu.Enabled = false;
                    rectangleMenuItem.Enabled = false;
                    selectTileButton.Enabled = false;
                    pickTileMenuItem.Enabled = false;

                    moveButton.Enabled = true;
                    moveMenuItem.Enabled = true;
                    moveToMenu.Enabled = true;
                    moveToMenuItem.Enabled = true;
                    centreMenu.Enabled = true;
                    centreMenuItem.Enabled = true;

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
            this.SelectTileInListView(-1);

        }

        private void moveToMenu_Click(object sender, EventArgs e)
        {
            this.mapEditorControl.Tool = new FocusTool();
            eraseMenu.Enabled = false;
            eraseMenuItem.Enabled = false;
            rectangleMenu.Enabled = false;
            rectangleMenuItem.Enabled = false;
            selectTileButton.Enabled = false;
            pickTileMenuItem.Enabled = false;
            moveButton.Enabled = false;
            moveMenuItem.Enabled = false;
            //moveToMenu.Enabled = false;
            //moveToMenuItem.Enabled = false;
            centreMenu.Enabled = false;
            centreMenuItem.Enabled = false;
        }

        private void playerStartMenu_Click(object sender, EventArgs e)
        {
            this.mapEditorControl.Tool = new PlayerPlacementTool();

            tabPages.SelectTab(3);
            eraseMenu.Enabled = false;
            rectangleMenu.Enabled = false;
        }

        private void centreMenu_Click(object sender, EventArgs e)
        {
            this.mapCollection.CurrentMap.CentreMap();
            this.mapCollection.drawOffsetX = (this.mapEditorControl.Width / 2) - 8;
            this.mapCollection.drawOffsetY = (this.mapEditorControl.Height / 2) - 8;
            this.mapEditorControl.Invalidate();
            this.mapEditorControl.Refresh();
        }

        private void rectangleMenu_Click(object sender, EventArgs e)
        {
            showTileTools();

            tilesListView.Visible = true;

            this.mapEditorControl.Tool = new RectangleFillTool();

        }

        private void selectTileButton_Click(object sender, EventArgs e)
        {
            this.mapEditorControl.Tool = new TileSelectTool();

            eraseMenu.Enabled = false;
            eraseMenuItem.Enabled = false;
            rectangleMenu.Enabled = false;
            rectangleMenuItem.Enabled = false;
            //selectTileButton.Enabled = false;
            //pickTileMenuItem.Enabled = false;
            moveButton.Enabled = false;
            moveMenuItem.Enabled = false;
            moveToMenu.Enabled = false;
            moveToMenuItem.Enabled = false;
            centreMenu.Enabled = false;
            centreMenuItem.Enabled = false;


        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            this.mapEditorControl.Tool = new DragMoveTool();
            eraseMenu.Enabled = false;
            eraseMenuItem.Enabled = false;
            rectangleMenu.Enabled = false;
            rectangleMenuItem.Enabled = false;
            selectTileButton.Enabled = false;
            pickTileMenuItem.Enabled = false;
            //moveButton.Enabled = false;
            //moveMenuItem.Enabled = false;
            moveToMenu.Enabled = false;
            moveToMenuItem.Enabled = false;
            centreMenu.Enabled = false;
            centreMenuItem.Enabled = false;
        }

        private void eraseMenuItem_Click(object sender, EventArgs e)
        {
            this.mapEditorControl.SelectedTileId = -1;
            this.mapEditorControl.Tool = new TileTool();
        }

        private void rectangleMenuItem_Click(object sender, EventArgs e)
        {
            showTileTools();

            tilesListView.Visible = true;

            this.mapEditorControl.Tool = new RectangleFillTool();
        }
        
        private void centreMenuItem_Click(object sender, EventArgs e)
        {
            mapCollection.CurrentMap.CentreMap();
            this.mapEditorControl.Invalidate();
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

            if (spritesPlacedListView.SelectedItems.Count > 0 && spritesPlacedListView.SelectedItems[0].SubItems[5].Text != "") {

                HealthNumericUpDown.Left = tabPages.Left + spritesPlacedListView.Left + spritesPlacedListView_IDColumn.Width + spritesPlacedListView_Name.Width + spritesPlacedListView_XColumn.Width + spritesPlacedListView_YColumn.Width + 42;
                HealthNumericUpDown.Top = spritesPlacedListView.Top + 108 + ((spritesPlacedListView.SelectedIndices[0] - spritesPlacedListView.TopItem.Index) * 17);
                HealthNumericUpDown.Width = spritesPlacedListView_HealthColumn.Width;
                HealthNumericUpDown.Value = int.Parse(spritesPlacedListView.SelectedItems[0].SubItems[5].Text);
                HealthNumericUpDown.Visible = true;
                HealthNumericUpDown.Tag = spritesPlacedListView.SelectedItems[0].Index;

            }

        }

        private void HealthNumericUpDown_Leave(object sender, EventArgs e)
        {
            HealthNumericUpDown.Visible = false;
        }

        private void MapEditorForm_Resize(object sender, EventArgs e)
        {
            HealthNumericUpDown.Visible = false;
        }

        private void tabPages_MouseEnter(object sender, EventArgs e)
        {
            HealthNumericUpDown.Visible = false;
        }

        private void HealthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (spritesPlacedListView.SelectedItems.Count > 0 && HealthNumericUpDown.Tag != null && (((int)HealthNumericUpDown.Tag) == spritesPlacedListView.SelectedIndices[0]))
                if (spritesPlacedListView.Items[(int)HealthNumericUpDown.Tag].SubItems[5].Text != HealthNumericUpDown.Value.ToString())
                {
                    spritesPlacedListView.Items[(int)HealthNumericUpDown.Tag].SubItems[5].Text = HealthNumericUpDown.Value.ToString();

                    SpriteComponent sprite = this.mapCollection.CurrentMap.Sprites[(int)HealthNumericUpDown.Tag];

                    sprite.Health = (int)HealthNumericUpDown.Value;
                }
        }

        private void HealthNumericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                HealthNumericUpDown.Visible = false;
        }

        private void spritesPlacedListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            int colIndex = e.ColumnIndex;

            if (spritesPlacedListView.Columns[colIndex].Width != int.Parse(spritesPlacedListView.Columns[colIndex].Tag.ToString()))
                spritesPlacedListView.Columns[colIndex].Width = int.Parse(spritesPlacedListView.Columns[colIndex].Tag.ToString());
        }

        private void spritesListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            int colIndex = e.ColumnIndex;

            if (spritesListView.Columns[colIndex].Width != int.Parse(spritesListView.Columns[colIndex].Tag.ToString()))
                spritesListView.Columns[colIndex].Width = int.Parse(spritesListView.Columns[colIndex].Tag.ToString());
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
                if (spriteToolStripMenuItem.DropDownItems.Count > 3) {
                    this.spriteToolStripMenuItem.Enabled = true;
                    this.selectSpriteToolStripMenuItem.Enabled = (foundSprite != -1);
                    this.removeSpriteToolStripMenuItem.Enabled = (foundSprite != -1);
                }
                else {
                    this.spriteToolStripMenuItem.Enabled = (foundSprite != -1);
                }

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

                showTileTools();
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

                showSpritesTool();
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

            // Update player position
            if (map.PlayerStart.X > column) map.PlayerStart.X++;

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

            // Update player position
            if (map.PlayerStart.X >= column) map.PlayerStart.X--;

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
            
            // Update player position
            if (map.PlayerStart.Y > row) map.PlayerStart.Y++;

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

            // Update player position
            if (map.PlayerStart.Y >= row) map.PlayerStart.Y--;

            this.RefreshMap();
        }

        #endregion

        private void mapEditorControl_MouseMove(object sender, MouseEventArgs e) {

            Point point = mapEditorControl.CurrentMap.ToTileSpace(e.Location);

            if (point.X >= 0 && point.X < mapEditorControl.CurrentMap.Width &&
                point.Y >= 0 && point.X < mapEditorControl.CurrentMap.Height) {
                toolStatusLabel.Text = point.ToString();
            }
            else {
                toolStatusLabel.Text = "";
            }

        }

        private void mapEditorControl_onTileChanged(object sender, TileChangedEventArgs e) {

            Tile tile = (Tile)e.NewTile;

            for (int i = 3; i < tileToolStripMenuItem.DropDownItems.Count; i++) {

                ToolStripMenuItem menuItem = (ToolStripMenuItem)tileToolStripMenuItem.DropDownItems[i];

                if (menuItem.Text == tile.Name) {

                    tileToolStripMenuItem.DropDownItems.Remove(menuItem);
                    break;

                }

            }

            ToolStripMenuItem newMenuItem = new ToolStripMenuItem();
            newMenuItem.Text = tile.Name;
            newMenuItem.Image = tilesListView.SmallImageList.Images[tile.TextureID];
            newMenuItem.Tag = tile.ID;
            newMenuItem.Click += new System.EventHandler(mapEditorContextMenu_Tile_Item_Click);
            tileToolStripMenuItem.DropDownItems.Insert(3, newMenuItem);

            if (tileToolStripMenuItem.DropDownItems.Count > 11) { tileToolStripMenuItem.DropDownItems.RemoveAt(11); }

        }

        private void mapEditorContextMenu_Tile_Item_Click(object sender, EventArgs e) {

            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            // Switch to TileTool if not already selected ..

            if (!(this.mapEditorControl.Tool is TileTool)) {

                showTileTools();

            }

            for (int i = 0; i < tilesListView.Items.Count; i++) {

                if (int.Parse(tilesListView.Items[i].SubItems[1].Text) == (int)item.Tag) {

                    tilesListView.Items[i].Selected = true;
                    tilesListView.Items[i].EnsureVisible();
                    break;

                }

            }

        }

        private void mapEditorControl_onSpriteAdded(object sender, SpriteAddedEventArgs e) {

            for (int i = 3; i < spriteToolStripMenuItem.DropDownItems.Count; i++) {

                ToolStripMenuItem menuItem = (ToolStripMenuItem)spriteToolStripMenuItem.DropDownItems[i];

                if (menuItem.Text == e.Sprite.Name) {

                    mapEditorContextMenu.Items.Remove(menuItem);
                    break;

                }

            }

            ToolStripMenuItem newMenuItem = new ToolStripMenuItem();
            newMenuItem.Text = e.Sprite.Name;
            newMenuItem.Image = spritesListView.SmallImageList.Images[e.Sprite.ID];
            newMenuItem.Tag = e.Sprite.ID;
            newMenuItem.Click += new System.EventHandler(mapEditorContextMenu_Sprite_Item_Click);
            spriteToolStripMenuItem.DropDownItems.Insert(3, newMenuItem);

            if (spriteToolStripMenuItem.DropDownItems.Count > 11) { spriteToolStripMenuItem.DropDownItems.RemoveAt(11); }

        }


        private void mapEditorContextMenu_Sprite_Item_Click(object sender, EventArgs e) {

            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            // Switch to TileTool if not already selected ..

            if (!(this.mapEditorControl.Tool is SpritePlacementTool)) {

                showSpritesTool();

            }

            for (int i = 0; i < spritesListView.Items.Count; i++) {

                if (int.Parse(spritesListView.Items[i].SubItems[1].Text) == (int)item.Tag) {

                    spritesListView.Items[i].Selected = true;
                    spritesListView.Items[i].EnsureVisible();
                    break;

                }

            }

        }


        private void mapEditorControl_onTileSelected(object sender, TileSelectedEventArgs e) {

            this.SelectTileInListView(e.Tile.ID);

        }
        
        private void mapEditorControl_onSingleActionComplete(object sender, SingleActionEventArgs e) {

            switch (tabPages.SelectedIndex) {

                case 0:
                    showTileTools();
                    break;

                case 1:
                    showSpritesTool();
                    break;

                case 2:
                    showConnectionTool();
                    break;

            }

        }
        
        private void MapEditorForm_KeyDown(object sender, KeyEventArgs e) {

            if ((centreMenu.Enabled == false) && (e.KeyCode == Keys.Escape)) {

                showTileTools();

            }

        }

    }

}
