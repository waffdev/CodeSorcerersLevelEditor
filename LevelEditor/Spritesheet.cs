using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LevelEditor
{
    /// <summary>
    /// Spritesheet
    /// Helper class for dividing texture atlases
    /// </summary>
    class Spritesheet
    {
        // Dimensions
        private int columns;
        private int rows;
        private int cellSize;

        // Image
        private Bitmap spritesheetImg;

        /// <summary>
        /// Spritesheet constructor
        /// </summary>
        /// <param name="columns">Number of columns in the sheet</param>
        /// <param name="rows">Number of rows in the sheet</param>
        /// <param name="cellSize">Size of each cell (tile size)</param>
        /// <param name="spritesheetImg">The image instance</param>
        public Spritesheet(int columns, int rows, int cellSize, Bitmap spritesheetImg)
        {
            this.columns = columns;
            this.rows = rows;
            this.cellSize = cellSize;
            this.spritesheetImg = spritesheetImg;
        }

        /// <summary>
        /// Splice the sheet into a one-dimensional array
        /// </summary>
        /// <returns>Bitmap[] one-dimensional array of sprites</returns>
        public Bitmap[] splice()
        {
            Bitmap[] returnArray = new Bitmap[rows * columns];

            int index = 0;
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    returnArray[index] = spritesheetImg.Clone(new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize), spritesheetImg.PixelFormat);
                    index++;
                }
            }

            return returnArray;
        }
    }
}
