using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        private TileMap currentMap;
        private TileSet currentTileSet;
        private DrawMode drawMode = DrawMode.Draw;

        private bool showGrid = false;
        public static float RATIO = 1f;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapDialog.ShowDialog();
            if (mapDialog.FileName != "")
                loadMap(mapDialog.FileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void loadMap(string mapPath)
        {
            if (currentTileSet == null)
            {
                MessageBox.Show("You must load a tile set first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(mapPath))
            {
                MessageBox.Show("There was an error getting the map file. The file does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentMap = new TileMap(mapPath, currentTileSet);
            panel1.Refresh();

        }

        public void loadTileSet(string tileSetPath, int tileSize, int rows, int cols)
        {
            if (!File.Exists(tileSetPath))
            {
                MessageBox.Show("There was an error getting the tile set file. The file does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentTileSet = new TileSet(tileSetPath, rows, cols, tileSize);
            lblNoTileset.Visible = false;

            tileSetPanel.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (currentMap != null && currentTileSet != null)
            {
                currentMap.render(e.Graphics);

                if (showGrid)
                {
                    int width = currentMap.getWidth();
                    int height = currentMap.getHeight();
                    int tileSize = currentTileSet.getTileSize();
                    Pen pen = new Pen(Brushes.Black);
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            Rectangle rect = new Rectangle(x * (int)(tileSize * RATIO), y * (int)(tileSize * RATIO), (int)(tileSize * RATIO), (int)(tileSize * RATIO));
                            e.Graphics.DrawRectangle(pen, rect);
                        }
                    }
                    pen.Dispose();
                }
            }
        }

        private void loadTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportTileSetDialog dialog = new ImportTileSetDialog(this);
            dialog.Show();
        }

        private int selectedTSTile = -1;
        private void tileSetPanel_Paint(object sender, PaintEventArgs e)
        {
            if (currentTileSet != null)
            {
                Graphics g = e.Graphics;

                int index = 0;
                int rows = currentTileSet.getRows();
                int cols = currentTileSet.getColumns();
                int tileSize = currentTileSet.getTileSize();
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        g.DrawImage(currentTileSet.getTile(index), new Point(x * tileSize, y * tileSize));
                        index++;
                    }
                }

                if (selectedTSTile != -1)
                {
                    Pen selectPen = new Pen(Brushes.Red);
                    int selectedTileY = (int)Math.Floor((double)selectedTSTile / cols);
                    int selectedTileX = selectedTSTile - (selectedTileY * cols);

                    Rectangle outline = new Rectangle((int)(selectedTileX * tileSize), (int)(selectedTileY * tileSize), (int)(tileSize), (int)(tileSize));
                    g.DrawRectangle(selectPen, outline);
                }

            }
        }

        private void tileSetPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            int x = (int)Math.Floor((double)(e.X / currentTileSet.getTileSize()));
            int y = (int)Math.Floor((double)(e.Y / currentTileSet.getTileSize()));

            this.selectedTSTile = ((currentTileSet.getColumns()) * y) + x;
            tileSetPanel.Refresh();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            int x = (int)Math.Floor((double)(e.X / (currentTileSet.getTileSize() * RATIO)));
            int y = (int)Math.Floor((double)(e.Y / (currentTileSet.getTileSize() * RATIO)));

            if (drawMode == DrawMode.Erase)
            {
                currentMap.tileMap[x, y] = 255;
                panel1.Refresh();
                return;
            }

            if (selectedTSTile != -1)
            {
                currentMap.tileMap[x, y] = selectedTSTile;
                panel1.Refresh();
            } 
        }

        private void tsBtnDrawMode_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.Draw;
            tsBtnDrawMode.Checked = true;
            tsBtnEraseMode.Checked = false;
        }

        private void tsBtnEraseMode_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.Erase;
            tsBtnDrawMode.Checked = false;
            tsBtnEraseMode.Checked = true;
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveMapDialog.ShowDialog();
            string fileName = saveMapDialog.FileName;

            if (fileName == "")
                return;

            int width = currentMap.getWidth();
            int height = currentMap.getHeight();
            Bitmap bitmap = new Bitmap(width, height);
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = Color.FromArgb(currentMap.tileMap[x, y], 0, 100);
                    bitmap.SetPixel(x, y, color);
                }
            }

            bitmap.Save(fileName, ImageFormat.Png);
            MessageBox.Show("Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            showGrid = !showGrid;
            tsBtnShowGrid.Checked = showGrid;
            panel1.Refresh();
        }

        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMap dialog = new NewMap(this);
            dialog.Show();
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tsBtnHalf.Checked = true;
            tsBtnFull.Checked = false;
            RATIO = 0.5f;
            panel1.Refresh();
        }

        private void tsBtnFull_Click(object sender, EventArgs e)
        {
            tsBtnHalf.Checked = false;
            tsBtnFull.Checked = true;
            RATIO = 1f;
            panel1.Refresh();
        }
    }
}
