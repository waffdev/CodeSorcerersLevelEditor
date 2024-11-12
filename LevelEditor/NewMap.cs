using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace LevelEditor
{
    public partial class NewMap : Form
    {
        private Form1 instance;

        public NewMap(Form1 instance)
        {
            InitializeComponent();

            this.instance = instance;
        }

        private void NewMap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveDialog.ShowDialog();
            string fileName = saveDialog.FileName;

            if (fileName == "")
                return;

            int width = Int32.Parse(txtWidth.Text);
            int height = Int32.Parse(txtHeight.Text);

            Bitmap bitmap = new Bitmap(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bitmap.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                }
            }

            bitmap.Save(fileName, ImageFormat.Png);
            instance.loadMap(fileName);
        }
    }
}
