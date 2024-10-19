using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (picBefore.Image == null)
            {
                MessageBox.Show("Please choose an image first.");
                return;
            }

            Bitmap sourceBitmap = new Bitmap(picBefore.Image);
            Bitmap filteredBitmap = ApplyMedianFilter(sourceBitmap);

            picAfter.Image = filteredBitmap;
        }

        private Bitmap ApplyMedianFilter(Bitmap sourceBitmap)
        {
            int width = sourceBitmap.Width;
            int height = sourceBitmap.Height;
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, width, height),
                                                          ImageLockMode.ReadOnly,
                                                          PixelFormat.Format32bppArgb);

            int byteCount = sourceData.Stride * sourceData.Height;
            byte[] pixelBuffer = new byte[byteCount];
            byte[] resultBuffer = new byte[byteCount];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, byteCount);
            sourceBitmap.UnlockBits(sourceData);

            int filterOffset = 1;
            int calcOffset = 0;
            int byteOffset = 0;

            List<int> neighbourPixels = new List<int>();
            byte[] middlePixel;

            for (int offsetY = filterOffset; offsetY < height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    neighbourPixels.Clear();

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);
                            neighbourPixels.Add(BitConverter.ToInt32(pixelBuffer, calcOffset));
                        }
                    }

                    neighbourPixels.Sort();
                    middlePixel = BitConverter.GetBytes(neighbourPixels[filterOffset * 4]);

                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }

            Bitmap resultBitmap = new Bitmap(width, height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, width, height),
                                                          ImageLockMode.WriteOnly,
                                                          PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, byteCount);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        private void AdaptiveMedianFilter_btn_Click(object sender, EventArgs e)
        {
         if (picBefore.Image == null)
         {
          MessageBox.Show("Please choose an image first.");
          return;
         }

         Bitmap sourceBitmap = new Bitmap(picBefore.Image);
         Bitmap filteredBitmap = ApplyAdaptiveMedianFilter(sourceBitmap);

         picAfter.Image = filteredBitmap;
        }
        private Bitmap ApplyAdaptiveMedianFilter(Bitmap image)
        {
          Bitmap result = new Bitmap(image.Width, image.Height);
          int maxWindowSize = 7;

          for (int y = 0; y < image.Height; y++)
          {
           for (int x = 0; x < image.Width; x++)
           {
            result.SetPixel(x, y, GetAdaptiveMedianPixel(image, x, y, maxWindowSize));
           }
          }

          return result;
        }

        private Color GetAdaptiveMedianPixel(Bitmap image, int x, int y, int maxWindowSize)
        {
          int windowSize = 3;

          while (windowSize <= maxWindowSize)
          {
           int halfWindow = windowSize / 2;
           int[] pixelValues = new int[windowSize * windowSize];
           int index = 0;

           
           for (int j = -halfWindow; j <= halfWindow; j++)
           {
            for (int i = -halfWindow; i <= halfWindow; i++)
            {
             int px = Math.Max(0, Math.Min(image.Width - 1, x + i));
             int py = Math.Max(0, Math.Min(image.Height - 1, y + j));
             Color pixelColor = image.GetPixel(px, py);
             pixelValues[index++] = pixelColor.R;
            }
           }

           
           Array.Sort(pixelValues);
           int minValue = pixelValues[0];
           int maxValue = pixelValues[pixelValues.Length - 1];
           int medianValue = pixelValues[pixelValues.Length / 2];
           int currentPixelValue = image.GetPixel(x, y).R;

           
           if (medianValue > minValue && medianValue < maxValue)
           {
            if (currentPixelValue > minValue && currentPixelValue < maxValue)
            {
             return Color.FromArgb(medianValue, medianValue, medianValue);
            }
            else
            {
             return Color.FromArgb(medianValue, medianValue, medianValue);
            }
           }
           else
           {
            windowSize += 2;
           }
          }

          return image.GetPixel(x, y);
         }

  
 }
}

