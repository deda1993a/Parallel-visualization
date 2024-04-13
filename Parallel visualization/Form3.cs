using System.Diagnostics;
using System.Drawing.Imaging;

namespace Parallel_visualization
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private Bitmap OgImage;
        private Bitmap NeImage;
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                textBox1.Text = openFileDialog1.FileName;
                OgImage = new Bitmap(openFileDialog1.FileName);
              
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            NeImage = (Bitmap)OgImage.Clone();

            ParGrayscale(NeImage);
            stopwatch.Stop();
            label2.Text = "time: " + (double)stopwatch.ElapsedMilliseconds / 1000;

        }

        private void ParGrayscale(Bitmap pic)
        {
            unsafe
            {
                BitmapData bitmapData = pic.LockBits(new Rectangle(0, 0, pic.Width, pic.Height), ImageLockMode.ReadWrite, pic.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(pic.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        int CValue = (oldRed + oldGreen + oldBlue) / 3;

                        currentLine[x] = (byte)CValue;
                        currentLine[x + 1] = (byte)CValue;
                        currentLine[x + 2] = (byte)CValue;

                    }
                });


                pic.UnlockBits(bitmapData);
                pictureBox4.Image = OgImage;
                pictureBox2.Image = pic;
            }

        }

        private void SeqGrayscale(Bitmap pic)
        {
            unsafe
            {
                BitmapData bitmapData = pic.LockBits(new Rectangle(0, 0, pic.Width, pic.Height), ImageLockMode.ReadWrite, pic.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(pic.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        int CValue = (oldRed + oldGreen + oldBlue) / 3;

                        currentLine[x] = (byte)CValue;
                        currentLine[x + 1] = (byte)CValue;
                        currentLine[x + 2] = (byte)CValue;
                    }
                }
                pic.UnlockBits(bitmapData);
                pictureBox3.Image = OgImage;
                pictureBox1.Image = pic;
            }
        }

        //gthtz
        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
          
            NeImage = (Bitmap)OgImage.Clone();
            
            SeqGrayscale(NeImage);
            stopwatch.Stop();
            label1.Text = "time: " + (double)stopwatch.ElapsedMilliseconds / 1000;
        }

        private string[] dirs;
        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                dirs = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //NeImage = OgImage;
            foreach (string selected in dirs)
            {

                NeImage = new Bitmap(selected);


                SeqGrayscale(NeImage);
            }
            stopwatch.Stop();
            label1.Text = "time: " + (double)stopwatch.ElapsedMilliseconds / 1000;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //NeImage = OgImage;
            foreach (string selected in dirs)
            {

                NeImage = new Bitmap(selected);


                ParGrayscale(NeImage);



            }
            stopwatch.Stop();
            label2.Text = "time: " + (double)stopwatch.ElapsedMilliseconds / 1000;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PerformanceCounter myAppCpu =
    new PerformanceCounter(
        "Process", "% Processor Time", "Parallel visualization", true);
            Debug.WriteLine(myAppCpu.NextValue());
        }
    }
}
