using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LevelEditor
{
    /// <summary>
    /// TileMap
    /// Tile map helper class
    /// </summary>
    class TileMap
    {

        // Path to tile map and instance of tile set
        private string tileMapPath;
        private TileSet tileSet;

        // Dimensions
        private int mapWidth;
        private int mapHeight;

        // Tile map data
        public List<int[,]> tileMapLayers;
        public int[,] collisionLayer;

        // String constants
        private const string ERR_DIMENSIONS_DONT_MATCH = "Tile map layers do not match the same dimensions.";

        /// <summary>
        /// Tile Map constructor
        /// </summary>
        /// <param name="tileMapPath">The path to the tile map</param>
        /// <param name="tileSet">The instance of the tile set</param>
        public TileMap(string tileMapPath, TileSet tileSet)
        {
            // Remove suffixes
            FileInfo pathFileInfo = new FileInfo(tileMapPath);
            this.tileMapPath = pathFileInfo.Directory.FullName + @"\" + pathFileInfo.Name.Replace("0.png", "").Replace("0.PNG", "");
            
            this.tileMapLayers = new List<int[,]>();
            this.tileSet = tileSet;
            init();
        }

        /// <summary>
        /// Load the tile map into memory
        /// </summary>
        private void init()
        {

            // Construct paths and check if a second layer exists
            string layer1Path = tileMapPath + "0.png";
            string layer2Path = tileMapPath + "1.png";
            bool hasLayer2 = File.Exists(layer2Path);

            // Layer 1
            Bitmap tileMapImg = (Bitmap)Image.FromFile(layer1Path);
            this.mapWidth = tileMapImg.Width;
            this.mapHeight = tileMapImg.Height;
            buildTileMap(tileMapImg);

            // Collision Layer
            collisionLayer = new int[mapWidth, mapHeight];

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    collisionLayer[x, y] = tileMapImg.GetPixel(x, y).B;
                }
            }

            // Layer 2
            if (hasLayer2)
            {
                tileMapImg = (Bitmap)Image.FromFile(layer2Path);
                
                // Error check : All tile map layers must be the same width and height
                if (tileMapImg.Width != this.mapWidth || tileMapImg.Height != this.mapHeight)
                {
                    MessageBox.Show(ERR_DIMENSIONS_DONT_MATCH, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                buildTileMap(tileMapImg);
            }


        }

        /// <summary>
        /// Build a tile map layer from the specified bitmap
        /// </summary>
        /// <param name="tileMapImg">The tile map to be built</param>
        private void buildTileMap(Bitmap tileMapImg)
        {
            int[,] layerMap = new int[mapWidth, mapHeight];

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    layerMap[x, y] = tileMapImg.GetPixel(x, y).R;
                }
            }

            tileMapLayers.Add(layerMap);
        }

        /// <summary>
        /// Render the tile map
        /// </summary>
        /// <param name="g">Graphics context</param>
        public void render(Graphics g)
        {
            foreach (int[,] tileMapLayer in tileMapLayers)
            {
                // Check if the layer is meant to be visible.
                if (MainForm.visibleLayers[tileMapLayers.IndexOf(tileMapLayer)])
                {
                    for (int x = 0; x < mapWidth; x++)
                    {
                        for (int y = 0; y < mapHeight; y++)
                        {
                            int tileSize = tileSet.getTileSize();

                            // Draw the tile if the layer if the tile can be retrieved from the tile set.
                            if (tileSet.getTile(tileMapLayer[x, y]) != null)
                                g.DrawImage(tileSet.getTile(tileMapLayer[x, y]), x * (tileSize * MainForm.RATIO), y * (tileSize * MainForm.RATIO), tileSize * MainForm.RATIO, tileSize * MainForm.RATIO);

                        }
                    }
                }
                
            }

            // If in collision mode, draw the collision grid lines
            if (MainForm.drawMode == DrawMode.Collision)
            {
                // Create colour coded pens
                Pen colPen1 = new Pen(Color.Red);
                Pen colPen2 = new Pen(Color.Blue);

                int tileSize = tileSet.getTileSize();

                for (int x = 0; x < mapWidth; x++)
                {
                    for (int y = 0; y < mapHeight; y++)
                    {
                        Rectangle rect = new Rectangle(x * (int)(MainForm.RATIO * tileSize), y * (int)(MainForm.RATIO * tileSize), (int)(tileSize * MainForm.RATIO), (int)(tileSize * MainForm.RATIO));

                        // Draw the rectangle with the correct colour based on the collision layer
                        switch (collisionLayer[x, y])
                        {
                            case 1:
                                g.DrawRectangle(colPen1, rect);
                                break;
                            case 2:
                                g.DrawRectangle(colPen2, rect);
                                break;
                            default:
                                break;
                        }
                    }
                }

                // Dispose pens
                colPen1.Dispose();
                colPen2.Dispose();

            }
        }

        // Getters and Setter
        // (for some reason... still in Java brain)

        public int getWidth()
        {
            return mapWidth;
        }

        public int getHeight()
        {
            return mapHeight;
        }
    
    }
}
