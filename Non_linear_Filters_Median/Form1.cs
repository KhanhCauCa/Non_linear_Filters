using System.Drawing;
using System;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

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
            comboBoxFilter.Items.Clear();
            comboBoxFilter.Items.Add("Choose Filter");
            comboBoxFilter.Items.Add("Median");
            comboBoxFilter.Items.Add("Bilateral");
            comboBoxFilter.Items.Add("Gaussian");
            comboBoxFilter.Items.Add("Nonlinear Weighted Mean");
            comboBoxFilter.Items.Add("Anisotropic Diffusion");
            comboBoxFilter.Items.Add("None");
            comboBoxFilter.SelectedIndex = 0;

            trackBarBilateral.Visible = false;
            lblTrackBarValue.Visible = false;
            btnFilter.Visible = false;

            trackBarBilateral.Minimum = 1;
            trackBarBilateral.Maximum = 100;
            trackBarBilateral.Value = 50;

            picAfter.MouseWheel += PicAfter_MouseWheel;

        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = comboBoxFilter.SelectedItem.ToString();

            if (selectedFilter == "Bilateral")
            {
                trackBarBilateral.Visible = true;
                lblTrackBarValue.Visible = true;
                btnFilter.Visible = false;
                ApplySelectedFilter();
            }
            else
            {
                trackBarBilateral.Visible = false;
                lblTrackBarValue.Visible = false;
                btnFilter.Visible = true;
            }
        }

        private void trackBarBilateral_Scroll(object sender, EventArgs e)
        {
            lblTrackBarValue.Text = "Mịn: " + trackBarBilateral.Value.ToString();
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
                    Cv2.MedianBlur(sourceMat, filteredMat, 5);
                    break;

                case "Bilateral":
                    int sigmaSpace = trackBarBilateral.Value;
                    int sigmaColor = 50;
                    Cv2.BilateralFilter(sourceMat, filteredMat, 15, sigmaColor, sigmaSpace);
                    break;

                case "Gaussian":
                    Cv2.GaussianBlur(sourceMat, filteredMat, new OpenCvSharp.Size(5, 5), 0);
                    break;

                case "Nonlinear Weighted Mean":
                    filteredMat = ApplyNonlinearWeightedMeanFilter(sourceMat);
                    break;

                case "Anisotropic Diffusion":
                    //filteredMat = ApplyAnisotropicDiffusion(sourceMat, 10, 0.25); // 10 iterations, lambda = 0.25
                    break;

                case "None":
                    filteredMat = sourceMat.Clone();
                    break;
            }

            Bitmap filteredBitmap = BitmapConverter.ToBitmap(filteredMat);
            picAfter.Image = filteredBitmap;
        }

        // Bộ lọc trung bình có trọng số phi tuyến (Nonlinear Weighted Mean Filter)
        public Mat ApplyNonlinearWeightedMeanFilter(Mat sourceMat)
        {
            // Tạo bản sao của ảnh đầu vào (Mat)
            Mat resultMat = new Mat(sourceMat.Size(), sourceMat.Type());

            // Duyệt qua từng pixel của ảnh, bỏ qua viền
            for (int y = 1; y < sourceMat.Rows - 1; y++)
            {
                for (int x = 1; x < sourceMat.Cols - 1; x++)
                {
                    double sumB = 0, sumG = 0, sumR = 0;
                    double weightSum = 0;

                    Vec3b centerPixel = sourceMat.At<Vec3b>(y, x); // Pixel tại vị trí (x, y)

                    // Áp dụng bộ lọc 3x3
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Vec3b neighborPixel = sourceMat.At<Vec3b>(y + i, x + j);

                            // Tính trọng số phi tuyến dựa trên sự khác biệt của kênh màu đỏ (R)
                            double weight = 1.0 / (1.0 + Math.Abs(neighborPixel.Item2 - centerPixel.Item2));

                            // Cộng dồn giá trị của các kênh (B, G, R) với trọng số
                            sumB += neighborPixel.Item0 * weight; // Blue
                            sumG += neighborPixel.Item1 * weight; // Green
                            sumR += neighborPixel.Item2 * weight; // Red

                            // Tổng trọng số
                            weightSum += weight;
                        }
                    }

                    // Tính giá trị trung bình có trọng số cho mỗi kênh màu (B, G, R)
                    byte avgB = (byte)Math.Min(255, Math.Max(0, sumB / weightSum));
                    byte avgG = (byte)Math.Min(255, Math.Max(0, sumG / weightSum));
                    byte avgR = (byte)Math.Min(255, Math.Max(0, sumR / weightSum));

                    // Gán giá trị mới vào ảnh kết quả
                    resultMat.Set(y, x, new Vec3b(avgB, avgG, avgR));
                }
            }

            return resultMat;
        }



        // Bộ lọc khuếch tán dị hướng (Anisotropic Diffusion)
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

        //add 
        private float zoomFactorAfter = 1.0f;

        private void PicAfter_MouseWheel(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem cuộn chuột lên hay xuống
            if (e.Delta > 0) // Cuộn lên
            {
                zoomFactorAfter += 0.1f; // Tăng tỷ lệ phóng đại
            }
            else if (e.Delta < 0) // Cuộn xuống
            {
                zoomFactorAfter = Math.Max(zoomFactorAfter - 0.1f, 0.1f); // Giảm tỷ lệ phóng đại nhưng không dưới 0.1
            }

            // Áp dụng tỷ lệ phóng đại
            picAfter.Width = (int)(465 * zoomFactorAfter); // Giữ kích thước tối đa
            picAfter.Height = (int)(551 * zoomFactorAfter);
            Bitmap sourceBitmap = new Bitmap(picAfter.Image);

            // Cập nhật lại kích thước hình ảnh
            picAfter.Image?.Dispose(); // Giải phóng hình ảnh trước đó
            picAfter.Image = new Bitmap(sourceBitmap, picAfter.Size); // Tạo hình ảnh mới với kích thước đã thay đổi
        }
    }
}
