namespace RogueboyLevelEditor.Forms
{
    partial class MapEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLoadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.FileExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mapPropertysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOutOfBoundsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSpritesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewConnectionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPlayerStartMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mapsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mapAddMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mapDeleteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mapMoveUpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mapMoveDownMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playerStartButton = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.centreMap = new System.Windows.Forms.Button();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tilesListView = new System.Windows.Forms.ListView();
            this.TileImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TileID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsExit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsSender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsReciver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spritesListView = new System.Windows.Forms.ListView();
            this.Texture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SpriteID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SpriteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SpriteHealth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spritesPlacedListView = new System.Windows.Forms.ListView();
            this.SpritePicture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spritesPlaced_HealthColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeSprite = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.removeConnection = new System.Windows.Forms.Button();
            this.connectionListView = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.currentMapLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentFileLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.spriteContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.spriteContextMenu_FindInList = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteContextMenu_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.connectionContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.connectionContextMenu_FindInList = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionContextMenu_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tilesContextMenu_FindInList = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.spriteContextMenu.SuspendLayout();
            this.connectionContextMenu.SuspendLayout();
            this.tilesContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(12, 12);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu,
            this.mapsMenu,
            this.helpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(740, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileLoadMenu,
            this.fileSaveMenu,
            this.fileSaveAsMenu,
            this.toolStripMenuItem3,
            this.FileExitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            // 
            // fileLoadMenu
            // 
            this.fileLoadMenu.Name = "fileLoadMenu";
            this.fileLoadMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.fileLoadMenu.Size = new System.Drawing.Size(159, 22);
            this.fileLoadMenu.Text = "Load";
            this.fileLoadMenu.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // fileSaveMenu
            // 
            this.fileSaveMenu.Name = "fileSaveMenu";
            this.fileSaveMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.fileSaveMenu.Size = new System.Drawing.Size(159, 22);
            this.fileSaveMenu.Text = "Save File";
            this.fileSaveMenu.Click += new System.EventHandler(this.fileSaveMenu_Click);
            // 
            // fileSaveAsMenu
            // 
            this.fileSaveAsMenu.Name = "fileSaveAsMenu";
            this.fileSaveAsMenu.Size = new System.Drawing.Size(159, 22);
            this.fileSaveAsMenu.Text = "Save File As ...";
            this.fileSaveAsMenu.Click += new System.EventHandler(this.fileSaveAsMenu_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(156, 6);
            // 
            // FileExitMenu
            // 
            this.FileExitMenu.Name = "FileExitMenu";
            this.FileExitMenu.Size = new System.Drawing.Size(159, 22);
            this.FileExitMenu.Text = "E&xit";
            this.FileExitMenu.Click += new System.EventHandler(this.fileExistMenu_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapPropertysToolStripMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(39, 20);
            this.editMenu.Text = "&Edit";
            // 
            // mapPropertysToolStripMenuItem
            // 
            this.mapPropertysToolStripMenuItem.Name = "mapPropertysToolStripMenuItem";
            this.mapPropertysToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mapPropertysToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.mapPropertysToolStripMenuItem.Text = "Map Properties";
            this.mapPropertysToolStripMenuItem.Click += new System.EventHandler(this.mapPropertysToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewOutOfBoundsMenu,
            this.viewTileMenu,
            this.viewSpritesMenu,
            this.viewConnectionsMenu,
            this.viewPlayerStartMenu});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(44, 20);
            this.viewMenu.Text = "&View";
            // 
            // viewOutOfBoundsMenu
            // 
            this.viewOutOfBoundsMenu.Name = "viewOutOfBoundsMenu";
            this.viewOutOfBoundsMenu.Size = new System.Drawing.Size(153, 22);
            this.viewOutOfBoundsMenu.Text = "&Out Of Bounds";
            this.viewOutOfBoundsMenu.Click += new System.EventHandler(this.viewOutOfBoundsMenu_Click);
            // 
            // viewTileMenu
            // 
            this.viewTileMenu.Name = "viewTileMenu";
            this.viewTileMenu.Size = new System.Drawing.Size(153, 22);
            this.viewTileMenu.Text = "&Tiles";
            this.viewTileMenu.Click += new System.EventHandler(this.viewTileMenu_Click);
            // 
            // viewSpritesMenu
            // 
            this.viewSpritesMenu.Name = "viewSpritesMenu";
            this.viewSpritesMenu.Size = new System.Drawing.Size(153, 22);
            this.viewSpritesMenu.Text = "&Sprites";
            this.viewSpritesMenu.Click += new System.EventHandler(this.viewSpritesMenu_Click);
            // 
            // viewConnectionsMenu
            // 
            this.viewConnectionsMenu.Name = "viewConnectionsMenu";
            this.viewConnectionsMenu.Size = new System.Drawing.Size(153, 22);
            this.viewConnectionsMenu.Text = "&Connections";
            this.viewConnectionsMenu.Click += new System.EventHandler(this.viewConnectionsMenu_Click);
            // 
            // viewPlayerStartMenu
            // 
            this.viewPlayerStartMenu.Name = "viewPlayerStartMenu";
            this.viewPlayerStartMenu.Size = new System.Drawing.Size(153, 22);
            this.viewPlayerStartMenu.Text = "&Player Start";
            this.viewPlayerStartMenu.Click += new System.EventHandler(this.viewPlayerStartMenu_Click);
            // 
            // mapsMenu
            // 
            this.mapsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapAddMenu,
            this.mapDeleteMenu,
            this.toolStripMenuItem1,
            this.mapMoveUpMenu,
            this.mapMoveDownMenu,
            this.toolStripMenuItem2});
            this.mapsMenu.Name = "mapsMenu";
            this.mapsMenu.Size = new System.Drawing.Size(48, 20);
            this.mapsMenu.Text = "&Maps";
            // 
            // mapAddMenu
            // 
            this.mapAddMenu.Name = "mapAddMenu";
            this.mapAddMenu.Size = new System.Drawing.Size(138, 22);
            this.mapAddMenu.Text = "&Add Map";
            this.mapAddMenu.Click += new System.EventHandler(this.mapAddMenu_Click);
            // 
            // mapDeleteMenu
            // 
            this.mapDeleteMenu.Name = "mapDeleteMenu";
            this.mapDeleteMenu.Size = new System.Drawing.Size(138, 22);
            this.mapDeleteMenu.Text = "&Delete Map";
            this.mapDeleteMenu.Click += new System.EventHandler(this.mapDeleteMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 6);
            // 
            // mapMoveUpMenu
            // 
            this.mapMoveUpMenu.Name = "mapMoveUpMenu";
            this.mapMoveUpMenu.Size = new System.Drawing.Size(138, 22);
            this.mapMoveUpMenu.Tag = "KeepOpen";
            this.mapMoveUpMenu.Text = "Move &Up";
            this.mapMoveUpMenu.Click += new System.EventHandler(this.mapMoveUpMenu_Click);
            // 
            // mapMoveDownMenu
            // 
            this.mapMoveDownMenu.Name = "mapMoveDownMenu";
            this.mapMoveDownMenu.Size = new System.Drawing.Size(138, 22);
            this.mapMoveDownMenu.Tag = "KeepOpen";
            this.mapMoveDownMenu.Text = "Move &Down";
            this.mapMoveDownMenu.Click += new System.EventHandler(this.mapMoveDownMenu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 6);
            // 
            // helpMenu
            // 
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.playerStartButton);
            this.groupBox1.Controls.Add(this.radioButton7);
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.centreMap);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // playerStartButton
            // 
            this.playerStartButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.playerStartButton.AutoSize = true;
            this.playerStartButton.Image = ((System.Drawing.Image)(resources.GetObject("playerStartButton.Image")));
            this.playerStartButton.Location = new System.Drawing.Point(602, 24);
            this.playerStartButton.Name = "playerStartButton";
            this.playerStartButton.Size = new System.Drawing.Size(71, 39);
            this.playerStartButton.TabIndex = 8;
            this.playerStartButton.Text = "Player Start";
            this.playerStartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.playerStartButton.UseVisualStyleBackColor = true;
            this.playerStartButton.CheckedChanged += new System.EventHandler(this.playerStartButton_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton7.AutoSize = true;
            this.radioButton7.Image = ((System.Drawing.Image)(resources.GetObject("radioButton7.Image")));
            this.radioButton7.Location = new System.Drawing.Point(344, 24);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(42, 39);
            this.radioButton7.TabIndex = 7;
            this.radioButton7.Text = "Edge";
            this.radioButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton6.AutoSize = true;
            this.radioButton6.Image = ((System.Drawing.Image)(resources.GetObject("radioButton6.Image")));
            this.radioButton6.Location = new System.Drawing.Point(272, 24);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(66, 39);
            this.radioButton6.TabIndex = 6;
            this.radioButton6.Text = "Rectangle";
            this.radioButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // centreMap
            // 
            this.centreMap.Image = ((System.Drawing.Image)(resources.GetObject("centreMap.Image")));
            this.centreMap.Location = new System.Drawing.Point(186, 24);
            this.centreMap.Name = "centreMap";
            this.centreMap.Size = new System.Drawing.Size(80, 39);
            this.centreMap.TabIndex = 5;
            this.centreMap.Text = "Centre Map";
            this.centreMap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.centreMap.UseVisualStyleBackColor = true;
            this.centreMap.Click += new System.EventHandler(this.centreMap_Click);
            // 
            // radioButton5
            // 
            this.radioButton5.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton5.AutoSize = true;
            this.radioButton5.Image = ((System.Drawing.Image)(resources.GetObject("radioButton5.Image")));
            this.radioButton5.Location = new System.Drawing.Point(120, 24);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(60, 39);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "Move To";
            this.radioButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Image = ((System.Drawing.Image)(resources.GetObject("radioButton4.Image")));
            this.radioButton4.Location = new System.Drawing.Point(530, 24);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(68, 39);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Sprite Tool";
            this.radioButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Image = ((System.Drawing.Image)(resources.GetObject("radioButton3.Image")));
            this.radioButton3.Location = new System.Drawing.Point(429, 24);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(95, 39);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Connection Tool";
            this.radioButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Image = ((System.Drawing.Image)(resources.GetObject("radioButton2.Image")));
            this.radioButton2.Location = new System.Drawing.Point(70, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(44, 39);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Erase";
            this.radioButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Image = ((System.Drawing.Image)(resources.GetObject("radioButton1.Image")));
            this.radioButton1.Location = new System.Drawing.Point(6, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 39);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tile Tool";
            this.radioButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tilesListView
            // 
            this.tilesListView.AutoArrange = false;
            this.tilesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TileImage,
            this.TileID,
            this.TileName,
            this.IsExit,
            this.IsSender,
            this.IsReciver});
            this.tilesListView.FullRowSelect = true;
            this.tilesListView.GridLines = true;
            this.tilesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.tilesListView.HideSelection = false;
            this.tilesListView.Location = new System.Drawing.Point(352, 114);
            this.tilesListView.MultiSelect = false;
            this.tilesListView.Name = "tilesListView";
            this.tilesListView.Size = new System.Drawing.Size(376, 323);
            this.tilesListView.TabIndex = 3;
            this.tilesListView.UseCompatibleStateImageBehavior = false;
            this.tilesListView.View = System.Windows.Forms.View.Details;
            this.tilesListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // TileImage
            // 
            this.TileImage.Text = "Tile";
            this.TileImage.Width = 68;
            // 
            // TileID
            // 
            this.TileID.Text = "ID";
            this.TileID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TileID.Width = 38;
            // 
            // TileName
            // 
            this.TileName.Text = "Name";
            this.TileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TileName.Width = 108;
            // 
            // IsExit
            // 
            this.IsExit.Text = "IsExit";
            this.IsExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IsExit.Width = 39;
            // 
            // IsSender
            // 
            this.IsSender.Text = "IsSender";
            this.IsSender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IsSender.Width = 55;
            // 
            // IsReciver
            // 
            this.IsReciver.Text = "IsReciver";
            this.IsReciver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IsReciver.Width = 65;
            // 
            // spritesListView
            // 
            this.spritesListView.AutoArrange = false;
            this.spritesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spritesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Texture,
            this.SpriteID,
            this.SpriteName,
            this.SpriteHealth});
            this.spritesListView.FullRowSelect = true;
            this.spritesListView.GridLines = true;
            this.spritesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.spritesListView.HideSelection = false;
            this.spritesListView.Location = new System.Drawing.Point(423, 114);
            this.spritesListView.MultiSelect = false;
            this.spritesListView.Name = "spritesListView";
            this.spritesListView.Size = new System.Drawing.Size(305, 131);
            this.spritesListView.TabIndex = 4;
            this.spritesListView.UseCompatibleStateImageBehavior = false;
            this.spritesListView.View = System.Windows.Forms.View.Details;
            this.spritesListView.Visible = false;
            this.spritesListView.SelectedIndexChanged += new System.EventHandler(this.spritesListView_SelectedIndexChanged);
            // 
            // Texture
            // 
            this.Texture.Text = "";
            this.Texture.Width = 30;
            // 
            // SpriteID
            // 
            this.SpriteID.Text = "ID";
            this.SpriteID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SpriteID.Width = 40;
            // 
            // SpriteName
            // 
            this.SpriteName.Text = "Name";
            this.SpriteName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SpriteName.Width = 79;
            // 
            // SpriteHealth
            // 
            this.SpriteHealth.Text = "Health";
            this.SpriteHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // spritesPlacedListView
            // 
            this.spritesPlacedListView.AutoArrange = false;
            this.spritesPlacedListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spritesPlacedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SpritePicture,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.spritesPlaced_HealthColumn});
            this.spritesPlacedListView.FullRowSelect = true;
            this.spritesPlacedListView.GridLines = true;
            this.spritesPlacedListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.spritesPlacedListView.HideSelection = false;
            this.spritesPlacedListView.Location = new System.Drawing.Point(423, 251);
            this.spritesPlacedListView.MultiSelect = false;
            this.spritesPlacedListView.Name = "spritesPlacedListView";
            this.spritesPlacedListView.Size = new System.Drawing.Size(305, 186);
            this.spritesPlacedListView.TabIndex = 5;
            this.spritesPlacedListView.UseCompatibleStateImageBehavior = false;
            this.spritesPlacedListView.View = System.Windows.Forms.View.Details;
            this.spritesPlacedListView.Visible = false;
            this.spritesPlacedListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.spritesPlacedListView_ItemSelectionChanged);
            // 
            // SpritePicture
            // 
            this.SpritePicture.Text = "";
            this.SpritePicture.Width = 29;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 47;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "X";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 36;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Y";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 38;
            // 
            // spritesPlaced_HealthColumn
            // 
            this.spritesPlaced_HealthColumn.Text = "Health";
            // 
            // removeSprite
            // 
            this.removeSprite.Location = new System.Drawing.Point(352, 114);
            this.removeSprite.Name = "removeSprite";
            this.removeSprite.Size = new System.Drawing.Size(65, 42);
            this.removeSprite.TabIndex = 6;
            this.removeSprite.Text = "Remove Sprite";
            this.removeSprite.UseVisualStyleBackColor = true;
            this.removeSprite.Visible = false;
            this.removeSprite.Click += new System.EventHandler(this.removeSprite_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "h";
            this.saveFileDialog1.FileName = "Maps.h";
            this.saveFileDialog1.Filter = "C++ Header|*.h";
            // 
            // removeConnection
            // 
            this.removeConnection.Location = new System.Drawing.Point(352, 114);
            this.removeConnection.Name = "removeConnection";
            this.removeConnection.Size = new System.Drawing.Size(65, 42);
            this.removeConnection.TabIndex = 7;
            this.removeConnection.Text = "Remove Connector";
            this.removeConnection.UseVisualStyleBackColor = true;
            this.removeConnection.Visible = false;
            this.removeConnection.Click += new System.EventHandler(this.removeConnection_Click);
            // 
            // connectionListView
            // 
            this.connectionListView.AutoArrange = false;
            this.connectionListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.connectionListView.FullRowSelect = true;
            this.connectionListView.GridLines = true;
            this.connectionListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.connectionListView.HideSelection = false;
            this.connectionListView.Location = new System.Drawing.Point(423, 114);
            this.connectionListView.MultiSelect = false;
            this.connectionListView.Name = "connectionListView";
            this.connectionListView.Size = new System.Drawing.Size(305, 323);
            this.connectionListView.TabIndex = 8;
            this.connectionListView.UseCompatibleStateImageBehavior = false;
            this.connectionListView.View = System.Windows.Forms.View.Details;
            this.connectionListView.Visible = false;
            this.connectionListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.connectionListView_ItemSelectionChanged);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Valid";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "StartX";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "StartY";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "EndX";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "EndY";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(12, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 323);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "h";
            this.openFileDialog.FileName = "Maps.h";
            this.openFileDialog.Filter = "C++ Header|*.h";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentMapLabel,
            this.toolStripStatusLabel1,
            this.currentFileLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(740, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // currentMapLabel
            // 
            this.currentMapLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.currentMapLabel.Name = "currentMapLabel";
            this.currentMapLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(23, 17);
            this.toolStripStatusLabel1.Text = " in ";
            // 
            // currentFileLabel
            // 
            this.currentFileLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.currentFileLabel.Name = "currentFileLabel";
            this.currentFileLabel.Size = new System.Drawing.Size(74, 17);
            this.currentFileLabel.Text = "< New File >";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // spriteContextMenu
            // 
            this.spriteContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spriteContextMenu_FindInList,
            this.spriteContextMenu_Remove,
            this.toolStripMenuItem4});
            this.spriteContextMenu.Name = "spriteContextMenu";
            this.spriteContextMenu.Size = new System.Drawing.Size(132, 54);
            // 
            // spriteContextMenu_FindInList
            // 
            this.spriteContextMenu_FindInList.Enabled = false;
            this.spriteContextMenu_FindInList.Name = "spriteContextMenu_FindInList";
            this.spriteContextMenu_FindInList.Size = new System.Drawing.Size(131, 22);
            this.spriteContextMenu_FindInList.Text = "&Find In List";
            this.spriteContextMenu_FindInList.Click += new System.EventHandler(this.spriteContextMenu_FindInList_Click);
            // 
            // spriteContextMenu_Remove
            // 
            this.spriteContextMenu_Remove.Enabled = false;
            this.spriteContextMenu_Remove.Name = "spriteContextMenu_Remove";
            this.spriteContextMenu_Remove.Size = new System.Drawing.Size(131, 22);
            this.spriteContextMenu_Remove.Text = "&Remove";
            this.spriteContextMenu_Remove.Click += new System.EventHandler(this.spriteContextMenu_Remove_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(128, 6);
            // 
            // connectionContextMenu
            // 
            this.connectionContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionContextMenu_FindInList,
            this.connectionContextMenu_Remove});
            this.connectionContextMenu.Name = "connectionContextMenu";
            this.connectionContextMenu.Size = new System.Drawing.Size(132, 48);
            // 
            // connectionContextMenu_FindInList
            // 
            this.connectionContextMenu_FindInList.Enabled = false;
            this.connectionContextMenu_FindInList.Name = "connectionContextMenu_FindInList";
            this.connectionContextMenu_FindInList.Size = new System.Drawing.Size(131, 22);
            this.connectionContextMenu_FindInList.Text = "&Find In List";
            this.connectionContextMenu_FindInList.Click += new System.EventHandler(this.connectionContextMenu_FindInList_Click);
            // 
            // connectionContextMenu_Remove
            // 
            this.connectionContextMenu_Remove.Enabled = false;
            this.connectionContextMenu_Remove.Name = "connectionContextMenu_Remove";
            this.connectionContextMenu_Remove.Size = new System.Drawing.Size(131, 22);
            this.connectionContextMenu_Remove.Text = "&Remove";
            this.connectionContextMenu_Remove.Click += new System.EventHandler(this.connectionContextMenu_Remove_Click);
            // 
            // tilesContextMenu
            // 
            this.tilesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesContextMenu_FindInList,
            this.tilesContextMenu_Remove,
            this.toolStripMenuItem5});
            this.tilesContextMenu.Name = "tilesContextMenu";
            this.tilesContextMenu.Size = new System.Drawing.Size(132, 54);
            // 
            // tilesContextMenu_FindInList
            // 
            this.tilesContextMenu_FindInList.Enabled = false;
            this.tilesContextMenu_FindInList.Name = "tilesContextMenu_FindInList";
            this.tilesContextMenu_FindInList.Size = new System.Drawing.Size(131, 22);
            this.tilesContextMenu_FindInList.Text = "&Find In List";
            this.tilesContextMenu_FindInList.Click += new System.EventHandler(this.tilesContextMenu_FindInList_Click);
            // 
            // tilesContextMenu_Remove
            // 
            this.tilesContextMenu_Remove.Enabled = false;
            this.tilesContextMenu_Remove.Name = "tilesContextMenu_Remove";
            this.tilesContextMenu_Remove.Size = new System.Drawing.Size(131, 22);
            this.tilesContextMenu_Remove.Text = "&Remove";
            this.tilesContextMenu_Remove.Click += new System.EventHandler(this.tilesContextMenu_Remove_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(128, 6);
            // 
            // MapEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(740, 477);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.connectionListView);
            this.Controls.Add(this.removeConnection);
            this.Controls.Add(this.removeSprite);
            this.Controls.Add(this.spritesPlacedListView);
            this.Controls.Add(this.spritesListView);
            this.Controls.Add(this.tilesListView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MapEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rogue Level Editor";
            this.Load += new System.EventHandler(this.MapEditorForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.spriteContextMenu.ResumeLayout(false);
            this.connectionContextMenu.ResumeLayout(false);
            this.tilesContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMenu;
        private System.Windows.Forms.ToolStripMenuItem fileLoadMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem mapPropertysToolStripMenuItem;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ListView tilesListView;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Button centreMap;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.ColumnHeader TileID;
        private System.Windows.Forms.ColumnHeader TileName;
        private System.Windows.Forms.ColumnHeader TileImage;
        private System.Windows.Forms.ListView spritesListView;
        private System.Windows.Forms.ColumnHeader Texture;
        private System.Windows.Forms.ColumnHeader SpriteID;
        private System.Windows.Forms.ColumnHeader SpriteName;
        private System.Windows.Forms.ToolStripMenuItem mapsMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem FileExitMenu;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.ColumnHeader IsExit;
        private System.Windows.Forms.ColumnHeader IsSender;
        private System.Windows.Forms.ColumnHeader IsReciver;
        private System.Windows.Forms.ToolStripMenuItem viewTileMenu;
        private System.Windows.Forms.ToolStripMenuItem viewSpritesMenu;
        private System.Windows.Forms.ToolStripMenuItem viewConnectionsMenu;
        private System.Windows.Forms.ToolStripMenuItem viewPlayerStartMenu;
        private System.Windows.Forms.ColumnHeader SpritePicture;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.ListView spritesPlacedListView;
        private System.Windows.Forms.Button removeSprite;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button removeConnection;
        public System.Windows.Forms.ListView connectionListView;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ToolStripMenuItem mapAddMenu;
        private System.Windows.Forms.ToolStripMenuItem mapDeleteMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mapMoveUpMenu;
        private System.Windows.Forms.ToolStripMenuItem mapMoveDownMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAsMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripStatusLabel currentMapLabel;
        private System.Windows.Forms.ToolStripStatusLabel currentFileLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem viewOutOfBoundsMenu;
        private System.Windows.Forms.ColumnHeader spritesPlaced_HealthColumn;
        private System.Windows.Forms.ColumnHeader SpriteHealth;
        private System.Windows.Forms.RadioButton playerStartButton;
        private System.Windows.Forms.ContextMenuStrip spriteContextMenu;
        private System.Windows.Forms.ToolStripMenuItem spriteContextMenu_FindInList;
        private System.Windows.Forms.ToolStripMenuItem spriteContextMenu_Remove;
        private System.Windows.Forms.ContextMenuStrip connectionContextMenu;
        private System.Windows.Forms.ToolStripMenuItem connectionContextMenu_FindInList;
        private System.Windows.Forms.ToolStripMenuItem connectionContextMenu_Remove;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ContextMenuStrip tilesContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_FindInList;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_Remove;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    }
}