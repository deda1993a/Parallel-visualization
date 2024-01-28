using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallel_visualization
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //g.FillEllipse(red, kor);
            Graphics g = pictureBox2.CreateGraphics();
            // Rajzolas...                     





        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //this.DoubleBuffered = true;
        }

        void SequentialMergeSort(int[] array)
        {
            if (array.Length <= 1)
                return;

            int middle = array.Length / 2;

            int[] leftArray = new int[middle];
            int[] rightArray = new int[array.Length - middle];

            Array.Copy(array, 0, leftArray, 0, middle);
            Array.Copy(array, middle, rightArray, 0, array.Length - middle);

            SequentialMergeSort(leftArray);
            SequentialMergeSort(rightArray);

            Merge(array, leftArray, rightArray);

            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush redBrush = new SolidBrush(Color.Red);

            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);

            // Fill rectangle to screen.
            g.FillRectangle(new SolidBrush(Color.White), rect);
            for (int i = 0; i < array.Length; i++)
            {


                // Create rectangle for ellipse.
                int x = i + 10;
                int y = pictureBox1.Height - array[i] * 10;
                int width = 10;
                int height = pictureBox1.Height;
                Rectangle rect2 = new Rectangle(x, y, width, height);

                // Fill ellipse on screen.
                g.FillRectangle(redBrush, rect2);
            }

        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        Graphics g;

        int pchange = 0;
        int schange = 0;
        void ParallelMergeSort(int[] array)
        {
            if (array.Length <= 1)
                return;

            int middle = array.Length / 2;

            int[] leftArray = new int[middle];
            int[] rightArray = new int[array.Length - middle];

            Array.Copy(array, 0, leftArray, 0, middle);
            Array.Copy(array, middle, rightArray, 0, array.Length - middle);

            Parallel.Invoke(
                () => ParallelMergeSort(leftArray),
                () => ParallelMergeSort(rightArray)
            );

            Parallel.Invoke(
                () => Merge(array, leftArray, rightArray),
                () => Merge(array, leftArray, rightArray)  // Perform merging twice in parallel
            );

            Graphics g = pictureBox2.CreateGraphics();
            SolidBrush redBrush = new SolidBrush(Color.Red);

            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);

            // Fill rectangle to screen.
            g.FillRectangle(new SolidBrush(Color.White), rect);
            for (int i = 0; i < array.Length; i++)
            {


                // Create rectangle for ellipse.
                int x = i + 10;
                int y = pictureBox1.Height - array[i] * 10;
                int width = 10;
                int height = pictureBox1.Height;
                Rectangle rect2 = new Rectangle(x, y, width, height);

                // Fill ellipse on screen.
                g.FillRectangle(redBrush, rect2);
            }
        }

        void Merge(int[] array, int[] leftArray, int[] rightArray)
        {

            int leftIndex = 0, rightIndex = 0, index = 0;

            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex] < rightArray[rightIndex])
                {
                    array[index++] = leftArray[leftIndex++];
                    pchange++;
                    schange++;
                }
                else
                {
                    array[index++] = rightArray[rightIndex++];
                }






            }

            while (leftIndex < leftArray.Length)
            {

                array[index++] = leftArray[leftIndex++];

            }

            while (rightIndex < rightArray.Length)
            {
                array[index++] = rightArray[rightIndex++];

            }
        }

        /*void sort(int[] arr, int l, int r)
        {
            var watch = Stopwatch.StartNew();
            // something to time

            if (l < r)
            {

                // Find the middle point
                int m = l + (r - l) / 2;

                // Sort first and second halves
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
                Invoke((MethodInvoker)delegate
                {
                    label1.Text = "time: " + (double)watch.ElapsedMilliseconds / 1000;

                });
            }
            watch.Stop();

        }*/



        private void button1_Click(object sender, EventArgs e)
        {
            arrorig.CopyTo(arr, 0);
            Stopwatch stopwatch = Stopwatch.StartNew();
            SequentialMergeSort(arr);
            stopwatch.Stop();
            label1.Text = "time: " + (double)stopwatch.ElapsedMilliseconds / 1000;
            label5.Text = schange.ToString() + " csere történt";
            /*new Thread(() =>
            {
                sort(arr, 0, arr.Length - 1);
            }).Start();*/



        }

        private int Min;
        private int Max;
        private int[] arrorig;
        private int[] arr;
        private void button2_Click(object sender, EventArgs e)
        {
            arrorig.CopyTo(arr, 0);



            Stopwatch stopwatch = Stopwatch.StartNew();
            ParallelMergeSort(arr);
            stopwatch.Stop();
            label2.Text = "time: " + (double)stopwatch.ElapsedMilliseconds / 1000;
            label6.Text = pchange.ToString() + " történt";

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Min = Convert.ToInt32(numericUpDown1.Value);
            Max = Convert.ToInt32(numericUpDown2.Value);

            arr = new int[Convert.ToInt32(numericUpDown3.Value)];
            arrorig = new int[Convert.ToInt32(numericUpDown3.Value)];

            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush redBrush = new SolidBrush(Color.Red);

            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);

            // Fill rectangle to screen.
            g.FillRectangle(new SolidBrush(Color.White), rect);

            Random randNum = new Random();
            for (int i = 0; i < arrorig.Length; i++)
            {
                arrorig[i] = randNum.Next(Min, Max);
                //Debug.WriteLine(arr[i]);

                // Create rectangle for ellipse.
                int x = i + 10;
                int y = pictureBox1.Height - arrorig[i] * 10;
                int width = 10;
                int height = pictureBox1.Height;
                Rectangle rect2 = new Rectangle(x, y, width, height);

                // Fill ellipse on screen.
                g.FillRectangle(redBrush, rect2);

            }







        }
    }
}
