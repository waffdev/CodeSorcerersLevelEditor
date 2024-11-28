using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/// <summary>
/// Import Tile Set Dialog
/// This allows users to import their own tileset
/// </summary>
namespace LevelEditor
{
    public partial class ImportTileSetDialog : Form
    {
        private MainForm instance;

        // String Constants
        private const string ERR_FILE_DOES_NOT_EXIST = "The file does not exist.";

        public ImportTileSetDialog(MainForm instance)
        {
            InitializeComponent();

            this.instance = instance;
        }

        /// <summary>
        /// Click event for the browse button
        /// </summary>
        /// <param name="sender">Instance of the button</param>
        /// <param name="e">Event arguments</param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Show dialog
            fileChooser.ShowDialog();
            txtPath.Text = fileChooser.FileName;
        }

        /// <summary>
        /// Click event for the import button
        /// </summary>
        /// <param name="sender">Instance of the import button</param>
        /// <param name="e">Event arguments</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtPath.Text))
            {
                instance.loadTileSet(txtPath.Text, Int32.Parse(cboCellSize.Text), Int32.Parse(txtRows.Text), Int32.Parse(txtCols.Text));
                Close();
            } else
            {
                MessageBox.Show(ERR_FILE_DOES_NOT_EXIST, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

    }
}
