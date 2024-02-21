using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallel_visualization
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private const int MaxIterations = 100;
        private static object bitmapLock = new object();


        public static Bitmap Generate(int width, int height)
        {
            Bitmap image = new Bitmap(width, height);
            double xMin = -2.5;
            double xMax = 1;
            double yMin = -1;
            double yMax = 1;

            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    double a = Map(x, 0, width, xMin, xMax);
                    double b = Map(y, 0, height, yMin, yMax);
                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);
                    int n = 0;

                    while (n < MaxIterations)
                    {
                        z = z * z + c;
                        if ((z.Real * z.Real + z.Imaginary * z.Imaginary) > 4)
                        {
                            break;
                        }
                        n++;
                    }

                    int brightness = Map(n, 0, MaxIterations, 0, 255);
                    Color color = (n == MaxIterations) ? Color.Black : Color.FromArgb(brightness, brightness, brightness);
                    lock (bitmapLock)
                    {
                        image.SetPixel(x, y, color);
                    }
                }
            });

            return image;
        }


        public static Bitmap SeqGenerate(int width, int height)
        {
            Bitmap image = new Bitmap(width, height);
            double xMin = -2.5;
            double xMax = 1;
            double yMin = -1;
            double yMax = 1;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double a = Map(x, 0, width, xMin, xMax);
                    double b = Map(y, 0, height, yMin, yMax);
                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);
                    int n = 0;

                    while (n < MaxIterations)
                    {
                        z = z * z + c;
                        if ((z.Real * z.Real + z.Imaginary * z.Imaginary) > 4)
                        {
                            break;
                        }
                        n++;
                    }

                    int brightness = Map(n, 0, MaxIterations, 0, 255);
                    Color color = (n == MaxIterations) ? Color.Black : Color.FromArgb(brightness, brightness, brightness);
                    image.SetPixel(x, y, color);
                }
            }

            return image;
        }

        private static int Map(int value, int min1, int max1, int min2, int max2)
        {
            return (value - min1) * (max2 - min2) / (max1 - min1) + min2;
        }

        private static double Map(double value, double min1, double max1, double min2, double max2)
        {
            return (value - min1) * (max2 - min2) / (max1 - min1) + min2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Bitmap imagenew= Generate(800, 800);
            stopwatch.Stop();
            pictureBox1.Image = imagenew;
            label2.Text = "time: " + (double)stopwatch.ElapsedMilliseconds / 1000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Bitmap imagenew2 = SeqGenerate(800, 800);
            stopwatch.Stop();
            pictureBox2.Image = imagenew2;

            label1.Text = "time: " + (double)stopwatch.ElapsedMilliseconds / 1000;
          

        }
    }
}
