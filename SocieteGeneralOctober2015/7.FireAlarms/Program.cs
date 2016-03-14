using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace SocieteGeneralOctober2015._7.FireAlarms
{

    internal class Program
    {

        private static void Main(string[] args)
        {
           // var sample = File.ReadAllText(@"C:\Users\Vincent\Documents\GITHUB\isograd-tosa\SocieteGeneralOctober2015\7.FireAlarms\samples\input1.txt");

           // var input = new StringReader(sample);

            var input = Console.In;

            var size = input.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var width = size[0];
            var length = size[1];

            // Rows 2 to W + 1: L characters representing either:
            // - a bank 'B';
            // - a fire station 'F';
            // - an empty space '.'(dot).
            var map = (from i in Enumerable.Range(0, width)
                       select input.ReadLine().ToCharArray())
                .ToArray();

            var fireStations = map.SelectMany(
                (arg, x) => arg
                    .Select((c, y) => new { c, p = new Point(x, y)})
                .Where(arg1 => arg1.c == 'F')
                .Select(arg1 => arg1.p))
                .ToList();


            // Row W + 2: an integer N between 1 and 20,000 representing the number of fire alarms in the city.
            var nbFireAlarm = int.Parse(input.ReadLine());

            // Rows W + 3 to W + 2 + N: two space-separated integers I and J representing the coordinates of a detected fire in a bank of the city.
            var fires = (from i in Enumerable.Range(0, nbFireAlarm)
                         select input.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray())
                .Select(ints => new Point(ints[0], ints[1]))
                .ToArray();
            
            Func<Point, IEnumerable<Point>> getNeighbours = (n) =>
            {
                var x = n.X;
                var y = n.Y;
                var neighbours = new List<Point>();

                //top
                if (y > 0) { neighbours.Add(new Point(x, y - 1)); }
                //right
                if (x < width-1) { neighbours.Add(new Point(x + 1, y)); }
                //bottom
                if (y < length-1) { neighbours.Add(new Point(x, y + 1)); }
                // left
                if (x > 0) { neighbours.Add(new Point(x - 1, y)); }

                return neighbours;

            };

            Func<Point, Point, double> manathan = 
                (node1, node2) => { return Math.Abs(node1.X - node2.X) + Math.Abs(node1.Y - node2.Y); };

            Func<Point, Point, IEnumerable<Point>> FilterNeighbours = (n, end) =>
            {
                return getNeighbours(n)
                    .Where(point => map[point.X][point.Y] == '.'
                                    || (point.X == end.X && point.Y == end.Y));
            };

            var costList = new List<int>();
            foreach (var fire in fires)
            {
                var possibleDestWithHeuristic = fireStations
                    .Select(point => new {point = point,heuristic = manathan(fire, point) })
                    .OrderBy(x =>x.heuristic );

                var best = int.MaxValue;
                foreach (var dest in possibleDestWithHeuristic)
                {
                    var path = FindPath(fire, dest.point, point => FilterNeighbours(point, dest.point), manathan,
                        point => manathan(point, dest.point));

                    if (path != null)
                    {
                        best = Math.Min(best,(int)path.TotalCost);
                        if(best <= possibleDestWithHeuristic.Where(arg => arg.point != dest.point).Min(arg => arg.heuristic))
                        break;
                    }

                }
                costList.Add(best == int.MaxValue ? -1 : best);
            }


           //var firePathCost = (from fire in fires
           //                     from firestation in fireStations
           //                     let path = FindPath(fire, firestation, point =>  FilterNeighbours(point,firestation), manathan, point => manathan(point, firestation))
           //                     select new {fire, pathCost = path == null ? int.MaxValue : (int)path.TotalCost })
           //                     .GroupBy(arg => arg.fire)
           //                     .ToDictionary(grouping => grouping.Key,grouping => grouping.Min(arg => arg.pathCost))
           //                    ;

           // var costList = fires.Select(point => firePathCost[point] == int.MaxValue ? -1 : firePathCost[point]);
            var result = string.Join(" ", costList);
            Console.WriteLine(result);
            
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
                foreach (var n in neighbours)
                {
                    double d = distance(path.LastStep, n);
                    var newPath = path.AddStep(n, d);
                    queue.Enqueue(newPath.TotalCost + estimate(n), newPath);
                }
            }
            return null;
        }
    }

    internal class PriorityQueue<P, V>
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

        public Path(Node start) : this(start, null, 0)
        {
        }

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
