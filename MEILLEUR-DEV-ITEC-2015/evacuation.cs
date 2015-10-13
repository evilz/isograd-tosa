using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace TOSA.MEILLEUR.DEV.ITEC.evacuation
{


    public class Program
    {

        static void Main(string[] args)
        {

            //            var sampleYES = @"1 6 4
            //100000 8 10 5 10 100000";


//            var sampleNO = @"4 5 2
//100000 4 1 4 5
//5 4 4 3 3
//4 2 1 3 1
//2 3 2 1 100000";

                      //  var input = new StringReader(sampleNO);
            var input = Console.In;

            var size = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var width = size[0];
            var length = size[1];
            var height = size[2];

            var map = (from i in Enumerable.Range(0, width)
                       from line in input.ReadLine().Split(new[] { ' ' }).ToArray()
                       select int.Parse(line) >= height)
                    .ToArray();
            
            var start = new Point(0, 0);
            var end = new Point(width-1, length-1);

            Func<int, int, int> GetIndex = (x, y) => { return x*length + y; };

            Func<Point, IEnumerable<Point>> getNeighbours = n =>
            {
                var x = n.X;
                var y = n.Y;
                var neighbours = new List<Point>();

                var index = -1;
                //top
                index = GetIndex(x, y - 1);
                if (y > 0 && index < length * width && map[index] ) { neighbours.Add(new Point(x, y - 1)); }
                //right
                index = GetIndex(x+1, y);
                if (x<width && index < length * width && map[index]) { neighbours.Add(new Point(x + 1, y)); }
                //bottom
                index = GetIndex(x, y + 1);
                if (y < length && index < length * width && map[index]) { neighbours.Add(new Point(x, y + 1)); }
                // left
                index = GetIndex(x - 1, y);
                if (x > 0 && index < length * width && map[index]) { neighbours.Add(new Point(x - 1, y)); }

                var t = neighbours.ToArray();
                return neighbours;

            };
            
            Func<Point, Point, double> manathan = (node1, node2) => { return Math.Abs(node1.X - node2.X) + Math.Abs(node1.Y - node2.Y); };
            
            Func<Point, double> estimate = point => { return manathan(point, end); };


            var path = FindPath(start, end, getNeighbours, manathan, estimate);

            Console.WriteLine(path == null ? "NO" : "YES");
        }

        public static Path<T> FindPath<T>(
       T start,
       T destination,
       Func<T, IEnumerable<T>> getNeighbours, Func<T, T, double> distance,
       Func<T, double> estimate)
        {
            var closed = new HashSet<T>();
            var queue = new PriorityQueue<double, Path<T>>();
            queue.Enqueue(0, new Path<T>(start));
            while (!queue.IsEmpty)
            {
                var path = queue.Dequeue();
                if (closed.Contains(path.LastStep))
                    continue;
                if (path.LastStep.Equals(destination))
                    return path;
                closed.Add(path.LastStep);

                var neighbours = getNeighbours(path.LastStep);
                foreach (T n in neighbours)
                {
                    double d = distance(path.LastStep, n);
                    var newPath = path.AddStep(n, d);
                    queue.Enqueue(newPath.TotalCost + estimate(n), newPath);
                }
            }
            return null;
        }

    }

    class PriorityQueue<P, V>
    {
        private SortedDictionary<P, Queue<V>> list = new SortedDictionary<P, Queue<V>>();
        public void Enqueue(P priority, V value)
        {
            Queue<V> q;
            if (!list.TryGetValue(priority, out q))
            {
                q = new Queue<V>();
                list.Add(priority, q);
            }
            q.Enqueue(value);
        }
        public V Dequeue()
        {
            // will throw if there isn’t any first element!
            var pair = list.First();
            var v = pair.Value.Dequeue();
            if (pair.Value.Count == 0) // nothing left of the top priority.
                list.Remove(pair.Key);
            return v;
        }
        public bool IsEmpty
        {
            get { return !list.Any(); }
        }
    }

    public class Path<Node> : IEnumerable<Node>
    {
        public Node LastStep { get; private set; }
        public Path<Node> PreviousSteps { get; private set; }
        public double TotalCost { get; private set; }
        private Path(Node lastStep, Path<Node> previousSteps, double totalCost)
        {
            LastStep = lastStep;
            PreviousSteps = previousSteps;
            TotalCost = totalCost;
        }
        public Path(Node start) : this(start, null, 0) { }
        public Path<Node> AddStep(Node step, double stepCost)
        {
            return new Path<Node>(step, this, TotalCost + stepCost);
        }
        public IEnumerator<Node> GetEnumerator()
        {
            for (Path<Node> p = this; p != null; p = p.PreviousSteps)
                yield return p.LastStep;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
