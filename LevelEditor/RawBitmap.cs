using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace LevelEditor
{
    public class RawBitmap
    {
        public readonly int width;
        public readonly int height;
        private byte[] imageBytes;

        public RawBitmap(int width, int height)
        {
            this.width = width;
            this.height = height;
            imageBytes = new byte[width * height * 4];
        }

        public void setPixel(int x, int y, RawColor color)
        {
            int offset = ((height - y - 1) * width + x) * 4;
            imageBytes[offset + 0] = color.B;
            imageBytes[offset + 1] = color.G;
            imageBytes[offset + 2] = color.R;
        }

        public Bitmap getBitmap()
        {
            const int headerSize = 54;
            byte[] bitmapBytes = new byte[imageBytes.Length + headerSize];
            bitmapBytes[0] = (byte)'B';
            bitmapBytes[1] = (byte)'M';
            bitmapBytes[14] = 40;
            Array.Copy(BitConverter.GetBytes(bitmapBytes.Length), 0, bitmapBytes, 2, 4);
            Array.Copy(BitConverter.GetBytes(headerSize), 0, bitmapBytes, 10, 4);
            Array.Copy(BitConverter.GetBytes(width), 0, bitmapBytes, 18, 4);
            Array.Copy(BitConverter.GetBytes(height), 0, bitmapBytes, 22, 4);
            Array.Copy(BitConverter.GetBytes(32), 0, bitmapBytes, 28, 2);
            Array.Copy(BitConverter.GetBytes(imageBytes.Length), 0, bitmapBytes, 34, 4);

            Bitmap bmp;
            using (MemoryStream ms = new MemoryStream(bitmapBytes))
            {
                bmp = new Bitmap(ms);
            }
            return bmp;
        }
    }
}
