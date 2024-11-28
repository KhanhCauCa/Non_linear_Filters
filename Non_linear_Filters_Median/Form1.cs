using System.Drawing;
using System;

using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;


namespace Non_linear_Filters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            addComboBoxWindow(cmbWindow);
            addComboBoxFilter(comboBoxFilter);
            setupTrackBar();
            grbBilateral.Visible = false;
            grbMedian.Visible = false;
            btnFilter.Visible = false;
                      
        }
        private void setupTrackBar()
        {
            tbColor.Minimum = 0;  
            tbColor.Maximum = 200; 
            tbSpace.Minimum = 1;   
            tbSpace.Maximum = 50;  

            
            lblSigmaColor.Text = "SigmaColor: " + tbColor.Value;
            lblSigmaSpace.Text = "SigmaSpace: " + tbSpace.Value;
        }
        private void addComboBoxWindow(ComboBox comboBox)
        {
            cmbWindow.Items.Clear();
            cmbWindow.Items.Add(3);
            cmbWindow.Items.Add(5);
            cmbWindow.Items.Add(7);
            cmbWindow.Items.Add(9);
            cmbWindow.Items.Add(11);
            cmbWindow.SelectedIndex = 0;
        }
        private void addComboBoxFilter(ComboBox comboBox) {
            comboBoxFilter.Items.Clear();
            comboBoxFilter.Items.Add("Choose Filter");
            comboBoxFilter.Items.Add("Median");
            comboBoxFilter.Items.Add("Bilateral");
            comboBoxFilter.Items.Add("None");
            comboBoxFilter.SelectedIndex = 0;
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = comboBoxFilter.SelectedItem.ToString();

            if (selectedFilter == "Bilateral")
            {
                grbBilateral.Visible = true;
                grbMedian.Visible = false; 
                btnFilter.Visible = true;

            }
            else if (selectedFilter == "Median")
            {
                grbBilateral.Visible = false; 
                grbMedian.Visible = true;
                btnFilter.Visible = true;
            }
            else
            {
                grbBilateral.Visible = false;
                grbMedian.Visible = false;
                btnFilter.Visible = false;
            }
        }

        private void trackBarSigmaSpace_Scroll(object sender, EventArgs e)
        {
            lblSigmaSpace.Text = "SigmaSpace: " + tbSpace.Value.ToString();
            ApplySelectedFilter(); 
        }

        private void trackBarSigmaColor_Scroll(object sender, EventArgs e)
        {
            lblSigmaColor.Text = "SigmaColor: " + tbColor.Value.ToString();
            ApplySelectedFilter();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplySelectedFilter();
        }

        private void ApplySelectedFilter()
        {
            if (comboBoxFilter.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a valid filter.");
                return;
            }
            if (picBefore.Image == null)
            {
                MessageBox.Show("Please choose an image first.");
                return;
            }
            Bitmap sourceBitmap = new Bitmap(picBefore.Image);
            Mat sourceMat = BitmapConverter.ToMat(sourceBitmap);

            if (sourceMat.Type() != MatType.CV_8UC3 && sourceMat.Type() != MatType.CV_8UC1)
            {
                Cv2.CvtColor(sourceMat, sourceMat, ColorConversionCodes.BGRA2BGR);
            }

            Mat filteredMat = new Mat();
            string selectedFilter = comboBoxFilter.SelectedItem.ToString();

            switch (selectedFilter)
            {
                case "Median":
                    int windowSize = Convert.ToInt32(cmbWindow.SelectedItem);
                    Cv2.MedianBlur(sourceMat, filteredMat, windowSize);
                    break;

                case "Bilateral":
                    int sigmaSpace = tbSpace.Value; 
                    int sigmaColor = tbColor.Value; 
                    Cv2.BilateralFilter(sourceMat, filteredMat, 15, sigmaColor, sigmaSpace);
                    break;

                case "None":
                    filteredMat = sourceMat.Clone();
                    break;
            }

            Bitmap filteredBitmap = BitmapConverter.ToBitmap(filteredMat);
            picAfter.Image = filteredBitmap;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picBefore.Image = Image.FromFile(openFileDialog.FileName);
                    picAfter.Image = null;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            picBefore.Image = null;
            picAfter.Image = null;
        }

         }
}
