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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
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
            this.tilesContextMenu_Column = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu_ColumnInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu_ColumnMoveRight = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu_ColumnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu_ColumnMoveLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu_Row = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu_RowInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu_ColumnMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu_RowDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesContextMenu_ColumnMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.overallTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.currentMapLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentFileLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.modeFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.connectionFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.removeConnection = new System.Windows.Forms.Button();
            this.connectionListView = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spritesFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.removeSprite = new System.Windows.Forms.Button();
            this.spritesFlowPanelVert = new System.Windows.Forms.TableLayoutPanel();
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
            this.spritesPlaced_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tilesFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tilesListView = new System.Windows.Forms.ListView();
            this.TileImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TileID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsExit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsSender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsReciver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playerStartRadioButton = new System.Windows.Forms.RadioButton();
            this.edgeRadioButton = new System.Windows.Forms.RadioButton();
            this.rectangleRadioButton = new System.Windows.Forms.RadioButton();
            this.centreMap = new System.Windows.Forms.Button();
            this.moveToRadioButton = new System.Windows.Forms.RadioButton();
            this.spriteToolRadioButton = new System.Windows.Forms.RadioButton();
            this.connectionToolRadioButton = new System.Windows.Forms.RadioButton();
            this.eraseRadioButton = new System.Windows.Forms.RadioButton();
            this.tileToolRadioButton = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.spriteContextMenu.SuspendLayout();
            this.connectionContextMenu.SuspendLayout();
            this.tilesContextMenu.SuspendLayout();
            this.overallTableLayout.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.modeFlowPanel.SuspendLayout();
            this.connectionFlowPanel.SuspendLayout();
            this.spritesFlowPanel.SuspendLayout();
            this.spritesFlowPanelVert.SuspendLayout();
            this.tilesFlowPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.menuStrip1.Location = new System.Drawing.Point(4, 4);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1073, 33);
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
            this.fileMenu.Size = new System.Drawing.Size(50, 29);
            this.fileMenu.Text = "&File";
            // 
            // fileLoadMenu
            // 
            this.fileLoadMenu.Name = "fileLoadMenu";
            this.fileLoadMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.fileLoadMenu.Size = new System.Drawing.Size(225, 30);
            this.fileLoadMenu.Text = "Load";
            this.fileLoadMenu.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // fileSaveMenu
            // 
            this.fileSaveMenu.Name = "fileSaveMenu";
            this.fileSaveMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.fileSaveMenu.Size = new System.Drawing.Size(225, 30);
            this.fileSaveMenu.Text = "Save File";
            this.fileSaveMenu.Click += new System.EventHandler(this.fileSaveMenu_Click);
            // 
            // fileSaveAsMenu
            // 
            this.fileSaveAsMenu.Name = "fileSaveAsMenu";
            this.fileSaveAsMenu.Size = new System.Drawing.Size(225, 30);
            this.fileSaveAsMenu.Text = "Save File As ...";
            this.fileSaveAsMenu.Click += new System.EventHandler(this.fileSaveAsMenu_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(222, 6);
            // 
            // FileExitMenu
            // 
            this.FileExitMenu.Name = "FileExitMenu";
            this.FileExitMenu.Size = new System.Drawing.Size(225, 30);
            this.FileExitMenu.Text = "E&xit";
            this.FileExitMenu.Click += new System.EventHandler(this.fileExistMenu_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapPropertysToolStripMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(54, 29);
            this.editMenu.Text = "&Edit";
            // 
            // mapPropertysToolStripMenuItem
            // 
            this.mapPropertysToolStripMenuItem.Name = "mapPropertysToolStripMenuItem";
            this.mapPropertysToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mapPropertysToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
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
            this.viewMenu.Size = new System.Drawing.Size(61, 29);
            this.viewMenu.Text = "&View";
            // 
            // viewOutOfBoundsMenu
            // 
            this.viewOutOfBoundsMenu.Name = "viewOutOfBoundsMenu";
            this.viewOutOfBoundsMenu.Size = new System.Drawing.Size(216, 30);
            this.viewOutOfBoundsMenu.Text = "&Out Of Bounds";
            this.viewOutOfBoundsMenu.Click += new System.EventHandler(this.viewOutOfBoundsMenu_Click);
            // 
            // viewTileMenu
            // 
            this.viewTileMenu.Name = "viewTileMenu";
            this.viewTileMenu.Size = new System.Drawing.Size(216, 30);
            this.viewTileMenu.Text = "&Tiles";
            this.viewTileMenu.Click += new System.EventHandler(this.viewTileMenu_Click);
            // 
            // viewSpritesMenu
            // 
            this.viewSpritesMenu.Name = "viewSpritesMenu";
            this.viewSpritesMenu.Size = new System.Drawing.Size(216, 30);
            this.viewSpritesMenu.Text = "&Sprites";
            this.viewSpritesMenu.Click += new System.EventHandler(this.viewSpritesMenu_Click);
            // 
            // viewConnectionsMenu
            // 
            this.viewConnectionsMenu.Name = "viewConnectionsMenu";
            this.viewConnectionsMenu.Size = new System.Drawing.Size(216, 30);
            this.viewConnectionsMenu.Text = "&Connections";
            this.viewConnectionsMenu.Click += new System.EventHandler(this.viewConnectionsMenu_Click);
            // 
            // viewPlayerStartMenu
            // 
            this.viewPlayerStartMenu.Name = "viewPlayerStartMenu";
            this.viewPlayerStartMenu.Size = new System.Drawing.Size(216, 30);
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
            this.mapsMenu.Size = new System.Drawing.Size(68, 29);
            this.mapsMenu.Text = "&Maps";
            // 
            // mapAddMenu
            // 
            this.mapAddMenu.Name = "mapAddMenu";
            this.mapAddMenu.Size = new System.Drawing.Size(193, 30);
            this.mapAddMenu.Text = "&Add Map";
            this.mapAddMenu.Click += new System.EventHandler(this.mapAddMenu_Click);
            // 
            // mapDeleteMenu
            // 
            this.mapDeleteMenu.Name = "mapDeleteMenu";
            this.mapDeleteMenu.Size = new System.Drawing.Size(193, 30);
            this.mapDeleteMenu.Text = "&Delete Map";
            this.mapDeleteMenu.Click += new System.EventHandler(this.mapDeleteMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
            // 
            // mapMoveUpMenu
            // 
            this.mapMoveUpMenu.Name = "mapMoveUpMenu";
            this.mapMoveUpMenu.Size = new System.Drawing.Size(193, 30);
            this.mapMoveUpMenu.Tag = "KeepOpen";
            this.mapMoveUpMenu.Text = "Move &Up";
            this.mapMoveUpMenu.Click += new System.EventHandler(this.mapMoveUpMenu_Click);
            // 
            // mapMoveDownMenu
            // 
            this.mapMoveDownMenu.Name = "mapMoveDownMenu";
            this.mapMoveDownMenu.Size = new System.Drawing.Size(193, 30);
            this.mapMoveDownMenu.Tag = "KeepOpen";
            this.mapMoveDownMenu.Text = "Move &Down";
            this.mapMoveDownMenu.Click += new System.EventHandler(this.mapMoveDownMenu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(190, 6);
            // 
            // helpMenu
            // 
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(61, 29);
            this.helpMenu.Text = "&Help";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "h";
            this.saveFileDialog1.FileName = "Maps.h";
            this.saveFileDialog1.Filter = "C++ Header|*.h";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "h";
            this.openFileDialog.FileName = "Maps.h";
            this.openFileDialog.Filter = "C++ Header|*.h";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // spriteContextMenu
            // 
            this.spriteContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.spriteContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spriteContextMenu_FindInList,
            this.spriteContextMenu_Remove,
            this.toolStripMenuItem4});
            this.spriteContextMenu.Name = "spriteContextMenu";
            this.spriteContextMenu.Size = new System.Drawing.Size(170, 70);
            // 
            // spriteContextMenu_FindInList
            // 
            this.spriteContextMenu_FindInList.Enabled = false;
            this.spriteContextMenu_FindInList.Name = "spriteContextMenu_FindInList";
            this.spriteContextMenu_FindInList.Size = new System.Drawing.Size(169, 30);
            this.spriteContextMenu_FindInList.Text = "&Find In List";
            this.spriteContextMenu_FindInList.Click += new System.EventHandler(this.spriteContextMenu_FindInList_Click);
            // 
            // spriteContextMenu_Remove
            // 
            this.spriteContextMenu_Remove.Enabled = false;
            this.spriteContextMenu_Remove.Name = "spriteContextMenu_Remove";
            this.spriteContextMenu_Remove.Size = new System.Drawing.Size(169, 30);
            this.spriteContextMenu_Remove.Text = "&Remove";
            this.spriteContextMenu_Remove.Click += new System.EventHandler(this.spriteContextMenu_Remove_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(166, 6);
            // 
            // connectionContextMenu
            // 
            this.connectionContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.connectionContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionContextMenu_FindInList,
            this.connectionContextMenu_Remove});
            this.connectionContextMenu.Name = "connectionContextMenu";
            this.connectionContextMenu.Size = new System.Drawing.Size(170, 64);
            // 
            // connectionContextMenu_FindInList
            // 
            this.connectionContextMenu_FindInList.Enabled = false;
            this.connectionContextMenu_FindInList.Name = "connectionContextMenu_FindInList";
            this.connectionContextMenu_FindInList.Size = new System.Drawing.Size(169, 30);
            this.connectionContextMenu_FindInList.Text = "&Find In List";
            this.connectionContextMenu_FindInList.Click += new System.EventHandler(this.connectionContextMenu_FindInList_Click);
            // 
            // connectionContextMenu_Remove
            // 
            this.connectionContextMenu_Remove.Enabled = false;
            this.connectionContextMenu_Remove.Name = "connectionContextMenu_Remove";
            this.connectionContextMenu_Remove.Size = new System.Drawing.Size(169, 30);
            this.connectionContextMenu_Remove.Text = "&Remove";
            this.connectionContextMenu_Remove.Click += new System.EventHandler(this.connectionContextMenu_Remove_Click);
            // 
            // tilesContextMenu
            // 
            this.tilesContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tilesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesContextMenu_FindInList,
            this.tilesContextMenu_Remove,
            this.toolStripMenuItem5,
            this.tilesContextMenu_Column,
            this.tilesContextMenu_Row,
            this.toolStripMenuItem6});
            this.tilesContextMenu.Name = "tilesContextMenu";
            this.tilesContextMenu.Size = new System.Drawing.Size(170, 136);
            // 
            // tilesContextMenu_FindInList
            // 
            this.tilesContextMenu_FindInList.Enabled = false;
            this.tilesContextMenu_FindInList.Name = "tilesContextMenu_FindInList";
            this.tilesContextMenu_FindInList.Size = new System.Drawing.Size(169, 30);
            this.tilesContextMenu_FindInList.Text = "&Find In List";
            this.tilesContextMenu_FindInList.Click += new System.EventHandler(this.tilesContextMenu_FindInList_Click);
            // 
            // tilesContextMenu_Remove
            // 
            this.tilesContextMenu_Remove.Enabled = false;
            this.tilesContextMenu_Remove.Name = "tilesContextMenu_Remove";
            this.tilesContextMenu_Remove.Size = new System.Drawing.Size(169, 30);
            this.tilesContextMenu_Remove.Text = "&Remove";
            this.tilesContextMenu_Remove.Click += new System.EventHandler(this.tilesContextMenu_Remove_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(166, 6);
            // 
            // tilesContextMenu_Column
            // 
            this.tilesContextMenu_Column.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesContextMenu_ColumnInsert,
            this.tilesContextMenu_ColumnMoveRight,
            this.tilesContextMenu_ColumnDelete,
            this.tilesContextMenu_ColumnMoveLeft});
            this.tilesContextMenu_Column.Enabled = false;
            this.tilesContextMenu_Column.Name = "tilesContextMenu_Column";
            this.tilesContextMenu_Column.Size = new System.Drawing.Size(169, 30);
            this.tilesContextMenu_Column.Text = "&Column";
            // 
            // tilesContextMenu_ColumnInsert
            // 
            this.tilesContextMenu_ColumnInsert.Name = "tilesContextMenu_ColumnInsert";
            this.tilesContextMenu_ColumnInsert.Size = new System.Drawing.Size(259, 30);
            this.tilesContextMenu_ColumnInsert.Text = "&Insert (expand size)";
            this.tilesContextMenu_ColumnInsert.Click += new System.EventHandler(this.tilesContextMenu_ColumnInsert_Click);
            // 
            // tilesContextMenu_ColumnMoveRight
            // 
            this.tilesContextMenu_ColumnMoveRight.Name = "tilesContextMenu_ColumnMoveRight";
            this.tilesContextMenu_ColumnMoveRight.Size = new System.Drawing.Size(259, 30);
            this.tilesContextMenu_ColumnMoveRight.Text = "I&nsert (retain size)";
            this.tilesContextMenu_ColumnMoveRight.Click += new System.EventHandler(this.tilesContextMenu_ColumnMove_Click);
            // 
            // tilesContextMenu_ColumnDelete
            // 
            this.tilesContextMenu_ColumnDelete.Name = "tilesContextMenu_ColumnDelete";
            this.tilesContextMenu_ColumnDelete.Size = new System.Drawing.Size(259, 30);
            this.tilesContextMenu_ColumnDelete.Text = "&Delete (contract size)";
            this.tilesContextMenu_ColumnDelete.Click += new System.EventHandler(this.tilesContextMenu_ColumnDelete_Click);
            // 
            // tilesContextMenu_ColumnMoveLeft
            // 
            this.tilesContextMenu_ColumnMoveLeft.Name = "tilesContextMenu_ColumnMoveLeft";
            this.tilesContextMenu_ColumnMoveLeft.Size = new System.Drawing.Size(259, 30);
            this.tilesContextMenu_ColumnMoveLeft.Text = "D&elete (retain size)";
            this.tilesContextMenu_ColumnMoveLeft.Click += new System.EventHandler(this.tilesContextMenu_ColumnMoveLeft_Click);
            // 
            // tilesContextMenu_Row
            // 
            this.tilesContextMenu_Row.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesContextMenu_RowInsert,
            this.tilesContextMenu_ColumnMoveDown,
            this.tilesContextMenu_RowDelete,
            this.tilesContextMenu_ColumnMoveUp});
            this.tilesContextMenu_Row.Enabled = false;
            this.tilesContextMenu_Row.Name = "tilesContextMenu_Row";
            this.tilesContextMenu_Row.Size = new System.Drawing.Size(169, 30);
            this.tilesContextMenu_Row.Text = "&Row";
            // 
            // tilesContextMenu_RowInsert
            // 
            this.tilesContextMenu_RowInsert.Name = "tilesContextMenu_RowInsert";
            this.tilesContextMenu_RowInsert.Size = new System.Drawing.Size(259, 30);
            this.tilesContextMenu_RowInsert.Text = "&Insert (expand size)";
            this.tilesContextMenu_RowInsert.Click += new System.EventHandler(this.tilesContextMenu_RowInsert_Click);
            // 
            // tilesContextMenu_ColumnMoveDown
            // 
            this.tilesContextMenu_ColumnMoveDown.Name = "tilesContextMenu_ColumnMoveDown";
            this.tilesContextMenu_ColumnMoveDown.Size = new System.Drawing.Size(259, 30);
            this.tilesContextMenu_ColumnMoveDown.Text = "I&nsert (retain size)";
            this.tilesContextMenu_ColumnMoveDown.Click += new System.EventHandler(this.tilesContextMenu_RowMoveDown_Click);
            // 
            // tilesContextMenu_RowDelete
            // 
            this.tilesContextMenu_RowDelete.Name = "tilesContextMenu_RowDelete";
            this.tilesContextMenu_RowDelete.Size = new System.Drawing.Size(259, 30);
            this.tilesContextMenu_RowDelete.Text = "&Delete (contract size)";
            this.tilesContextMenu_RowDelete.Click += new System.EventHandler(this.tilesContextMenu_RowDelete_Click);
            // 
            // tilesContextMenu_ColumnMoveUp
            // 
            this.tilesContextMenu_ColumnMoveUp.Name = "tilesContextMenu_ColumnMoveUp";
            this.tilesContextMenu_ColumnMoveUp.Size = new System.Drawing.Size(259, 30);
            this.tilesContextMenu_ColumnMoveUp.Text = "D&elete (retain size)";
            this.tilesContextMenu_ColumnMoveUp.Click += new System.EventHandler(this.tilesContextMenu_RowMoveUp_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(166, 6);
            // 
            // overallTableLayout
            // 
            this.overallTableLayout.AutoSize = true;
            this.overallTableLayout.ColumnCount = 2;
            this.overallTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.overallTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.overallTableLayout.Controls.Add(this.statusStrip1, 0, 2);
            this.overallTableLayout.Controls.Add(this.pictureBox1, 0, 1);
            this.overallTableLayout.Controls.Add(this.modeFlowPanel, 1, 1);
            this.overallTableLayout.Controls.Add(this.groupBox1, 0, 0);
            this.overallTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overallTableLayout.Location = new System.Drawing.Point(4, 37);
            this.overallTableLayout.Name = "overallTableLayout";
            this.overallTableLayout.RowCount = 3;
            this.overallTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.overallTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.overallTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.overallTableLayout.Size = new System.Drawing.Size(1073, 656);
            this.overallTableLayout.TabIndex = 10;
            this.overallTableLayout.SizeChanged += new System.EventHandler(this.overallTableLayout_SizeChanged);
            // 
            // statusStrip1
            // 
            this.overallTableLayout.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentMapLabel,
            this.toolStripStatusLabel1,
            this.currentFileLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 633);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1073, 23);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // currentMapLabel
            // 
            this.currentMapLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.currentMapLabel.Name = "currentMapLabel";
            this.currentMapLabel.Size = new System.Drawing.Size(0, 18);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(36, 18);
            this.toolStripStatusLabel1.Text = " in ";
            // 
            // currentFileLabel
            // 
            this.currentFileLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.currentFileLabel.Name = "currentFileLabel";
            this.currentFileLabel.Size = new System.Drawing.Size(112, 18);
            this.currentFileLabel.Text = "< New File >";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(667, 557);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // modeFlowPanel
            // 
            this.modeFlowPanel.AutoSize = true;
            this.modeFlowPanel.Controls.Add(this.connectionFlowPanel);
            this.modeFlowPanel.Controls.Add(this.spritesFlowPanel);
            this.modeFlowPanel.Controls.Add(this.tilesFlowPanel);
            this.modeFlowPanel.Location = new System.Drawing.Point(673, 70);
            this.modeFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.modeFlowPanel.Name = "modeFlowPanel";
            this.modeFlowPanel.Size = new System.Drawing.Size(399, 464);
            this.modeFlowPanel.TabIndex = 12;
            // 
            // connectionFlowPanel
            // 
            this.connectionFlowPanel.AutoSize = true;
            this.connectionFlowPanel.Controls.Add(this.removeConnection);
            this.connectionFlowPanel.Controls.Add(this.connectionListView);
            this.connectionFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.connectionFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.connectionFlowPanel.Name = "connectionFlowPanel";
            this.connectionFlowPanel.Size = new System.Drawing.Size(326, 117);
            this.connectionFlowPanel.TabIndex = 20;
            this.connectionFlowPanel.Visible = false;
            // 
            // removeConnection
            // 
            this.removeConnection.Location = new System.Drawing.Point(3, 3);
            this.removeConnection.Name = "removeConnection";
            this.removeConnection.Size = new System.Drawing.Size(65, 42);
            this.removeConnection.TabIndex = 19;
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
            this.connectionListView.Location = new System.Drawing.Point(74, 3);
            this.connectionListView.MultiSelect = false;
            this.connectionListView.Name = "connectionListView";
            this.connectionListView.Size = new System.Drawing.Size(249, 111);
            this.connectionListView.TabIndex = 21;
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
            // spritesFlowPanel
            // 
            this.spritesFlowPanel.AutoSize = true;
            this.spritesFlowPanel.Controls.Add(this.removeSprite);
            this.spritesFlowPanel.Controls.Add(this.spritesFlowPanelVert);
            this.spritesFlowPanel.Location = new System.Drawing.Point(0, 117);
            this.spritesFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.spritesFlowPanel.Name = "spritesFlowPanel";
            this.spritesFlowPanel.Size = new System.Drawing.Size(351, 82);
            this.spritesFlowPanel.TabIndex = 21;
            // 
            // removeSprite
            // 
            this.removeSprite.Location = new System.Drawing.Point(3, 3);
            this.removeSprite.Name = "removeSprite";
            this.removeSprite.Size = new System.Drawing.Size(65, 42);
            this.removeSprite.TabIndex = 20;
            this.removeSprite.Text = "Remove Sprite";
            this.removeSprite.UseVisualStyleBackColor = true;
            this.removeSprite.Visible = false;
            this.removeSprite.Click += new System.EventHandler(this.removeSprite_Click);
            // 
            // spritesFlowPanelVert
            // 
            this.spritesFlowPanelVert.AutoSize = true;
            this.spritesFlowPanelVert.ColumnCount = 1;
            this.spritesFlowPanelVert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.spritesFlowPanelVert.Controls.Add(this.spritesListView, 0, 0);
            this.spritesFlowPanelVert.Controls.Add(this.spritesPlacedListView, 0, 1);
            this.spritesFlowPanelVert.Location = new System.Drawing.Point(71, 0);
            this.spritesFlowPanelVert.Margin = new System.Windows.Forms.Padding(0);
            this.spritesFlowPanelVert.Name = "spritesFlowPanelVert";
            this.spritesFlowPanelVert.RowCount = 2;
            this.spritesFlowPanelVert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.spritesFlowPanelVert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.spritesFlowPanelVert.Size = new System.Drawing.Size(280, 82);
            this.spritesFlowPanelVert.TabIndex = 21;
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
            this.spritesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritesListView.FullRowSelect = true;
            this.spritesListView.GridLines = true;
            this.spritesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.spritesListView.HideSelection = false;
            this.spritesListView.Location = new System.Drawing.Point(3, 3);
            this.spritesListView.MultiSelect = false;
            this.spritesListView.Name = "spritesListView";
            this.spritesListView.Size = new System.Drawing.Size(274, 35);
            this.spritesListView.TabIndex = 21;
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
            this.SpriteName.Width = 170;
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
            this.spritesPlaced_HealthColumn,
            this.spritesPlaced_Name});
            this.spritesPlacedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritesPlacedListView.FullRowSelect = true;
            this.spritesPlacedListView.GridLines = true;
            this.spritesPlacedListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.spritesPlacedListView.HideSelection = false;
            this.spritesPlacedListView.Location = new System.Drawing.Point(3, 44);
            this.spritesPlacedListView.MultiSelect = false;
            this.spritesPlacedListView.Name = "spritesPlacedListView";
            this.spritesPlacedListView.Size = new System.Drawing.Size(274, 35);
            this.spritesPlacedListView.TabIndex = 20;
            this.spritesPlacedListView.UseCompatibleStateImageBehavior = false;
            this.spritesPlacedListView.View = System.Windows.Forms.View.Details;
            this.spritesPlacedListView.Visible = false;
            this.spritesPlacedListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.spritesPlacedListView_ItemSelectionChanged);
            this.spritesPlacedListView.SelectedIndexChanged += new System.EventHandler(this.spritesListView_SelectedIndexChanged);
            // 
            // SpritePicture
            // 
            this.SpritePicture.Text = "";
            this.SpritePicture.Width = 30;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 40;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 3;
            this.columnHeader5.Text = "X";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 36;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 4;
            this.columnHeader6.Text = "Y";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 38;
            // 
            // spritesPlaced_HealthColumn
            // 
            this.spritesPlaced_HealthColumn.DisplayIndex = 5;
            this.spritesPlaced_HealthColumn.Text = "Health";
            // 
            // spritesPlaced_Name
            // 
            this.spritesPlaced_Name.DisplayIndex = 2;
            this.spritesPlaced_Name.Text = "Name";
            this.spritesPlaced_Name.Width = 96;
            // 
            // tilesFlowPanel
            // 
            this.tilesFlowPanel.Controls.Add(this.tilesListView);
            this.tilesFlowPanel.Location = new System.Drawing.Point(3, 202);
            this.tilesFlowPanel.Name = "tilesFlowPanel";
            this.tilesFlowPanel.Size = new System.Drawing.Size(393, 259);
            this.tilesFlowPanel.TabIndex = 22;
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
            this.tilesListView.Location = new System.Drawing.Point(0, 0);
            this.tilesListView.Margin = new System.Windows.Forms.Padding(0);
            this.tilesListView.MultiSelect = false;
            this.tilesListView.Name = "tilesListView";
            this.tilesListView.Size = new System.Drawing.Size(337, 239);
            this.tilesListView.TabIndex = 20;
            this.tilesListView.UseCompatibleStateImageBehavior = false;
            this.tilesListView.View = System.Windows.Forms.View.Details;
            this.tilesListView.SelectedIndexChanged += new System.EventHandler(this.tilesListView_SelectedIndexChanged);
            // 
            // TileImage
            // 
            this.TileImage.Text = "";
            this.TileImage.Width = 24;
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
            this.TileName.Width = 152;
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
            this.IsReciver.Text = "IsReceiver";
            this.IsReciver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IsReciver.Width = 65;
            // 
            // groupBox1
            // 
            this.overallTableLayout.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.playerStartRadioButton);
            this.groupBox1.Controls.Add(this.edgeRadioButton);
            this.groupBox1.Controls.Add(this.rectangleRadioButton);
            this.groupBox1.Controls.Add(this.centreMap);
            this.groupBox1.Controls.Add(this.moveToRadioButton);
            this.groupBox1.Controls.Add(this.spriteToolRadioButton);
            this.groupBox1.Controls.Add(this.connectionToolRadioButton);
            this.groupBox1.Controls.Add(this.eraseRadioButton);
            this.groupBox1.Controls.Add(this.tileToolRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 64);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // playerStartRadioButton
            // 
            this.playerStartRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.playerStartRadioButton.AutoSize = true;
            this.playerStartRadioButton.Image = global::RogueboyLevelEditor.Properties.Resources.Icon10;
            this.playerStartRadioButton.Location = new System.Drawing.Point(602, 14);
            this.playerStartRadioButton.Name = "playerStartRadioButton";
            this.playerStartRadioButton.Size = new System.Drawing.Size(101, 46);
            this.playerStartRadioButton.TabIndex = 8;
            this.playerStartRadioButton.Text = "Player Start";
            this.playerStartRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.playerStartRadioButton.UseVisualStyleBackColor = true;
            this.playerStartRadioButton.CheckedChanged += new System.EventHandler(this.playerStartRadioButton_CheckedChanged);
            // 
            // edgeRadioButton
            // 
            this.edgeRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.edgeRadioButton.AutoSize = true;
            this.edgeRadioButton.Image = global::RogueboyLevelEditor.Properties.Resources.Icon1;
            this.edgeRadioButton.Location = new System.Drawing.Point(344, 14);
            this.edgeRadioButton.Name = "edgeRadioButton";
            this.edgeRadioButton.Size = new System.Drawing.Size(57, 46);
            this.edgeRadioButton.TabIndex = 7;
            this.edgeRadioButton.Text = "Edge";
            this.edgeRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.edgeRadioButton.UseVisualStyleBackColor = true;
            this.edgeRadioButton.CheckedChanged += new System.EventHandler(this.edgeRadioButton_CheckedChanged);
            // 
            // rectangleRadioButton
            // 
            this.rectangleRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.rectangleRadioButton.AutoSize = true;
            this.rectangleRadioButton.Image = global::RogueboyLevelEditor.Properties.Resources.Icon7;
            this.rectangleRadioButton.Location = new System.Drawing.Point(272, 14);
            this.rectangleRadioButton.Name = "rectangleRadioButton";
            this.rectangleRadioButton.Size = new System.Drawing.Size(92, 46);
            this.rectangleRadioButton.TabIndex = 6;
            this.rectangleRadioButton.Text = "Rectangle";
            this.rectangleRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.rectangleRadioButton.UseVisualStyleBackColor = true;
            this.rectangleRadioButton.CheckedChanged += new System.EventHandler(this.rectangleRadioButton_CheckedChanged);
            // 
            // centreMap
            // 
            this.centreMap.Image = global::RogueboyLevelEditor.Properties.Resources.Icon6;
            this.centreMap.Location = new System.Drawing.Point(186, 14);
            this.centreMap.Name = "centreMap";
            this.centreMap.Size = new System.Drawing.Size(80, 39);
            this.centreMap.TabIndex = 5;
            this.centreMap.Text = "Centre Map";
            this.centreMap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.centreMap.UseVisualStyleBackColor = true;
            this.centreMap.Click += new System.EventHandler(this.centreMap_Click);
            // 
            // moveToRadioButton
            // 
            this.moveToRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.moveToRadioButton.AutoSize = true;
            this.moveToRadioButton.Image = global::RogueboyLevelEditor.Properties.Resources.Icon5;
            this.moveToRadioButton.Location = new System.Drawing.Point(120, 14);
            this.moveToRadioButton.Name = "moveToRadioButton";
            this.moveToRadioButton.Size = new System.Drawing.Size(79, 46);
            this.moveToRadioButton.TabIndex = 4;
            this.moveToRadioButton.Text = "Move To";
            this.moveToRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.moveToRadioButton.UseVisualStyleBackColor = true;
            this.moveToRadioButton.CheckedChanged += new System.EventHandler(this.moveToRadioButton_CheckedChanged);
            // 
            // spriteToolRadioButton
            // 
            this.spriteToolRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.spriteToolRadioButton.AutoSize = true;
            this.spriteToolRadioButton.Image = global::RogueboyLevelEditor.Properties.Resources.Icon9;
            this.spriteToolRadioButton.Location = new System.Drawing.Point(530, 14);
            this.spriteToolRadioButton.Name = "spriteToolRadioButton";
            this.spriteToolRadioButton.Size = new System.Drawing.Size(95, 46);
            this.spriteToolRadioButton.TabIndex = 3;
            this.spriteToolRadioButton.Text = "Sprite Tool";
            this.spriteToolRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.spriteToolRadioButton.UseVisualStyleBackColor = true;
            this.spriteToolRadioButton.CheckedChanged += new System.EventHandler(this.spriteToolRadioButton_CheckedChanged);
            // 
            // connectionToolRadioButton
            // 
            this.connectionToolRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.connectionToolRadioButton.AutoSize = true;
            this.connectionToolRadioButton.Image = global::RogueboyLevelEditor.Properties.Resources.Icon2;
            this.connectionToolRadioButton.Location = new System.Drawing.Point(429, 14);
            this.connectionToolRadioButton.Name = "connectionToolRadioButton";
            this.connectionToolRadioButton.Size = new System.Drawing.Size(134, 46);
            this.connectionToolRadioButton.TabIndex = 2;
            this.connectionToolRadioButton.Text = "Connection Tool";
            this.connectionToolRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.connectionToolRadioButton.UseVisualStyleBackColor = true;
            this.connectionToolRadioButton.CheckedChanged += new System.EventHandler(this.connectionToolRadioButton_CheckedChanged);
            // 
            // eraseRadioButton
            // 
            this.eraseRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.eraseRadioButton.AutoSize = true;
            this.eraseRadioButton.Image = global::RogueboyLevelEditor.Properties.Resources.Icon4;
            this.eraseRadioButton.Location = new System.Drawing.Point(70, 14);
            this.eraseRadioButton.Name = "eraseRadioButton";
            this.eraseRadioButton.Size = new System.Drawing.Size(61, 46);
            this.eraseRadioButton.TabIndex = 1;
            this.eraseRadioButton.Text = "Erase";
            this.eraseRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.eraseRadioButton.UseVisualStyleBackColor = true;
            this.eraseRadioButton.CheckedChanged += new System.EventHandler(this.eraseRadioButton_CheckedChanged);
            // 
            // tileToolRadioButton
            // 
            this.tileToolRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.tileToolRadioButton.AutoSize = true;
            this.tileToolRadioButton.Checked = true;
            this.tileToolRadioButton.Image = global::RogueboyLevelEditor.Properties.Resources.Icon3;
            this.tileToolRadioButton.Location = new System.Drawing.Point(6, 14);
            this.tileToolRadioButton.Name = "tileToolRadioButton";
            this.tileToolRadioButton.Size = new System.Drawing.Size(77, 46);
            this.tileToolRadioButton.TabIndex = 0;
            this.tileToolRadioButton.TabStop = true;
            this.tileToolRadioButton.Text = "Tile Tool";
            this.tileToolRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tileToolRadioButton.UseVisualStyleBackColor = true;
            this.tileToolRadioButton.CheckedChanged += new System.EventHandler(this.tileToolRadioButton_CheckedChanged);
            // 
            // MapEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1081, 697);
            this.Controls.Add(this.overallTableLayout);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapEditorForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dark Ritual Level Editor";
            this.Load += new System.EventHandler(this.MapEditorForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.spriteContextMenu.ResumeLayout(false);
            this.connectionContextMenu.ResumeLayout(false);
            this.tilesContextMenu.ResumeLayout(false);
            this.overallTableLayout.ResumeLayout(false);
            this.overallTableLayout.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.modeFlowPanel.ResumeLayout(false);
            this.modeFlowPanel.PerformLayout();
            this.connectionFlowPanel.ResumeLayout(false);
            this.spritesFlowPanel.ResumeLayout(false);
            this.spritesFlowPanel.PerformLayout();
            this.spritesFlowPanelVert.ResumeLayout(false);
            this.tilesFlowPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem mapsMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem FileExitMenu;
        private System.Windows.Forms.ToolStripMenuItem viewTileMenu;
        private System.Windows.Forms.ToolStripMenuItem viewSpritesMenu;
        private System.Windows.Forms.ToolStripMenuItem viewConnectionsMenu;
        private System.Windows.Forms.ToolStripMenuItem viewPlayerStartMenu;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem mapAddMenu;
        private System.Windows.Forms.ToolStripMenuItem mapDeleteMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mapMoveUpMenu;
        private System.Windows.Forms.ToolStripMenuItem mapMoveDownMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAsMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem viewOutOfBoundsMenu;
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
        private System.Windows.Forms.TableLayoutPanel overallTableLayout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton playerStartRadioButton;
        private System.Windows.Forms.RadioButton edgeRadioButton;
        private System.Windows.Forms.RadioButton rectangleRadioButton;
        private System.Windows.Forms.Button centreMap;
        private System.Windows.Forms.RadioButton moveToRadioButton;
        private System.Windows.Forms.RadioButton spriteToolRadioButton;
        private System.Windows.Forms.RadioButton connectionToolRadioButton;
        private System.Windows.Forms.RadioButton eraseRadioButton;
        private System.Windows.Forms.RadioButton tileToolRadioButton;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel modeFlowPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel currentMapLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel currentFileLabel;
        private System.Windows.Forms.FlowLayoutPanel connectionFlowPanel;
        private System.Windows.Forms.Button removeConnection;
        public System.Windows.Forms.ListView connectionListView;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.FlowLayoutPanel spritesFlowPanel;
        private System.Windows.Forms.Button removeSprite;
        private System.Windows.Forms.TableLayoutPanel spritesFlowPanelVert;
        private System.Windows.Forms.ListView spritesListView;
        private System.Windows.Forms.ColumnHeader Texture;
        private System.Windows.Forms.ColumnHeader SpriteID;
        private System.Windows.Forms.ColumnHeader SpriteName;
        private System.Windows.Forms.ColumnHeader SpriteHealth;
        public System.Windows.Forms.ListView spritesPlacedListView;
        private System.Windows.Forms.ColumnHeader SpritePicture;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader spritesPlaced_HealthColumn;
        private System.Windows.Forms.FlowLayoutPanel tilesFlowPanel;
        private System.Windows.Forms.ListView tilesListView;
        private System.Windows.Forms.ColumnHeader TileImage;
        private System.Windows.Forms.ColumnHeader TileID;
        private System.Windows.Forms.ColumnHeader TileName;
        private System.Windows.Forms.ColumnHeader IsExit;
        private System.Windows.Forms.ColumnHeader IsSender;
        private System.Windows.Forms.ColumnHeader IsReciver;
        private System.Windows.Forms.ColumnHeader spritesPlaced_Name;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_Column;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_Row;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_ColumnInsert;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_ColumnDelete;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_RowInsert;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_RowDelete;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_ColumnMoveRight;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_ColumnMoveLeft;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_ColumnMoveDown;
        private System.Windows.Forms.ToolStripMenuItem tilesContextMenu_ColumnMoveUp;
    }
}