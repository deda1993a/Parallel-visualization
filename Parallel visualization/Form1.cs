namespace Parallel_visualization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mergeSortToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form Form2 = new Form2();
            // Form2.Size=new Size(816, 489);

            Form2.Show();

            //this.Hide();
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form3 = new Form3();


            Form3.Show();
        }

        private void grahamScanForConvexHullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form5 = new Form5();


            Form5.Show();
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form4 = new Form4();


            Form4.Show();
        }

        private void mandelbrotSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form6 = new Form6();


            Form6.Show();
        }
    }
}