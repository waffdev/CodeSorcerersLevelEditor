using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class ImportTileSetDialog : Form
    {
        private Form1 instance;

        public ImportTileSetDialog(Form1 instance)
        {
            InitializeComponent();

            this.instance = instance;
        }

        private void ImportTileSetDialog_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileChooser.ShowDialog();
            txtPath.Text = fileChooser.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            instance.loadTileSet(txtPath.Text, Int32.Parse(cboCellSize.Text), Int32.Parse(txtRows.Text), Int32.Parse(txtCols.Text));
            Close();
        }

    }
}
