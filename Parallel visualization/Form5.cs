using System.Collections.Concurrent;
using System.Diagnostics;

namespace Parallel_visualization
{





    public partial class Form5 : Form
    {
        /*public Form5()
        {
            InitializeComponent();
        }*/


        private readonly List<Point> points;
        private readonly Button computeHullButton;
        private readonly PictureBox pictureBox;
        private readonly Label executionTimeLabel;

        public Form5()
        {
            this.ClientSize = new Size(800, 600);

            

            computeHullButton = new Button
            {
                Text = "Szekveniális Konvex burok számítása",
                Location = new Point(10, 10),
                Size = new Size(170, 30)
            };
            computeHullButton.Click += ComputeHullButtonClick;

            pictureBox = new PictureBox
            {
                Location = new Point(10, 50),
                Size = new Size(780, 500),
                BorderStyle = BorderStyle.Fixed3D,
                BackColor = Color.White
            };

            executionTimeLabel = new Label
            {
                Location = new Point(10, 560),
                Size = new Size(780, 30)
            };

            this.Controls.Add(computeHullButton);
            this.Controls.Add(pictureBox);
            this.Controls.Add(executionTimeLabel);
            computeHullButton.Click += ComputeHullButtonClick;
            
            points = GeneratePoints(100); // Generate 100 random points
        }

        private void ComputeHullButtonClick(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var hull = ComputeConvexHull(points);
            stopwatch.Stop();
            long microseconds = stopwatch.Elapsed.Ticks / (TimeSpan.TicksPerMillisecond / 1000);
            DrawHull(hull, pictureBox);
            executionTimeLabel.Text = $"Végrehajtási idő: {microseconds} μs";
        }

        private List<Point> GeneratePoints(int count)
        {
            Random rand = new Random();
            return Enumerable.Range(0, count).Select(_ => new Point(rand.Next(pictureBox.Width), rand.Next(pictureBox.Height))).ToList();
        }

        private Stack<Point> ComputeConvexHull(List<Point> points)
        {
            if (points.Count < 3) return new Stack<Point>();

            Point lowestPoint = points.Aggregate((minPoint, nextPoint) => nextPoint.Y < minPoint.Y || (nextPoint.Y == minPoint.Y && nextPoint.X < minPoint.X) ? nextPoint : minPoint);
            var sortedPoints = points.OrderBy(point => Math.Atan2(point.Y - lowestPoint.Y, point.X - lowestPoint.X)).ToList();

            Stack<Point> hull = new Stack<Point>();
            hull.Push(lowestPoint);
            hull.Push(sortedPoints[0]);
            hull.Push(sortedPoints[1]);

            for (int i = 2; i < sortedPoints.Count; i++)
            {
                Point top = hull.Pop();
                while (Orientation(NextToTop(hull), top, sortedPoints[i]) != -1)
                {
                    top = hull.Pop();
                }
                hull.Push(top);
                hull.Push(sortedPoints[i]);
            }

            return hull;
        }



        private void DrawHull(Stack<Point> hull, PictureBox pictureBox)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                if (hull.Count > 0)
                {
                    Point prev = hull.Peek(); // Start with the last point
                    foreach (var point in hull)
                    {
                        g.DrawLine(Pens.Black, prev, point);
                        prev = point;
                    }
                    g.DrawLine(Pens.Black, prev, hull.Peek()); // Close the hull
                }

                // Draw points
                foreach (var point in points)
                {
                    g.FillEllipse(Brushes.Red, point.X - 2, point.Y - 2, 4, 4);
                }
            }
            pictureBox.Image = bitmap;
        }

        private static Point NextToTop(Stack<Point> stack)
        {
            Point top = stack.Pop();
            Point nextToTop = stack.Peek();
            stack.Push(top);
            return nextToTop;
        }

        private static int Orientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
            return val == 0 ? 0 : (val > 0 ? 1 : -1); // 0: collinear, 1: clockwise, -1: counter-clockwise
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();


            SolidBrush redBrush = new SolidBrush(Color.Red);

            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);

            // Fill rectangle to screen.
            /*g.FillRectangle(new SolidBrush(Color.White), rect);
            for (int i = 0; i < pointsss.Count; i++)
            {


                // Create rectangle for ellipse.
                int x = pointsss[i].X;
                int y = pointsss[i].Y;
                int width = 10;
                int height = 10;
                Rectangle rect2 = new Rectangle(x, y, width, height);

                // Fill ellipse on screen.
                g.FillEllipse(redBrush, rect2);
            }*/


        }





        private void button2_Click(object sender, EventArgs e)
        {
           // ParallelGrahamScan(pointsss);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }


  
}
