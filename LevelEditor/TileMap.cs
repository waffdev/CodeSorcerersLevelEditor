using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LevelEditor
{
    class TileMap
    {

        private string tileMapPath;
        private Bitmap tileMapImg;
        private TileSet tileSet;

        private int mapWidth;
        private int mapHeight;
        public int[,] tileMap;

        public TileMap(string tileMapPath, TileSet tileSet)
        {
            this.tileMapPath = tileMapPath;
            this.tileSet = tileSet;
            init();
        }

        private void init()
        {

            // Load image

            this.tileMapImg = (Bitmap)Image.FromFile(tileMapPath);
            this.mapWidth = tileMapImg.Width;
            this.mapHeight = tileMapImg.Height;

            tileMap = new int[mapWidth, mapHeight];

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    tileMap[x, y] = tileMapImg.GetPixel(x, y).R;
                }
            }

        }

        public void render(Graphics g)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (tileSet.getTile(tileMap[x,y]) != null)
                        g.DrawImage(tileSet.getTile(tileMap[x, y]), x * (tileSet.getTileSize() * Form1.RATIO), y * (tileSet.getTileSize() * Form1.RATIO), tileSet.getTileSize() * Form1.RATIO, tileSet.getTileSize() * Form1.RATIO);
                }
            }
        }

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
