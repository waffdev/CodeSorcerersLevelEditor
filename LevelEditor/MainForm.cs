using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace LevelEditor
{
    /// <summary>
    /// 
    /// Main Form
    /// 
    /// This program is a level editor for games by Code Sourcerers
    /// for University projects.
    /// 
    /// This code is public and open source however all games created currently remain private.
    /// By James Hammett
    /// </summary>
    public partial class MainForm : Form
    {
        // Objects for maps, tilesets and the current draw mode
        private TileMap currentMap;
        private TileSet currentTileSet;
        public static DrawMode drawMode = DrawMode.Draw;

        // Display variables
        private bool showGrid = false;
        public static float RATIO = 1f;
        public static bool[] visibleLayers = new bool[2];

        // Currently selected tile index from the tile set
        private int selectedTSTile = -1;

        // String Constants
        private const string ERR_NO_TILESET_LOADED = "There is currently no loaded tileset.\nPlease load a tileset before attempting to create/load a map.";
        private const string ERR_LOADMAP_EXISTS = "There was an error getting the map file. The file does not exist";
        private const string ERR_LOADTILESET_EXISTS = "There was an error getting the tile set file. The file does not exist";
        private const string ERR_MAPS_MUST_BE_SAVED_AS_PNG = "Tile maps must be saved as .png format.";
        private const string WARN_AYS_DELETE_LAYER = "Are you sure you want to delete layer: {0}? This operation cannot be undone.";
        private const string INFO_SAVED = "Saved.";

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click event for the Load Map menu item.
        /// </summary>
        /// <param name="sender">Instance of the menu item</param>
        /// <param name="e">Event arguments</param>
        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapDialog.ShowDialog();
            if (mapDialog.FileName != "")
                loadMap(mapDialog.FileName);
        }

        /// <summary>
        /// Load event for the form
        /// </summary>
        /// <param name="sender">Instance of the form</param>
        /// <param name="e">Event arguments</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            tsBtnDrawMode.Checked = true;
            listBoxCollisionLayer.SelectedIndex = 0;
        }

        /// <summary>
        /// This method loads a map from the specified path
        /// </summary>
        /// <param name="mapPath">Path to the map file</param>
        public void loadMap(string mapPath)
        {
            // Error checking
            if (currentTileSet == null)
            {
                MessageBox.Show(ERR_NO_TILESET_LOADED, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(mapPath))
            {
                MessageBox.Show(ERR_LOADMAP_EXISTS, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create new tile map and prepare the form
            currentMap = new TileMap(mapPath, currentTileSet);
            drawPanel.Refresh();
            refreshLayerSelector(true);
            saveMapToolStripMenuItem.Enabled = true;

        }

        /// <summary>
        /// This method loads a tile set file with the specified parameters
        /// </summary>
        /// <param name="tileSetPath">The path to the tile set file</param>
        /// <param name="tileSize">The tile size</param>
        /// <param name="rows">How many rows are in the tile set</param>
        /// <param name="cols">How many columns are in the tile set</param>
        public void loadTileSet(string tileSetPath, int tileSize, int rows, int cols)
        {
            // Error checking
            if (!File.Exists(tileSetPath))
            {
                MessageBox.Show(ERR_LOADTILESET_EXISTS, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Create new tile set and prepare the form
            currentTileSet = new TileSet(tileSetPath, rows, cols, tileSize);
            lblNoTileset.Visible = false;

            tileSetPanel.Refresh();
        }

        /// <summary>
        /// Paint event for the main drawing panel
        /// </summary>
        /// <param name="sender">Instance of the panel</param>
        /// <param name="e">Event arguments</param>
        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            // Check if there is currently a map loaded
            // Also check that there is currently a tile set loaded
            if (currentMap != null && currentTileSet != null)
            {
                // Call render method for the tile map. All rendering handled in this method
                currentMap.render(e.Graphics);

                // If grid drawing is enabled, draw a black wireframe grid.
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

        /// <summary>
        /// Click event for the import tile set menu item
        /// </summary>
        /// <param name="sender">Instance of the menu item</param>
        /// <param name="e">Event arguments</param>
        private void loadTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the import tile set dialog
            ImportTileSetDialog dialog = new ImportTileSetDialog(this);
            dialog.Show();
        }

        /// <summary>
        /// Paint event for the tile set panel
        /// </summary>
        /// <param name="sender">Instance of the tile set panel</param>
        /// <param name="e">Event arguments</param>
        private void tileSetPanel_Paint(object sender, PaintEventArgs e)
        {
            // Check if a tile set is loaded
            if (currentTileSet != null)
            {
                Graphics g = e.Graphics;

                // Current tile index within the tile set
                int index = 0;

                // Tile set dimensions
                int rows = currentTileSet.getRows();
                int cols = currentTileSet.getColumns();
                int tileSize = currentTileSet.getTileSize();

                // Draw tile set chooser
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        g.DrawImage(currentTileSet.getTile(index), new Point(x * tileSize, y * tileSize));
                        index++;
                    }
                }

                // If a tile is selected, draw the red selection square
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

        /// <summary>
        /// Click event on the tile set panel for selecting a tile
        /// </summary>
        /// <param name="sender">Instance of the tile set panel</param>
        /// <param name="e">Event arguments</param>
        private void tileSetPanel_MouseUp(object sender, MouseEventArgs e)
        {
            // Ensure the click is a left-click
            if (e.Button != MouseButtons.Left)
                return;

            // Ensure a tile set is loaded
            if (currentTileSet == null)
                return;

            // Locate the point of which the click occurred
            int x = (int)Math.Floor((double)(e.X / currentTileSet.getTileSize()));
            int y = (int)Math.Floor((double)(e.Y / currentTileSet.getTileSize()));

            // Update the selected tile and repaint the panel
            this.selectedTSTile = ((currentTileSet.getColumns()) * y) + x;
            tileSetPanel.Refresh();
        }

        /// <summary>
        /// Click event on the draw panel
        /// </summary>
        /// <param name="sender">Instance of the draw panel</param>
        /// <param name="e">Event arguments</param>
        private void drawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            // Ensure the click is a left-click
            if (e.Button != MouseButtons.Left)
                return;

            // Prevent drawing on invisible layers
            if (!listBoxLayers.CheckedItems.Contains(listBoxLayers.SelectedItem))
                return;

            // Locate the point of which the click occurred
            int x = (int)Math.Floor((double)(e.X / (currentTileSet.getTileSize() * RATIO)));
            int y = (int)Math.Floor((double)(e.Y / (currentTileSet.getTileSize() * RATIO)));

            // Check the draw mode
            if (drawMode == DrawMode.Erase)
            {
                // Erase to a transparent tile (index: 255)
                currentMap.tileMapLayers[listBoxLayers.SelectedIndex][x, y] = 255;
                drawPanel.Refresh();
            }else if (drawMode == DrawMode.Collision)
            {
                // Modify the tile's collision property based on selected collision layer
                currentMap.collisionLayer[x, y] = listBoxCollisionLayer.SelectedIndex;
                drawPanel.Refresh();
            }else if (drawMode == DrawMode.Draw)
            {
                // Check a tile is selected from the tile set
                if (selectedTSTile != -1)
                {
                    currentMap.tileMapLayers[listBoxLayers.SelectedIndex][x, y] = selectedTSTile;
                    drawPanel.Refresh();
                }  
            } 
        }

        /// <summary>
        /// Click event to switch to draw mode
        /// </summary>
        /// <param name="sender">Instance of the menu item</param>
        /// <param name="e">Event arguments</param>
        private void tsBtnDrawMode_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.Draw;
            tsBtnDrawMode.Checked = true;
            tsBtnEraseMode.Checked = false;
            tsBtnCollisionMode.Checked = false;

            drawPanel.Refresh();
        }

        /// <summary>
        /// Click event to switch to erase mode
        /// </summary>
        /// <param name="sender">Instance of the menu item</param>
        /// <param name="e">Event arguments</param>
        private void tsBtnEraseMode_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.Erase;
            tsBtnDrawMode.Checked = false;
            tsBtnEraseMode.Checked = true;
            tsBtnCollisionMode.Checked = false;

            drawPanel.Refresh();
        }

        /// <summary>
        /// Click event to switch to collision mode
        /// </summary>
        /// <param name="sender">Instance of the menu item</param>
        /// <param name="e">Event arguments</param>
        private void tsBtnCollisionMode_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.Collision;
            tsBtnDrawMode.Checked = false;
            tsBtnEraseMode.Checked = false;
            tsBtnCollisionMode.Checked = true;

            drawPanel.Refresh();
        }

        /// <summary>
        /// Click event to save the tile map
        /// </summary>
        /// <param name="sender">Instance of the menu item</param>
        /// <param name="e">Event arguments</param>
        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show save dialog
            saveMapDialog.ShowDialog();
            string fileName = saveMapDialog.FileName;

            // Ensure file name is not blank
            if (fileName == "")
                return;

            // Error check incorrect format
            if (!fileName.Contains(".png") || !fileName.Contains(".PNG"))
            {
                MessageBox.Show(ERR_MAPS_MUST_BE_SAVED_AS_PNG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Remove potential suffixes
            fileName = fileName.Replace("0.png", "");
            fileName = fileName.Replace(".png", "");

            int width = currentMap.getWidth();
            int height = currentMap.getHeight();

            // Draw each pixel with correct tile value
            int layerIndex = 0;
            foreach (int[,] tileMapLayer in currentMap.tileMapLayers)
            {
                Bitmap bitmap = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Default collision value (if not on layer 0)
                        int blueValue = 100;

                        // If on layer 0, modify the BLUE value to the appropriate collision layer index
                        if (layerIndex == 0)
                            blueValue = currentMap.collisionLayer[x, y];

                        Color color = Color.FromArgb(currentMap.tileMapLayers[layerIndex][x, y], 0, blueValue);
                        bitmap.SetPixel(x, y, color);
                    }
                }

                // Save the image
                bitmap.Save(fileName + layerIndex + ".png", ImageFormat.Png);
                layerIndex++;
            }

            MessageBox.Show(INFO_SAVED, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Click event for the Show Grid menu item
        /// </summary>
        /// <param name="sender">Instance of the menu item</param>
        /// <param name="e">Event arguments</param>
        private void tsBtnShowGrid_Click(object sender, EventArgs e)
        {
            // Toggle show grid
            showGrid = !showGrid;
            tsBtnShowGrid.Checked = showGrid;
            drawPanel.Refresh();
        }

        /// <summary>
        /// Click event for the new map menu item
        /// </summary>
        /// <param name="sender">Instance of the menu item</param>
        /// <param name="e">Event arguments</param>
        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ensure a tile set is loaded
            if (currentTileSet == null)
            {
                MessageBox.Show(ERR_NO_TILESET_LOADED, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show new map dialog
            NewMap dialog = new NewMap(this);
            dialog.Show();
            
        }

        /// <summary>
        /// Click event for the half ratio menu item
        /// </summary>
        /// <param name="sender">Instance of the menu item</param>
        /// <param name="e">Event arguments</param>
        private void tsBtnHalf_Click(object sender, EventArgs e)
        {
            tsBtnHalf.Checked = true;
            tsBtnFull.Checked = false;
            RATIO = 0.5f;
            drawPanel.Refresh();
        }

        /// <summary>
        /// Click event for the full ratio menu item
        /// </summary>
        /// <param name="sender">Instance of the menu item</param>
        /// <param name="e">Event arguments</param>
        private void tsBtnFull_Click(object sender, EventArgs e)
        {
            tsBtnHalf.Checked = false;
            tsBtnFull.Checked = true;
            RATIO = 1f;
            drawPanel.Refresh();
        }

        /// <summary>
        /// Click event for the add layer button
        /// </summary>
        /// <param name="sender">Instance of the add layer button</param>
        /// <param name="e">Event arguments</param>
        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            // Create an empty tile map layer
            int[,] emptyTileMap = new int[currentMap.getWidth(), currentMap.getHeight()];
            for (int x = 0; x < currentMap.getWidth(); x++)
            {
                for (int y = 0; y < currentMap.getHeight(); y++)
                {
                    emptyTileMap[x,y] = 255;
                }
            }

            // Add the layer to the layer list, refresh the layers list and redraw the map
            currentMap.tileMapLayers.Add(emptyTileMap);
            refreshLayerSelector(false);
            drawPanel.Refresh();
        }

        /// <summary>
        /// Click event for the delete layer button
        /// </summary>
        /// <param name="sender">Instance of the delete layer button</param>
        /// <param name="e">Event arguments</param>
        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            // Check if the user is sure they want to delete the layer
            int selectedIndex = listBoxLayers.SelectedIndex;
            DialogResult result = MessageBox.Show(String.Format(WARN_AYS_DELETE_LAYER, selectedIndex.ToString()), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Remove the layer from the list and redraw
                currentMap.tileMapLayers.RemoveAt(selectedIndex);
                refreshLayerSelector(false);
                drawPanel.Refresh();
            }
        }

        /// <summary>
        /// Refreshes the layer selector listbox
        /// </summary>
        /// <param name="firstRefresh">True on map load, otherwise false</param>
        private void refreshLayerSelector(bool firstRefresh)
        {
            // Clear all items
            listBoxLayers.Items.Clear();

            // Add all layers from tile map layer list
            for (int i = 0; i < currentMap.tileMapLayers.Count; i++)
            {
                listBoxLayers.Items.Add("Layer " + i);
            }

            // Limit to 2 layers

            if (listBoxLayers.Items.Count >= 2)
            {
                btnAddLayer.Enabled = false;
                btnDeleteLayer.Enabled = true;
            } else if (listBoxLayers.Items.Count == 1)
            {
                btnAddLayer.Enabled = true;
                btnDeleteLayer.Enabled = true;
            } else
            {
                btnAddLayer.Enabled = true;
                btnDeleteLayer.Enabled = false;
            }

            // Check all items and set them visible on first load.
            if (firstRefresh)
            {
                for (int i = 0; i < listBoxLayers.Items.Count; i++)
                {
                    listBoxLayers.SetItemChecked(i, true);
                }

                visibleLayers[0] = true;
                visibleLayers[1] = true;

                listBoxLayers.SelectedIndex = 0;
            }
    
        }

        /// <summary>
        /// Check event for layer list box
        /// </summary>
        /// <param name="sender">List box instance</param>
        /// <param name="e">Event arguments</param>
        private void listBoxLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Modify visible layers array
            visibleLayers[e.Index] = e.NewValue == CheckState.Checked;
            drawPanel.Refresh();
        }

        private void listBoxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Draw event for the collision layer listbox. Simply for styling purposes
        /// </summary>
        /// <param name="sender">Instance of the list box</param>
        /// <param name="e">Event arguments</param>
        private void listBoxCollisionLayer_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            // Change font colour based on layer
            FontStyle fontStyle = FontStyle.Regular;
            if (listBoxCollisionLayer.Items.Count > 0)
            {
                Brush brush;

                switch (e.Index) {
                    case 1:
                        brush = Brushes.Red; ;
                        break;
                    case 2:
                        brush = Brushes.Blue;
                        break;
                    default:
                        brush = Brushes.Black;
                        break;
                }

                e.Graphics.DrawString(listBoxCollisionLayer.Items[e.Index].ToString(), new Font("Microsoft Sans Serif", 8.25f, fontStyle), brush, e.Bounds);

                e.DrawFocusRectangle();
            }
        }
    }
}
