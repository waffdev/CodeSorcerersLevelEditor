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
    /// <summary>
    /// NewMap
    /// This shows a new map dialog to allow the user to create a map
    /// </summary>
    public partial class NewMap : Form
    {
        private MainForm instance;

        public NewMap(MainForm instance)
        {
            InitializeComponent();

            this.instance = instance;
        }

        /// <summary>
        /// Click event for the create button
        /// </summary>
        /// <param name="sender">Instance of the button</param>
        /// <param name="e">Event arguments</param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Show the save dialog
            saveDialog.ShowDialog();
            string fileName = saveDialog.FileName;

            // Ensure the path is not blank
            if (fileName == "")
                return;

            // Error check incorrect format
            if (!fileName.Contains(".png") && !fileName.Contains(".PNG"))
            {
                MessageBox.Show("Tile maps must be saved as .png format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure there is a 0 at the end of the file name for layering purposes
            fileName = fileName.Replace(".png", "0.png").Replace(".PNG", "0.png");

            int width = Int32.Parse(txtWidth.Text);
            int height = Int32.Parse(txtHeight.Text);
            
            // Create an empty tile map with transparent tiles R(index: 255) and no collisions B(index: 0)
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
