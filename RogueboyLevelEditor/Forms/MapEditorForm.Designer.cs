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
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLoadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.FileExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mapPropertysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.eraseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.moveToMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPages = new System.Windows.Forms.TabControl();
            this.tabTileTool = new System.Windows.Forms.TabPage();
            this.tilesListView = new System.Windows.Forms.ListView();
            this.TileImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TileID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsExit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsSender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsReciver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabSpriteTool = new System.Windows.Forms.TabPage();
            this.spriteToolTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.spritesPlacedListView = new System.Windows.Forms.ListView();
            this.SpritePicture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spritesPlaced_HealthColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spritesPlaced_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spritesListView = new System.Windows.Forms.ListView();
            this.Texture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SpriteID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SpriteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SpriteHealth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeSprite = new System.Windows.Forms.Button();
            this.tabConnectionTool = new System.Windows.Forms.TabPage();
            this.connectionToolTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.connectionListView = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeConnection = new System.Windows.Forms.Button();
            this.tabPlayerStart = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.currentMapLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentFileLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tileToolMenu = new System.Windows.Forms.ToolStripButton();
            this.eraseMenu = new System.Windows.Forms.ToolStripButton();
            this.rectangleMenu = new System.Windows.Forms.ToolStripButton();
            this.moveToMenu = new System.Windows.Forms.ToolStripButton();
            this.centreMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.spriteToolMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.connectionToolMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.playerStartMenu = new System.Windows.Forms.ToolStripButton();
            this.ddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.xxx = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.spriteContextMenu.SuspendLayout();
            this.connectionContextMenu.SuspendLayout();
            this.tilesContextMenu.SuspendLayout();
            this.overallTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPages.SuspendLayout();
            this.tabTileTool.SuspendLayout();
            this.tabSpriteTool.SuspendLayout();
            this.spriteToolTableLayout.SuspendLayout();
            this.tabConnectionTool.SuspendLayout();
            this.connectionToolTableLayout.SuspendLayout();
            this.tabPlayerStart.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.mapPropertysToolStripMenuItem,
            this.toolStripMenuItem7,
            this.eraseMenuItem,
            this.rectangleMenuItem,
            this.toolStripMenuItem8,
            this.moveToMenuItem,
            this.centreMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(54, 29);
            this.editMenu.Text = "&Edit";
            // 
            // mapPropertysToolStripMenuItem
            // 
            this.mapPropertysToolStripMenuItem.Name = "mapPropertysToolStripMenuItem";
            this.mapPropertysToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mapPropertysToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.mapPropertysToolStripMenuItem.Text = "Map &Properties";
            this.mapPropertysToolStripMenuItem.Click += new System.EventHandler(this.mapPropertysToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(281, 6);
            // 
            // eraseMenuItem
            // 
            this.eraseMenuItem.Name = "eraseMenuItem";
            this.eraseMenuItem.Size = new System.Drawing.Size(284, 30);
            this.eraseMenuItem.Text = "&Erase";
            this.eraseMenuItem.Click += new System.EventHandler(this.eraseMenuItem_Click);
            // 
            // rectangleMenuItem
            // 
            this.rectangleMenuItem.Name = "rectangleMenuItem";
            this.rectangleMenuItem.Size = new System.Drawing.Size(284, 30);
            this.rectangleMenuItem.Text = "&Rectangle";
            this.rectangleMenuItem.Click += new System.EventHandler(this.rectangleMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(281, 6);
            // 
            // moveToMenuItem
            // 
            this.moveToMenuItem.Name = "moveToMenuItem";
            this.moveToMenuItem.Size = new System.Drawing.Size(284, 30);
            this.moveToMenuItem.Text = "&Move To";
            this.moveToMenuItem.Click += new System.EventHandler(this.moveToMenuItem_Click);
            // 
            // centreMenuItem
            // 
            this.centreMenuItem.Name = "centreMenuItem";
            this.centreMenuItem.Size = new System.Drawing.Size(284, 30);
            this.centreMenuItem.Text = "&Centre";
            this.centreMenuItem.Click += new System.EventHandler(this.centreMenuItem_Click);
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
            this.viewOutOfBoundsMenu.Visible = false;
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
            this.overallTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 412F));
            this.overallTableLayout.Controls.Add(this.statusStrip1, 0, 2);
            this.overallTableLayout.Controls.Add(this.pictureBox1, 0, 1);
            this.overallTableLayout.Controls.Add(this.tabPages, 1, 1);
            this.overallTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overallTableLayout.Location = new System.Drawing.Point(4, 4);
            this.overallTableLayout.Name = "overallTableLayout";
            this.overallTableLayout.RowCount = 3;
            this.overallTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.overallTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.overallTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.overallTableLayout.Size = new System.Drawing.Size(1141, 786);
            this.overallTableLayout.TabIndex = 10;
            this.overallTableLayout.SizeChanged += new System.EventHandler(this.overallTableLayout_SizeChanged);
            // 
            // statusStrip1
            // 
            this.overallTableLayout.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 764);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1141, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(723, 705);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // tabPages
            // 
            this.tabPages.Controls.Add(this.tabTileTool);
            this.tabPages.Controls.Add(this.tabSpriteTool);
            this.tabPages.Controls.Add(this.tabConnectionTool);
            this.tabPages.Controls.Add(this.tabPlayerStart);
            this.tabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPages.ImageList = this.tabImageList;
            this.tabPages.Location = new System.Drawing.Point(732, 55);
            this.tabPages.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(409, 706);
            this.tabPages.TabIndex = 15;
            this.tabPages.SelectedIndexChanged += new System.EventHandler(this.tabPages_SelectedIndexChanged);
            // 
            // tabTileTool
            // 
            this.tabTileTool.Controls.Add(this.tilesListView);
            this.tabTileTool.ImageIndex = 4;
            this.tabTileTool.Location = new System.Drawing.Point(4, 31);
            this.tabTileTool.Name = "tabTileTool";
            this.tabTileTool.Padding = new System.Windows.Forms.Padding(3);
            this.tabTileTool.Size = new System.Drawing.Size(401, 671);
            this.tabTileTool.TabIndex = 0;
            this.tabTileTool.Text = "Tiles  ";
            this.tabTileTool.UseVisualStyleBackColor = true;
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
            this.tilesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilesListView.FullRowSelect = true;
            this.tilesListView.GridLines = true;
            this.tilesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.tilesListView.HideSelection = false;
            this.tilesListView.Location = new System.Drawing.Point(3, 3);
            this.tilesListView.Margin = new System.Windows.Forms.Padding(0);
            this.tilesListView.MultiSelect = false;
            this.tilesListView.Name = "tilesListView";
            this.tilesListView.Size = new System.Drawing.Size(395, 665);
            this.tilesListView.TabIndex = 21;
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
            // tabSpriteTool
            // 
            this.tabSpriteTool.Controls.Add(this.spriteToolTableLayout);
            this.tabSpriteTool.ImageIndex = 5;
            this.tabSpriteTool.Location = new System.Drawing.Point(4, 31);
            this.tabSpriteTool.Name = "tabSpriteTool";
            this.tabSpriteTool.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpriteTool.Size = new System.Drawing.Size(401, 671);
            this.tabSpriteTool.TabIndex = 1;
            this.tabSpriteTool.Text = "Sprites  ";
            this.tabSpriteTool.UseVisualStyleBackColor = true;
            // 
            // spriteToolTableLayout
            // 
            this.spriteToolTableLayout.ColumnCount = 2;
            this.spriteToolTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.16628F));
            this.spriteToolTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.83372F));
            this.spriteToolTableLayout.Controls.Add(this.spritesPlacedListView, 1, 1);
            this.spriteToolTableLayout.Controls.Add(this.spritesListView, 1, 0);
            this.spriteToolTableLayout.Controls.Add(this.removeSprite, 0, 0);
            this.spriteToolTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spriteToolTableLayout.Location = new System.Drawing.Point(3, 3);
            this.spriteToolTableLayout.Name = "spriteToolTableLayout";
            this.spriteToolTableLayout.RowCount = 2;
            this.spriteToolTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.spriteToolTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.spriteToolTableLayout.Size = new System.Drawing.Size(395, 665);
            this.spriteToolTableLayout.TabIndex = 25;
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
            this.spritesPlacedListView.Location = new System.Drawing.Point(66, 335);
            this.spritesPlacedListView.MultiSelect = false;
            this.spritesPlacedListView.Name = "spritesPlacedListView";
            this.spritesPlacedListView.Size = new System.Drawing.Size(326, 327);
            this.spritesPlacedListView.TabIndex = 27;
            this.spritesPlacedListView.UseCompatibleStateImageBehavior = false;
            this.spritesPlacedListView.View = System.Windows.Forms.View.Details;
            this.spritesPlacedListView.Visible = false;
            this.spritesPlacedListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.spritesPlacedListView_ItemSelectionChanged);
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
            this.spritesListView.Location = new System.Drawing.Point(66, 3);
            this.spritesListView.MultiSelect = false;
            this.spritesListView.Name = "spritesListView";
            this.spritesListView.Size = new System.Drawing.Size(326, 326);
            this.spritesListView.TabIndex = 25;
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
            // removeSprite
            // 
            this.removeSprite.Location = new System.Drawing.Point(3, 3);
            this.removeSprite.Name = "removeSprite";
            this.removeSprite.Size = new System.Drawing.Size(57, 42);
            this.removeSprite.TabIndex = 24;
            this.removeSprite.Text = "Remove Sprite";
            this.removeSprite.UseVisualStyleBackColor = true;
            this.removeSprite.Visible = false;
            this.removeSprite.Click += new System.EventHandler(this.removeSprite_Click);
            // 
            // tabConnectionTool
            // 
            this.tabConnectionTool.Controls.Add(this.connectionToolTableLayout);
            this.tabConnectionTool.ImageIndex = 6;
            this.tabConnectionTool.Location = new System.Drawing.Point(4, 31);
            this.tabConnectionTool.Name = "tabConnectionTool";
            this.tabConnectionTool.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnectionTool.Size = new System.Drawing.Size(401, 671);
            this.tabConnectionTool.TabIndex = 2;
            this.tabConnectionTool.Text = "Connections  ";
            this.tabConnectionTool.UseVisualStyleBackColor = true;
            // 
            // connectionToolTableLayout
            // 
            this.connectionToolTableLayout.ColumnCount = 2;
            this.connectionToolTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.85912F));
            this.connectionToolTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.14088F));
            this.connectionToolTableLayout.Controls.Add(this.connectionListView, 1, 0);
            this.connectionToolTableLayout.Controls.Add(this.removeConnection, 0, 0);
            this.connectionToolTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionToolTableLayout.Location = new System.Drawing.Point(3, 3);
            this.connectionToolTableLayout.Name = "connectionToolTableLayout";
            this.connectionToolTableLayout.RowCount = 1;
            this.connectionToolTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.connectionToolTableLayout.Size = new System.Drawing.Size(395, 665);
            this.connectionToolTableLayout.TabIndex = 24;
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
            this.connectionListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionListView.FullRowSelect = true;
            this.connectionListView.GridLines = true;
            this.connectionListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.connectionListView.HideSelection = false;
            this.connectionListView.Location = new System.Drawing.Point(69, 3);
            this.connectionListView.MultiSelect = false;
            this.connectionListView.Name = "connectionListView";
            this.connectionListView.Size = new System.Drawing.Size(323, 659);
            this.connectionListView.TabIndex = 24;
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
            // removeConnection
            // 
            this.removeConnection.Location = new System.Drawing.Point(3, 3);
            this.removeConnection.Name = "removeConnection";
            this.removeConnection.Size = new System.Drawing.Size(60, 42);
            this.removeConnection.TabIndex = 23;
            this.removeConnection.Text = "Remove Connector";
            this.removeConnection.UseVisualStyleBackColor = true;
            this.removeConnection.Visible = false;
            this.removeConnection.Click += new System.EventHandler(this.removeConnection_Click);
            // 
            // tabPlayerStart
            // 
            this.tabPlayerStart.Controls.Add(this.label1);
            this.tabPlayerStart.ImageIndex = 7;
            this.tabPlayerStart.Location = new System.Drawing.Point(4, 31);
            this.tabPlayerStart.Name = "tabPlayerStart";
            this.tabPlayerStart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayerStart.Size = new System.Drawing.Size(401, 671);
            this.tabPlayerStart.TabIndex = 3;
            this.tabPlayerStart.Text = "Player Start  ";
            this.tabPlayerStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(101, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a starting position for the player on this level.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabImageList
            // 
            this.tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabImageList.ImageStream")));
            this.tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabImageList.Images.SetKeyName(0, "Icon3.png");
            this.tabImageList.Images.SetKeyName(1, "Icon9.png");
            this.tabImageList.Images.SetKeyName(2, "Icon2.png");
            this.tabImageList.Images.SetKeyName(3, "Icon10.png");
            this.tabImageList.Images.SetKeyName(4, "edit.png");
            this.tabImageList.Images.SetKeyName(5, "swiss-army-knife.png");
            this.tabImageList.Images.SetKeyName(6, "itinerary.png");
            this.tabImageList.Images.SetKeyName(7, "region-code.png");
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
            // toolStatusLabel
            // 
            this.toolStatusLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStatusLabel.Name = "toolStatusLabel";
            this.toolStatusLabel.Size = new System.Drawing.Size(747, 18);
            this.toolStatusLabel.Spring = true;
            this.toolStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tileToolMenu
            // 
            this.tileToolMenu.Image = global::RogueboyLevelEditor.Properties.Resources.tiles;
            this.tileToolMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tileToolMenu.Name = "tileToolMenu";
            this.tileToolMenu.Size = new System.Drawing.Size(74, 29);
            this.tileToolMenu.Text = "&Tiles";
            this.tileToolMenu.Click += new System.EventHandler(this.tileToolMenu_Click);
            // 
            // eraseMenu
            // 
            this.eraseMenu.Image = global::RogueboyLevelEditor.Properties.Resources.erase;
            this.eraseMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraseMenu.Name = "eraseMenu";
            this.eraseMenu.Size = new System.Drawing.Size(81, 29);
            this.eraseMenu.Text = "Erase";
            this.eraseMenu.Click += new System.EventHandler(this.eraseMenu_Click);
            // 
            // rectangleMenu
            // 
            this.rectangleMenu.Image = global::RogueboyLevelEditor.Properties.Resources.Icon7;
            this.rectangleMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleMenu.Name = "rectangleMenu";
            this.rectangleMenu.Size = new System.Drawing.Size(116, 29);
            this.rectangleMenu.Text = "Rectangle";
            this.rectangleMenu.Click += new System.EventHandler(this.rectangleMenu_Click);
            // 
            // moveToMenu
            // 
            this.moveToMenu.Image = global::RogueboyLevelEditor.Properties.Resources.move;
            this.moveToMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveToMenu.Name = "moveToMenu";
            this.moveToMenu.Size = new System.Drawing.Size(108, 29);
            this.moveToMenu.Text = "Move To";
            this.moveToMenu.Click += new System.EventHandler(this.moveToMenu_Click);
            // 
            // centreMenu
            // 
            this.centreMenu.Image = global::RogueboyLevelEditor.Properties.Resources.centre;
            this.centreMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.centreMenu.Name = "centreMenu";
            this.centreMenu.Size = new System.Drawing.Size(91, 29);
            this.centreMenu.Text = "Centre";
            this.centreMenu.Click += new System.EventHandler(this.centreMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // spriteToolMenu
            // 
            this.spriteToolMenu.Image = global::RogueboyLevelEditor.Properties.Resources.sprites;
            this.spriteToolMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spriteToolMenu.Name = "spriteToolMenu";
            this.spriteToolMenu.Size = new System.Drawing.Size(94, 29);
            this.spriteToolMenu.Text = "&Sprites";
            this.spriteToolMenu.Click += new System.EventHandler(this.spriteToolMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // connectionToolMenu
            // 
            this.connectionToolMenu.Image = global::RogueboyLevelEditor.Properties.Resources.connection;
            this.connectionToolMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectionToolMenu.Name = "connectionToolMenu";
            this.connectionToolMenu.Size = new System.Drawing.Size(138, 29);
            this.connectionToolMenu.Text = "&Connections";
            this.connectionToolMenu.Click += new System.EventHandler(this.connectionToolMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // playerStartMenu
            // 
            this.playerStartMenu.Image = global::RogueboyLevelEditor.Properties.Resources.playerStart;
            this.playerStartMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playerStartMenu.Name = "playerStartMenu";
            this.playerStartMenu.Size = new System.Drawing.Size(128, 29);
            this.playerStartMenu.Text = "&Player Start";
            this.playerStartMenu.Click += new System.EventHandler(this.playerStartMenu_Click);
            // 
            // ddToolStripMenuItem
            // 
            this.ddToolStripMenuItem.Name = "ddToolStripMenuItem";
            this.ddToolStripMenuItem.Size = new System.Drawing.Size(46, 29);
            this.ddToolStripMenuItem.Text = "dd";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.mapsMenu,
            this.helpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(4, 4);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1141, 33);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileToolMenu,
            this.eraseMenu,
            this.rectangleMenu,
            this.moveToMenu,
            this.centreMenu,
            this.toolStripSeparator1,
            this.spriteToolMenu,
            this.toolStripSeparator2,
            this.connectionToolMenu,
            this.toolStripSeparator3,
            this.playerStartMenu});
            this.toolStrip1.Location = new System.Drawing.Point(4, 37);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1141, 32);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // xxx
            // 
            this.xxx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xxx.Image = ((System.Drawing.Image)(resources.GetObject("xxx.Image")));
            this.xxx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.xxx.Name = "xxx";
            this.xxx.Size = new System.Drawing.Size(28, 28);
            this.xxx.Text = "toolStripButton1";
            // 
            // MapEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1149, 794);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.overallTableLayout);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(830, 530);
            this.Name = "MapEditorForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dark Ritual Level Editor";
            this.Load += new System.EventHandler(this.MapEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.spriteContextMenu.ResumeLayout(false);
            this.connectionContextMenu.ResumeLayout(false);
            this.tilesContextMenu.ResumeLayout(false);
            this.overallTableLayout.ResumeLayout(false);
            this.overallTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPages.ResumeLayout(false);
            this.tabTileTool.ResumeLayout(false);
            this.tabSpriteTool.ResumeLayout(false);
            this.spriteToolTableLayout.ResumeLayout(false);
            this.tabConnectionTool.ResumeLayout(false);
            this.connectionToolTableLayout.ResumeLayout(false);
            this.tabPlayerStart.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel currentMapLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel currentFileLabel;
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
        private System.Windows.Forms.TabControl tabPages;
        private System.Windows.Forms.TabPage tabTileTool;
        private System.Windows.Forms.ListView tilesListView;
        private System.Windows.Forms.ColumnHeader TileImage;
        private System.Windows.Forms.ColumnHeader TileID;
        private System.Windows.Forms.ColumnHeader TileName;
        private System.Windows.Forms.ColumnHeader IsExit;
        private System.Windows.Forms.ColumnHeader IsSender;
        private System.Windows.Forms.ColumnHeader IsReciver;
        private System.Windows.Forms.TabPage tabSpriteTool;
        private System.Windows.Forms.TabPage tabConnectionTool;
        private System.Windows.Forms.TableLayoutPanel spriteToolTableLayout;
        public System.Windows.Forms.ListView spritesPlacedListView;
        private System.Windows.Forms.ColumnHeader SpritePicture;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader spritesPlaced_HealthColumn;
        private System.Windows.Forms.ColumnHeader spritesPlaced_Name;
        private System.Windows.Forms.ListView spritesListView;
        private System.Windows.Forms.ColumnHeader Texture;
        private System.Windows.Forms.ColumnHeader SpriteID;
        private System.Windows.Forms.ColumnHeader SpriteName;
        private System.Windows.Forms.ColumnHeader SpriteHealth;
        private System.Windows.Forms.Button removeSprite;
        private System.Windows.Forms.TableLayoutPanel connectionToolTableLayout;
        public System.Windows.Forms.ListView connectionListView;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button removeConnection;
        private System.Windows.Forms.TabPage tabPlayerStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tileToolMenu;
        private System.Windows.Forms.ToolStripButton spriteToolMenu;
        private System.Windows.Forms.ToolStripButton connectionToolMenu;
        private System.Windows.Forms.ToolStripButton eraseMenu;
        private System.Windows.Forms.ToolStripButton playerStartMenu;
        private System.Windows.Forms.ToolStripButton moveToMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton centreMenu;
        private System.Windows.Forms.ToolStripButton rectangleMenu;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem eraseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleMenuItem;
        private System.Windows.Forms.ImageList tabImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem moveToMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centreMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ddToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton xxx;
    }
}