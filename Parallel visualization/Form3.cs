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
 
        private int allPic;
        private int complPic = 0;
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

        private void button3_Click(object sender, EventArgs e)
        {
            complPic = 0;
            listOfBitMaps.Clear();
            Stopwatch stopwatch = Stopwatch.StartNew();
            complPic++;
            label4.Text = "Képek: " + allPic + "/" + complPic;

            NeImage = (Bitmap)OgImage.Clone();

            ParGrayscale(NeImage);
            listOfBitMaps.Add(NeImage);
            stopwatch.Stop();
            label2.Text = "idő: " + (double)stopwatch.ElapsedMilliseconds / 1000 + " másodperc";
            for (int i = 0; i < listOfBitMaps.Count; i++)
            {
                listOfBitMaps[i].Save(folderBrowserDialog2.SelectedPath + "\\" + i + ".bmp", ImageFormat.Bmp);
            }
        }

        private void ParGrayscale(Bitmap pic)
        {
            label5.Text = "Felbontás: " + pic.Width + "x" + pic.Height;
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
            label5.Text = "Felbontás: " + pic.Width+"x"+pic.Height;
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
            complPic = 0;
            listOfBitMaps.Clear();
            Stopwatch stopwatch = Stopwatch.StartNew();
            complPic++;
            label3.Text = "Képek: " + allPic + "/" + complPic;
            NeImage = (Bitmap)OgImage.Clone();
            
            SeqGrayscale(NeImage);
            listOfBitMaps.Add(NeImage);
            stopwatch.Stop();

            label1.Text = "idő: " + (double)stopwatch.ElapsedMilliseconds / 1000+" másodperc";
            for (int i = 0; i < listOfBitMaps.Count; i++)
            {
                listOfBitMaps[i].Save(folderBrowserDialog2.SelectedPath + "\\" + i + ".bmp", ImageFormat.Bmp);
            }
        }

        private string[] dirs;
        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text=folderBrowserDialog1.SelectedPath;
                dirs = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                allPic = dirs.Length;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            complPic = 0;
            listOfBitMaps.Clear();
            Stopwatch stopwatch = Stopwatch.StartNew();
       
            foreach (string selected in dirs)
            {
                OgImage = new Bitmap(selected);
                NeImage=(Bitmap)OgImage.Clone();
                complPic++;
                label3.Text = "Képek: "+allPic+"/"+complPic;

                SeqGrayscale(NeImage);
                listOfBitMaps.Add(NeImage);

                

            }
            stopwatch.Stop();
            label1.Text = "idő: " + (double)stopwatch.ElapsedMilliseconds / 1000 + " másodperc";
            for(int i = 0; i < listOfBitMaps.Count; i++)
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
                complPic++;
                label4.Text = "Képek: " + allPic + "/" + complPic;
                OgImage = new Bitmap(selected);
                NeImage = (Bitmap)OgImage.Clone();


                ParGrayscale(NeImage);
                listOfBitMaps.Add(NeImage);
                //NeImage.Save(folderBrowserDialog2.SelectedPath + "\\" + complPic + ".bmp", ImageFormat.Bmp);


            }
            stopwatch.Stop();
            label2.Text = "idő: " + (double)stopwatch.ElapsedMilliseconds / 1000 + " másodperc";
            for (int i = 0; i < listOfBitMaps.Count; i++)
            {
                listOfBitMaps[i].Save(folderBrowserDialog2.SelectedPath + "\\" + i + ".bmp", ImageFormat.Bmp);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PerformanceCounter myAppCpu =
    new PerformanceCounter(
        "Process", "% Processor Time", "Parallel visualization", true);
            Debug.WriteLine(myAppCpu.NextValue());
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
