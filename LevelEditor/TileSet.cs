using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace LevelEditor
{

    /// <summary>
    /// TileSet
    /// Tile set helper class
    /// </summary>
    class TileSet
    {
        // Path to the tile set and physical image
        private string tileSetPath;
        private Bitmap tileSetImg;

        // Spritesheet and array of sprites
        private Spritesheet tileSpriteSheet;
        private Bitmap[] tileSet;

        // Dimensions
        private int rows;
        private int columns;
        private int tileSize;

        /// <summary>
        /// Tile Set constructor
        /// </summary>
        /// <param name="tileSetPath">Path to the tile set</param>
        /// <param name="rows">How many rows are in the tile set</param>
        /// <param name="columns">How many columns are in the tile set</param>
        /// <param name="tileSize">Size of the tiles</param>
        public TileSet(string tileSetPath, int rows, int columns, int tileSize)
        {
            this.tileSetPath = tileSetPath;
            this.rows = rows;
            this.columns = columns;
            this.tileSize = tileSize;

            this.load();
        }

        /// <summary>
        /// Loads the tile set into memory
        /// </summary>
        private void load()
        {
            tileSetImg = (Bitmap)Image.FromFile(tileSetPath);
            tileSpriteSheet = new Spritesheet(columns, rows, tileSize, tileSetImg);
            this.tileSet = tileSpriteSheet.splice();
            Debug.WriteLine("Successfully loaded tile set: " + tileSetPath);   
        }

        /// <summary>
        /// Gets the appropriate tile from a given index
        /// </summary>
        /// <param name="index">Tile index</param>
        /// <returns></returns>
        public Image getTile(int index)
        {
            // Return correct tile based on index if it is not 255.
            // If 255, return null so no tile is drawn (transparent tile)
            if (index != 255)
                return tileSet[index];
            else
                return null;
        }

        public int getTileSize()
        {
            return tileSize;
        }

        public Bitmap[] getRawTileset()
        {
            return tileSet;
        }

        public int getRows()
        {
            return rows;
        }

        public int getColumns()
        {
            return columns;
        }
    }
}
