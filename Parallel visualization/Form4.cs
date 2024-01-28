using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallel_visualization
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private Bitmap OgImage;
        private Bitmap NeImage;
        private Bitmap OutputB;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                textBox1.Text = openFileDialog1.FileName;
                OgImage = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NeImage = OgImage;
            OutputB = SequenErode(NeImage);
            pictureBox2.Image = OutputB;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NeImage = OgImage;

            OutputB = Erode(NeImage);
            pictureBox2.Image = OutputB;

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        public static unsafe Bitmap Erode(Bitmap inputBitmap)
        {
            int width = inputBitmap.Width;
            int height = inputBitmap.Height;
            Bitmap outputBitmap = new Bitmap(width, height);

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData inputData = inputBitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData outputData = outputBitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            byte* inputPtr = (byte*)inputData.Scan0;
            byte* outputPtr = (byte*)outputData.Scan0;

            Parallel.For(1, height - 1, y =>
            {
                for (int x = 1; x < width - 1; x++)
                {
                    bool isForeground = true;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            byte* pixel = inputPtr + ((y + j) * inputData.Stride) + ((x + i) * 3);
                            if (pixel[0] == 255) // Assuming the background is white
                            {
                                isForeground = false;
                                break;
                            }
                        }
                        if (!isForeground) break;
                    }

                    byte* outputPixel = outputPtr + (y * outputData.Stride) + (x * 3);
                    if (isForeground)
                    {
                        outputPixel[0] = 255; // Set pixel to black
                        outputPixel[1] = 255;
                        outputPixel[2] = 255;
                    }
                    else
                    {
                        outputPixel[0] = 0; // Set pixel to white
                        outputPixel[1] = 0;
                        outputPixel[2] = 0;
                    }
                }
            });

            inputBitmap.UnlockBits(inputData);
            outputBitmap.UnlockBits(outputData);

            return outputBitmap;
        }

        public static unsafe Bitmap SequenErode(Bitmap inputBitmap)
        {
            int width = inputBitmap.Width;
            int height = inputBitmap.Height;
            Bitmap outputBitmap = new Bitmap(width, height);

            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData inputData = inputBitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData outputData = outputBitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            byte* inputPtr = (byte*)inputData.Scan0;
            byte* outputPtr = (byte*)outputData.Scan0;

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    bool isForeground = true;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            byte* pixel = inputPtr + ((y + j) * inputData.Stride) + ((x + i) * 3);
                            if (pixel[0] == 255) // Assuming the background is white
                            {
                                isForeground = false;
                                break;
                            }
                        }
                        if (!isForeground) break;
                    }

                    byte* outputPixel = outputPtr + (y * outputData.Stride) + (x * 3);
                    if (isForeground)
                    {
                        outputPixel[0] = 255; // Set pixel to black
                        outputPixel[1] = 255;
                        outputPixel[2] = 255;
                    }
                    else
                    {
                        outputPixel[0] = 0; // Set pixel to white
                        outputPixel[1] = 0;
                        outputPixel[2] = 0;
                    }
                }
            }

            inputBitmap.UnlockBits(inputData);
            outputBitmap.UnlockBits(outputData);

            return outputBitmap;
        }


    }
}
