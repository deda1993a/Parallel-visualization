﻿using System.Diagnostics;

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
        
            Graphics g = pictureBox2.CreateGraphics();
                               





        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }


        private int MAX;
        private int THREAD_MAX;
        private int[] arrSequential;
        private int[] arrParallel;
        private int part = 0;

        private int widthScale = 1;
   
        static int Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j, changes = 0;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            i = 0;
            j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                    changes += n1 - i; 
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }

            return changes;
        }

        static void MergeSortSequential(int[] arr, int l, int r, ref int changes)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSortSequential(arr, l, m, ref changes);
                MergeSortSequential(arr, m + 1, r, ref changes);
                changes += Merge(arr, l, m, r);
            }
        }

        private int allParChange = 0;
        private List<int> threadCount = new List<int>();

        void MergeSortParallel()
        {
            int threadPart = Interlocked.Increment(ref part) - 1;
            int low = threadPart * (MAX / THREAD_MAX);
            int high = ((threadPart + 1) * (MAX / THREAD_MAX)) - 1;
            int mid = low + (high - low) / 2;
            if (low < high)
            {
                int changes = 0;
                MergeSortSequential(arrParallel, low, mid, ref changes);
                MergeSortSequential(arrParallel, mid + 1, high, ref changes);
                changes += Merge(arrParallel, low, mid, high);
                Debug.WriteLine("Ch: " + changes);
                allParChange += changes;
                threadCount.Add(changes);
               

            }
        }




      



        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Sequential Merge Sort:");
            DateTime startTimeSequential = DateTime.Now;
            int changesSequential = 0;
            MergeSortSequential(arrSequential, 0, MAX - 1, ref changesSequential);
            DateTime endTimeSequential = DateTime.Now;
            Console.WriteLine("Sorted array:");
           
            label5.Text = "Idő: " + (endTimeSequential - startTimeSequential).TotalSeconds + " másodperc";
            label1.Text = changesSequential + " csere történt: ";


            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush redBrush = new SolidBrush(Color.Red);

            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            valueChanged();
            
            g.FillRectangle(new SolidBrush(Color.White), rect);
            for (int i = 0; i < arrSequential.Length; i++)
            {

                int x = (i * 3) + 10;
                int y = pictureBox1.Height - arrSequential[i] * 10;
                int width = 10;
                int tmpz = width / widthScale;
                int height = pictureBox1.Height;
                if ((tmpz) == 0)
                {
                    tmpz = 1;
                }
                Rectangle rect2 = new Rectangle((x / widthScale) + 1, y, tmpz, height);

   
                g.FillRectangle(redBrush, rect2);

            }



        }


        private void button2_Click(object sender, EventArgs e)
        {
            THREAD_MAX = (int)numericUpDown4.Value;

            part = 0;

            Debug.WriteLine("\nParallel Merge Sort:");
            DateTime startTimeParallel = DateTime.Now;
            Thread[] threads = new Thread[THREAD_MAX];
            for (int i = 0; i < THREAD_MAX; ++i)
            {
                threads[i] = new Thread(new ThreadStart(MergeSortParallel));
                threads[i].Start();
            }

            foreach (Thread t in threads)
                t.Join();

            Merge(arrParallel, 0, (MAX / 2 - 1) / 2, MAX / 2 - 1);
            Merge(arrParallel, MAX / 2, MAX / 2 + (MAX - 1 - MAX / 2) / 2, MAX - 1);
            Merge(arrParallel, 0, (MAX - 1) / 2, MAX - 1);
            DateTime endTimeParallel = DateTime.Now;



            Graphics g = pictureBox2.CreateGraphics();
            SolidBrush redBrush = new SolidBrush(Color.Red);

            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            valueChanged();
            
            g.FillRectangle(new SolidBrush(Color.White), rect);
            for (int i = 0; i < arrSequential.Length; i++)
            {

                int x = (i * 3) + 10;
                int y = pictureBox1.Height - arrSequential[i] * 10;
                int width = 10;
                int tmpz = width / widthScale;
                int height = pictureBox1.Height;
                if ((tmpz) == 0)
                {
                    tmpz = 1;
                }
                Rectangle rect2 = new Rectangle((x / widthScale) + 1, y, tmpz, height);

   
                g.FillRectangle(redBrush, rect2);

            }
            label2.Text = allParChange + " csere történt";
      
            label6.Text = "Idő: " + (endTimeParallel - startTimeParallel).TotalSeconds + " másodperc";


        }

        private void button3_Click(object sender, EventArgs e)
        {



            MAX = (int)numericUpDown3.Value;
            arrSequential = new int[MAX];
            arrParallel = new int[MAX];

            Random rand = new Random();
            for (int i = 0; i < MAX; ++i)
            {
                int num = rand.Next((int)numericUpDown1.Value, (int)numericUpDown2.Value + 1);
                arrSequential[i] = num;
                arrParallel[i] = num;
            }
            valueChanged();
            Debug.WriteLine("Updated widthScale: " + widthScale);  // Debug print
            button1.Enabled = true;
            button2.Enabled = true;
            Graphics g = pictureBox1.CreateGraphics();
            Graphics g2 = pictureBox2.CreateGraphics();
            SolidBrush redBrush = new SolidBrush(Color.Red);

            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            Rectangle rectPar = new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height);

            // Fill rectangle to screen.
            g.FillRectangle(new SolidBrush(Color.White), rect);
            g2.FillRectangle(new SolidBrush(Color.White), rectPar);

            int tmp;
            for (int i = 0; i < arrSequential.Length; i++)
            {

                int x = (i * 3) + 10;
                int y = pictureBox1.Height - arrSequential[i] * 10;

                int width = 10;
                int height = pictureBox1.Height;
                int tmpz = width / widthScale;
                if ((tmpz) == 0)
                {
                    tmpz = 1;
                }

                Rectangle rect2 = new Rectangle(x / widthScale, y, tmpz, height);

                g.FillRectangle(redBrush, rect2);
                g2.FillRectangle(redBrush, rect2);
            }



        }

        private void valueChanged()
        {
            Debug.WriteLine("it is happened");

            if ((int)numericUpDown3.Value > 5570)
            {
                widthScale = 150;
                Debug.WriteLine("scale: " + widthScale);
            }
            else if ((int)numericUpDown3.Value > 890)
            {
                widthScale = 45;
                Debug.WriteLine("scale: " + widthScale);
            }
            else if ((int)numericUpDown3.Value > 120)
            {
                widthScale = 7;
                Debug.WriteLine("scale: " + widthScale);
            }
            else if ((int)numericUpDown3.Value <= 120)
            {
                widthScale = 1;
                Debug.WriteLine("scale: " + widthScale);
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            valueChanged();
        }
    }
}
