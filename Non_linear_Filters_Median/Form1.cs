using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Non_linear_Filters_Median
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select an Image";

            // show chose image
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picBefore.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            picAfter.Image = null;
            picBefore.Image = null;
        }
    }
}
