using System.Diagnostics;

namespace Parallel_visualization
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        List<HPoint> pointss = new List<HPoint>
        {
            new HPoint(20, 20),
            new HPoint(30, 20),
            new HPoint(40, 20),
            new HPoint(40, 45),
            new HPoint(70, 55),
            new HPoint(100, 45),
            new HPoint(120, 55),
        };

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();


            SolidBrush redBrush = new SolidBrush(Color.Red);

            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);

            // Fill rectangle to screen.
            g.FillRectangle(new SolidBrush(Color.White), rect);
            for (int i = 0; i < pointss.Count; i++)
            {


                // Create rectangle for ellipse.
                int x = pointss[i].X;
                int y = pointss[i].Y;
                int width = 10;
                int height = 10;
                Rectangle rect2 = new Rectangle(x, y, width, height);

                // Fill ellipse on screen.
                g.FillEllipse(redBrush, rect2);
            }


        }



        //List<HPoint> convexHull = ParallelGrahamScan(pointss);

        static List<HPoint> ParallelGrahamScan(List<HPoint> pointss)
        {
            if (pointss.Count < 3)
                throw new ArgumentException("Convex hull requires at least 3 pointss.");

            HPoint[] sortedPointss = SortPointssByPolarAngle(pointss.ToArray());

            Stack<HPoint> hull = new Stack<HPoint>();
            hull.Push(sortedPointss[0]);
            hull.Push(sortedPointss[1]);

            object lockObject = new object();

            Parallel.For(2, sortedPointss.Length, i =>
            {
                HPoint top;

                lock (lockObject)
                {
                    top = hull.Pop();
                }

                while (Orientation(hull.Peek(), top, sortedPointss[i]) != OrientationType.COUNTERCLOCKWISE)
                {
                    lock (lockObject)
                    {
                        top = hull.Pop();
                    }
                }

                lock (lockObject)
                {
                    hull.Push(top);
                    hull.Push(sortedPointss[i]);
                }
            });

            foreach (HPoint pts in hull)
            {
                Debug.WriteLine(pts);
            }


            return hull.ToList();
        }

        static HPoint[] SortPointssByPolarAngle(HPoint[] pointss)
        {
            HPoint anchor = FindAnchorPoint(pointss);
            return pointss.AsParallel().OrderBy(p => PolarAngle(anchor, p)).ToArray();
        }

        static HPoint FindAnchorPoint(HPoint[] pointss)
        {
            return pointss.Aggregate((min, p) => (p.Y < min.Y || (p.Y == min.Y && p.X < min.X)) ? p : min);
        }

        static double PolarAngle(HPoint anchor, HPoint point)
        {
            return Math.Atan2(point.Y - anchor.Y, point.X - anchor.X);
        }

        static OrientationType Orientation(HPoint p, HPoint q, HPoint r)
        {
            double value = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (Math.Abs(value) < double.Epsilon)
                return OrientationType.COLLINEAR;

            return (value > 0) ? OrientationType.COUNTERCLOCKWISE : OrientationType.CLOCKWISE;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParallelGrahamScan(pointss);

        }
    }

    class HPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public HPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    enum OrientationType
    {
        COLLINEAR,
        CLOCKWISE,
        COUNTERCLOCKWISE
    }
}
