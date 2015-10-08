using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TOSA.MEILLEUR.DEV.ITEC.evacuation
{


    public class Program
    {

        static void Main(string[] args)
        {

//            var sampleYES = @"1 6 4
//100000 8 10 5 10 100000";
//            var input = new StringReader(sample);
            var input = Console.In;

            var size = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var width = size[0];
            var length = size[1];
            var height = size[2];

            var matrix = Enumerable.Range(0, width)
                .SelectMany(
                    y =>
                        input.ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .Select((h, x) => new Tuple<Point, bool>(new Point(x, y), h >= height)))
                            .Where(tuple => tuple.Item2)
                            .Select(tuple => tuple.Item1)
                            .ToList();

           var start = matrix.First(p => p.X == 0 && p.Y == 0);
           var end = matrix.First(p => p.X == height - 1 && p.Y == width - 1);

            Func<Point, IEnumerable<Point>> getNeighbours = n =>
            {
                var x = n.X;
                var y = n.Y;
                //top
                var top = matrix.FirstOrDefault(p => p.Y == y - 1);
                var right = matrix.FirstOrDefault(p => p.X == x + 1);
                var bottom = matrix.FirstOrDefault(p => p.Y == y - 1);
                var left = matrix.FirstOrDefault(p => p.X == x + 1);


                var neighbours = new List<Point>();

                if (top != Point.Empty) neighbours.Add(top);
                if (right != Point.Empty) neighbours.Add(right);
                if (bottom != Point.Empty) neighbours.Add(bottom);
                if (left != Point.Empty) neighbours.Add(left);

                return neighbours;

            };


            Func<Point, Point, double> manathan = (node1, node2) =>
            {
                return Math.Abs(node1.X - node2.X) + Math.Abs(node1.Y - node2.Y);
            };


            Func<Point, double> estimate = point =>
            {
                return manathan(point, end);
            };


            var path = FindPath<Point>(start, end, getNeighbours, manathan, estimate);

            if (path == null)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }

        public static Path<N> FindPath<N>(
       N start,
       N destination,
       Func<N,IEnumerable<N>> getNeighbours, Func<N, N, double> distance,
       Func<N, double> estimate)
        {
            var closed = new HashSet<N>();
            var queue = new PriorityQueue<double, Path<N>>();
            queue.Enqueue(0, new Path<N>(start));
            while (!queue.IsEmpty)
            {
                var path = queue.Dequeue();
                if (closed.Contains(path.LastStep))
                    continue;
                if (path.LastStep.Equals(destination))
                    return path;
                closed.Add(path.LastStep);

                var neighbours = getNeighbours(path.LastStep);
                foreach (N n in neighbours)
                {
                    double d = distance(path.LastStep, n);
                    var newPath = path.AddStep(n, d);
                    queue.Enqueue(newPath.TotalCost + estimate(n), newPath);
                }
            }
            return null;
        }

    }

    public interface IHasNeighbours<T>
    {
        IEnumerable<T> Neighbours { get; }
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
