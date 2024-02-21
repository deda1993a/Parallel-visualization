using System.Collections.Concurrent;
using System.Diagnostics;

namespace Parallel_visualization
{

    public class HPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public HPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static HPoint operator -(HPoint a, HPoint b)
        {
            return new HPoint(a.X - b.X, a.Y - b.Y);
        }

        public static double Cross(HPoint O, HPoint A, HPoint B)
        {
            return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
        }
    }

    class PolarComparer : IComparer<HPoint>
    {
        private HPoint pivot;

        public PolarComparer(HPoint pivot)
        {
            this.pivot = pivot;
        }

        public int Compare(HPoint a, HPoint b)
        {
            if (a == b)
                return 0;

            double cross = HPoint.Cross(pivot, a, b);

            if (cross > 0)
                return -1;
            if (cross < 0)
                return 1;

            double distanceA = Math.Pow(pivot.X - a.X, 2) + Math.Pow(pivot.Y - a.Y, 2);
            double distanceB = Math.Pow(pivot.X - b.X, 2) + Math.Pow(pivot.Y - b.Y, 2);

            return distanceA.CompareTo(distanceB);
        }
    }

    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public static List<HPoint> ComputeConvexHull(List<HPoint> pointss)
        {
            if (pointss.Count <= 1)
                return pointss.ToList();

            // Find pivot
            HPoint pivot = pointss[0];
            foreach (HPoint p in pointss)
            {
                if (p.Y < pivot.Y || (p.Y == pivot.Y && p.X < pivot.X))
                    pivot = p;
            }

            // Sort pointss by polar angle with pivot
            pointss = pointss.OrderBy(p => p, new PolarComparer(pivot)).ToList();

            // Divide pointss among threads
            var partitioner = Partitioner.Create(0, pointss.Count);
            ConcurrentBag<List<HPoint>> localHulls = new ConcurrentBag<List<HPoint>>();

            Parallel.ForEach(partitioner, (range, state) =>
            {
                var localHull = SequentialGrahamScan(pointss.GetRange(range.Item1, range.Item2 - range.Item1));
                localHulls.Add(localHull);
            });

            // Merge local hulls into the global hull
            var globalHull = MergeLocalHulls(localHulls);

            return globalHull;
        }

        private static List<HPoint> SequentialGrahamScan(List<HPoint> pointss)
        {
            if (pointss.Count <= 1)
                return pointss;

            Stack<HPoint> hull = new Stack<HPoint>();
            hull.Push(pointss[0]);
            hull.Push(pointss[1]);

            for (int i = 2; i < pointss.Count; i++)
            {
                HPoint top = hull.Pop();
                while (hull.Count != 0 && HPoint.Cross(hull.Peek(), top, pointss[i]) <= 0)
                    top = hull.Pop();
                hull.Push(top);
                hull.Push(pointss[i]);
            }

            return hull.ToList();
        }

        private static List<HPoint> MergeLocalHulls(ConcurrentBag<List<HPoint>> localHulls)
        {
            // Simple hull merging, assumes local hulls are small compared to total pointss
            // For more efficient merging, consider implementing a more sophisticated algorithm
            var pointss = localHulls.SelectMany(h => h).Distinct().ToList();
            pointss.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));
            return SequentialGrahamScan(pointss);
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
    }


  
}
