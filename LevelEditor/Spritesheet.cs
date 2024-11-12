using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LevelEditor
{
    class Spritesheet
    {
        private int columns;
        private int rows;
        private int cellSize;

        private Bitmap spritesheetImg;

        public Spritesheet(int columns, int rows, int cellSize, Bitmap spritesheetImg)
        {
            this.columns = columns;
            this.rows = rows;
            this.cellSize = cellSize;
            this.spritesheetImg = spritesheetImg;
        }

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
