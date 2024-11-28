
namespace LevelEditor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.lblNoTileset = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnDrawMode = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEraseMode = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCollisionMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnFull = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHalf = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxCollisionLayer = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxLayers = new System.Windows.Forms.CheckedListBox();
            this.btnDeleteLayer = new System.Windows.Forms.Button();
            this.btnAddLayer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tileSetPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapDialog = new System.Windows.Forms.OpenFileDialog();
            this.paintTimer = new System.Windows.Forms.Timer(this.components);
            this.saveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.drawPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drawPanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1511, 992);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level View";
            // 
            // drawPanel
            // 
            this.drawPanel.AutoScroll = true;
            this.drawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawPanel.Controls.Add(this.lblNoTileset);
            this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPanel.Location = new System.Drawing.Point(3, 16);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(1505, 973);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            this.drawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseUp);
            // 
            // lblNoTileset
            // 
            this.lblNoTileset.AutoSize = true;
            this.lblNoTileset.Location = new System.Drawing.Point(24, 23);
            this.lblNoTileset.Name = "lblNoTileset";
            this.lblNoTileset.Size = new System.Drawing.Size(171, 13);
            this.lblNoTileset.TabIndex = 0;
            this.lblNoTileset.Text = "There is currently no tile set loaded";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnDrawMode,
            this.tsBtnEraseMode,
            this.tsBtnCollisionMode,
            this.toolStripSeparator2,
            this.tsBtnShowGrid,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.tsBtnFull,
            this.tsBtnHalf});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1511, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnDrawMode
            // 
            this.tsBtnDrawMode.Image = global::LevelEditor.Properties.Resources._3643750_draw_edit_pencil_stationary_write_icon;
            this.tsBtnDrawMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDrawMode.Name = "tsBtnDrawMode";
            this.tsBtnDrawMode.Size = new System.Drawing.Size(88, 22);
            this.tsBtnDrawMode.Text = "Draw Mode";
            this.tsBtnDrawMode.Click += new System.EventHandler(this.tsBtnDrawMode_Click);
            // 
            // tsBtnEraseMode
            // 
            this.tsBtnEraseMode.Image = global::LevelEditor.Properties.Resources._9057100_erase_icon;
            this.tsBtnEraseMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEraseMode.Name = "tsBtnEraseMode";
            this.tsBtnEraseMode.Size = new System.Drawing.Size(88, 22);
            this.tsBtnEraseMode.Text = "Erase Mode";
            this.tsBtnEraseMode.Click += new System.EventHandler(this.tsBtnEraseMode_Click);
            // 
            // tsBtnCollisionMode
            // 
            this.tsBtnCollisionMode.Image = global::LevelEditor.Properties.Resources._8541731_car_crash_icon;
            this.tsBtnCollisionMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCollisionMode.Name = "tsBtnCollisionMode";
            this.tsBtnCollisionMode.Size = new System.Drawing.Size(107, 22);
            this.tsBtnCollisionMode.Text = "Collision Mode";
            this.tsBtnCollisionMode.Click += new System.EventHandler(this.tsBtnCollisionMode_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnShowGrid
            // 
            this.tsBtnShowGrid.Image = global::LevelEditor.Properties.Resources._185058_grid_lines_icon;
            this.tsBtnShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnShowGrid.Name = "tsBtnShowGrid";
            this.tsBtnShowGrid.Size = new System.Drawing.Size(81, 22);
            this.tsBtnShowGrid.Text = "Show Grid";
            this.tsBtnShowGrid.Click += new System.EventHandler(this.tsBtnShowGrid_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel1.Text = "Ratio";
            // 
            // tsBtnFull
            // 
            this.tsBtnFull.Checked = true;
            this.tsBtnFull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnFull.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnFull.Image")));
            this.tsBtnFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnFull.Name = "tsBtnFull";
            this.tsBtnFull.Size = new System.Drawing.Size(30, 22);
            this.tsBtnFull.Text = "Full";
            this.tsBtnFull.Click += new System.EventHandler(this.tsBtnFull_Click);
            // 
            // tsBtnHalf
            // 
            this.tsBtnHalf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnHalf.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnHalf.Image")));
            this.tsBtnHalf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHalf.Name = "tsBtnHalf";
            this.tsBtnHalf.Size = new System.Drawing.Size(28, 22);
            this.tsBtnHalf.Text = "1/2";
            this.tsBtnHalf.Click += new System.EventHandler(this.tsBtnHalf_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxCollisionLayer);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.listBoxLayers);
            this.groupBox3.Controls.Add(this.btnDeleteLayer);
            this.groupBox3.Controls.Add(this.btnAddLayer);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tileSetPanel);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 631);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1511, 410);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Toolbox";
            // 
            // listBoxCollisionLayer
            // 
            this.listBoxCollisionLayer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxCollisionLayer.FormattingEnabled = true;
            this.listBoxCollisionLayer.Items.AddRange(new object[] {
            "0: No Collision",
            "1: General Collisions",
            "2: Platform Collisions"});
            this.listBoxCollisionLayer.Location = new System.Drawing.Point(1210, 59);
            this.listBoxCollisionLayer.Name = "listBoxCollisionLayer";
            this.listBoxCollisionLayer.Size = new System.Drawing.Size(148, 277);
            this.listBoxCollisionLayer.TabIndex = 7;
            this.listBoxCollisionLayer.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxCollisionLayer_DrawItem);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1207, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Collision Layers";
            // 
            // listBoxLayers
            // 
            this.listBoxLayers.FormattingEnabled = true;
            this.listBoxLayers.Location = new System.Drawing.Point(811, 59);
            this.listBoxLayers.Name = "listBoxLayers";
            this.listBoxLayers.Size = new System.Drawing.Size(370, 274);
            this.listBoxLayers.TabIndex = 5;
            this.listBoxLayers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listBoxLayers_ItemCheck);
            this.listBoxLayers.SelectedIndexChanged += new System.EventHandler(this.listBoxLayers_SelectedIndexChanged);
            // 
            // btnDeleteLayer
            // 
            this.btnDeleteLayer.Enabled = false;
            this.btnDeleteLayer.Location = new System.Drawing.Point(1148, 342);
            this.btnDeleteLayer.Name = "btnDeleteLayer";
            this.btnDeleteLayer.Size = new System.Drawing.Size(33, 23);
            this.btnDeleteLayer.TabIndex = 4;
            this.btnDeleteLayer.Text = "-";
            this.btnDeleteLayer.UseVisualStyleBackColor = true;
            this.btnDeleteLayer.Click += new System.EventHandler(this.btnDeleteLayer_Click);
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.Enabled = false;
            this.btnAddLayer.Location = new System.Drawing.Point(1115, 342);
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Size = new System.Drawing.Size(33, 23);
            this.btnAddLayer.TabIndex = 3;
            this.btnAddLayer.Text = "+";
            this.btnAddLayer.UseVisualStyleBackColor = true;
            this.btnAddLayer.Click += new System.EventHandler(this.btnAddLayer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(806, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Layers";
            // 
            // tileSetPanel
            // 
            this.tileSetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileSetPanel.Location = new System.Drawing.Point(14, 30);
            this.tileSetPanel.Name = "tileSetPanel";
            this.tileSetPanel.Size = new System.Drawing.Size(783, 371);
            this.tileSetPanel.TabIndex = 0;
            this.tileSetPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tileSetPanel_Paint);
            this.tileSetPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tileSetPanel_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tilesetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1511, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.loadMapToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveMapToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "Map";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newMapToolStripMenuItem.Text = "New Map";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.newMapToolStripMenuItem_Click);
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadMapToolStripMenuItem.Text = "Load Map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Enabled = false;
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveMapToolStripMenuItem.Text = "Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // tilesetToolStripMenuItem
            // 
            this.tilesetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTilesetToolStripMenuItem});
            this.tilesetToolStripMenuItem.Name = "tilesetToolStripMenuItem";
            this.tilesetToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.tilesetToolStripMenuItem.Text = "Tileset";
            // 
            // loadTilesetToolStripMenuItem
            // 
            this.loadTilesetToolStripMenuItem.Name = "loadTilesetToolStripMenuItem";
            this.loadTilesetToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadTilesetToolStripMenuItem.Text = "Load Tileset";
            this.loadTilesetToolStripMenuItem.Click += new System.EventHandler(this.loadTilesetToolStripMenuItem_Click);
            // 
            // mapDialog
            // 
            this.mapDialog.Filter = "Tile Maps|*.png";
            this.mapDialog.Title = "Choose Map";
            // 
            // saveMapDialog
            // 
            this.saveMapDialog.Filter = "Tile Maps|*.png";
            this.saveMapDialog.Title = "Save Map";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 1041);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Sorcerers Level Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.drawPanel.ResumeLayout(false);
            this.drawPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.Label lblNoTileset;
        private System.Windows.Forms.ToolStripMenuItem tilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTilesetToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog mapDialog;
        private System.Windows.Forms.Timer paintTimer;
        private System.Windows.Forms.Panel tileSetPanel;
        private System.Windows.Forms.ToolStripButton tsBtnDrawMode;
        private System.Windows.Forms.ToolStripButton tsBtnEraseMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveMapDialog;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnShowGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsBtnFull;
        private System.Windows.Forms.ToolStripButton tsBtnHalf;
        private System.Windows.Forms.Button btnDeleteLayer;
        private System.Windows.Forms.Button btnAddLayer;
        private System.Windows.Forms.CheckedListBox listBoxLayers;
        private System.Windows.Forms.ToolStripButton tsBtnCollisionMode;
        private System.Windows.Forms.ListBox listBoxCollisionLayer;
        private System.Windows.Forms.Label label2;
    }
}

