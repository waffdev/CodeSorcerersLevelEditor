using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace LevelEditor
{
    class TileSet
    {

        private string tileSetPath;
        private Bitmap tileSetImg;

        private Spritesheet tileSpriteSheet;
        private Bitmap[] tileSet;
        private int rows;
        private int columns;
        private int tileSize;

        public TileSet(string tileSetPath, int rows, int columns, int tileSize)
        {
            this.tileSetPath = tileSetPath;
            this.rows = rows;
            this.columns = columns;
            this.tileSize = tileSize;

            this.load();
        }

        private void load()
        {
            tileSetImg = (Bitmap)Image.FromFile(tileSetPath);
            tileSpriteSheet = new Spritesheet(columns, rows, tileSize, tileSetImg);
            this.tileSet = tileSpriteSheet.splice();
            Debug.WriteLine("Successfully loaded tile set: " + tileSetPath);   
        }

        public Image getTile(int index)
        {
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
