using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<Bitmap> listOfBitMaps = new List<Bitmap>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                allPic = 1;
                textBox1.Text = openFileDialog1.FileName;
                OgImage = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            complPic = 0;
            complPic++;
            listOfBitMaps.Clear();
            NeImage = (Bitmap)OgImage.Clone();
            
            label3.Text = "Képek: " + allPic + "/" + complPic;
            Stopwatch stopwatch = Stopwatch.StartNew();

            OutputB = SequenErode(NeImage);
            listOfBitMaps.Add(OutputB);
            label5.Text = "Felbontás: " + OutputB.Width + "x" + OutputB.Height;
            stopwatch.Stop();
            pictureBox3.Image = OgImage;
            pictureBox1.Image = OutputB;
            label1.Text = "idő: " + (double)stopwatch.ElapsedMilliseconds / 1000+ " másodperc";
            for (int i = 0; i < listOfBitMaps.Count; i++)
            {
                listOfBitMaps[i].Save(folderBrowserDialog2.SelectedPath + "\\" + i + ".bmp", ImageFormat.Bmp);
            }
        }

        private int complPic = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            complPic = 0;
            listOfBitMaps.Clear();
            Stopwatch stopwatch = Stopwatch.StartNew();
            //NeImage = OgImage;
            foreach (string selected in dirs)
            {
                OgImage = new Bitmap(selected);
                NeImage = (Bitmap)OgImage.Clone();
                complPic++;
                label3.Text = "Képek: " + allPic + "/" + complPic;

                OutputB = SequenErode(NeImage);
                listOfBitMaps.Add(OutputB);
                label5.Text = "Felbontás: " + OutputB.Width + "x" + OutputB.Height;
                pictureBox3.Image = OgImage;
                pictureBox1.Image = OutputB;
                //NeImage.Save(Path.GetDirectoryName("C:\\img.jpg"), ImageFormat.Jpeg);
            }
            stopwatch.Stop();
            label1.Text = "idő: " + (double)stopwatch.ElapsedMilliseconds / 1000 + " másodperc";
            for (int i = 0; i < listOfBitMaps.Count; i++)
            {
                listOfBitMaps[i].Save(folderBrowserDialog2.SelectedPath + "\\" + i + ".bmp", ImageFormat.Bmp);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            complPic = 0;
            listOfBitMaps.Clear();
            NeImage = (Bitmap)OgImage.Clone();
            complPic++;
            label4.Text = "Képek: " + allPic + "/" + complPic;
            Stopwatch stopwatch = Stopwatch.StartNew();

            OutputB = Erode(NeImage);
            listOfBitMaps.Add(OutputB);
            label5.Text = "Felbontás: " + OutputB.Width + "x" + OutputB.Height;
            stopwatch.Stop();
            pictureBox2.Image = OutputB;
            label2.Text = "idő: " + (double)stopwatch.ElapsedMilliseconds / 1000+ " másodperc";

            
            pictureBox4.Image = OgImage;
            for (int i = 0; i < listOfBitMaps.Count; i++)
            {
                listOfBitMaps[i].Save(folderBrowserDialog2.SelectedPath + "\\" + i + ".bmp", ImageFormat.Bmp);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            complPic = 0;
            listOfBitMaps.Clear();
            Stopwatch stopwatch = Stopwatch.StartNew();
            //NeImage = OgImage;
            foreach (string selected in dirs)
            {

                OgImage = new Bitmap(selected);
                NeImage = (Bitmap)OgImage.Clone();
                complPic++;
                label4.Text = "Képek: " + allPic + "/" + complPic;
                OutputB = Erode(NeImage);
                listOfBitMaps.Add(OutputB);
                label5.Text = "Felbontás: " + OutputB.Width + "x" + OutputB.Height;
                pictureBox2.Image = OutputB;
                pictureBox4.Image = OgImage;


            }
            stopwatch.Stop();
            label2.Text = "idő: " + (double)stopwatch.ElapsedMilliseconds / 1000 + " másodperc";
            for (int i = 0; i < listOfBitMaps.Count; i++)
            {
                listOfBitMaps[i].Save(folderBrowserDialog2.SelectedPath + "\\" + i + ".bmp", ImageFormat.Bmp);
            }
        }

        private int allPic;
        private string[] dirs;
        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                dirs = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                allPic = dirs.Length;
            }
        }

        public static unsafe Bitmap Erode(Bitmap inputBitmap)
        {
            int width = inputBitmap.Width;
            int height = inputBitmap.Height;
            Bitmap outputBitmap = new Bitmap(width, height);

           
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
                            if (pixel[0] == 255) 
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
                        outputPixel[0] = 255; 
                        outputPixel[1] = 255;
                        outputPixel[2] = 255;
                    }
                    else
                    {
                        outputPixel[0] = 0; 
                        outputPixel[1] = 0;
                        outputPixel[2] = 0;
                    }
                }
            });

            inputBitmap.UnlockBits(inputData);
            outputBitmap.UnlockBits(outputData);

            return outputBitmap;
        }

        public unsafe Bitmap SequenErode(Bitmap inputBitmap)
        {
            int width = inputBitmap.Width;
            int height = inputBitmap.Height;
            Bitmap outputBitmap = new Bitmap(width, height);

           
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
                            if (pixel[0] == 255) 
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
                        outputPixel[0] = 255; 
                        outputPixel[1] = 255;
                        outputPixel[2] = 255;
                    }
                    else
                    {
                        outputPixel[0] = 0;
                        outputPixel[1] = 0;
                        outputPixel[2] = 0;
                    }
                }
            }

            inputBitmap.UnlockBits(inputData);
            outputBitmap.UnlockBits(outputData);

            return outputBitmap;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text) == true && Directory.Exists(textBox3.Text) == true)
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox2.Text) == true && Directory.Exists(textBox3.Text) == true)
            {
                button5.Enabled = true;
                button6.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
                button6.Enabled = false;
            }

            if (File.Exists(textBox1.Text) == true && Directory.Exists(textBox3.Text) == true)
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog2.SelectedPath;
            }
        }
    }
}
