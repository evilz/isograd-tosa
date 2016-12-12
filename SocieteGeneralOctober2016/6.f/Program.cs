using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SocieteGeneralOctober2016._6.f
{

    public class Dijkstra
    {

        class PriorityQueue<TPriority, TItem> : IEnumerable<KeyValuePair<TPriority, TItem>>
        {
            readonly SortedDictionary<TPriority, Queue<TItem>> _subqueues;

            public PriorityQueue()
            {
                _subqueues = new SortedDictionary<TPriority, Queue<TItem>>(Comparer<TPriority>.Default);
            }

            public void Enqueue(TPriority priority, TItem item)
            {
                if (!_subqueues.ContainsKey(priority))
                {
                    _subqueues.Add(priority, new Queue<TItem>());
                }

                _subqueues[priority].Enqueue(item);
            }

            public KeyValuePair<TPriority, TItem> Dequeue()
            {
                if (_subqueues.Any())
                {
                    var first = _subqueues.First();
                    var nextItem = first.Value.Dequeue();
                    if (!first.Value.Any())
                    {
                        _subqueues.Remove(first.Key);
                    }
                    return new KeyValuePair<TPriority, TItem>(first.Key, nextItem);
                }
                else
                    throw new InvalidOperationException("The queue is empty");
            }

            public IEnumerator<KeyValuePair<TPriority, TItem>> GetEnumerator()
            {
                var q = _subqueues.SelectMany(pair => pair.Value.Select(item => new KeyValuePair<TPriority, TItem>(pair.Key, item)));
                return q.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)_subqueues).GetEnumerator();
            }
        }

        public static IEnumerable<T> Explore<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, T, int> getCost, Func<T, bool> isEnd = null)
        {
            return dijkstra(start, getNeighbours, getCost, false, isEnd);
        }

        private static IEnumerable<T> dijkstra<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, T, int> getCost, bool pathOnly,
            Func<T, bool> isEnd = null)
        {
            var visitedFrom = new Dictionary<T, T>();
            var toVisit = new PriorityQueue<int, T>();
            toVisit.Enqueue(0, start);
            visitedFrom.Add(start, default(T));

            while (toVisit.Any())
            {
                var currentNode = toVisit.Dequeue();
                var current = currentNode.Value;
                var currentCost = currentNode.Key;


                if (!pathOnly)
                {
                    yield return current;
                }

                if (isEnd != null && isEnd(current))
                {
                    if (pathOnly)
                    {
                        var path = new Queue<T>();

                        while (!current.Equals(start))
                        {
                            path.Enqueue(current);
                            current = visitedFrom[current];
                        }
                        path.Enqueue(current);
                        while (path.Any())
                        {
                            yield return path.Dequeue();
                        }

                    }
                    yield break;
                }

                var neighbours = getNeighbours(current)
                    .Where(n => !visitedFrom.ContainsKey(n))
                    .Reverse()
                    .ToList();
                foreach (var neighbour in neighbours)
                {
                    toVisit.Enqueue(currentCost + getCost(current, neighbour), neighbour); // <= add move cost here !
                    visitedFrom.Add(neighbour, current);
                }
            }

        }

        public static IEnumerable<T> FindPath<T>(T start, Func<T, IEnumerable<T>> getNeighbours, Func<T, T, int> getCost, Func<T, bool> isEnd = null)
        {
            return dijkstra(start, getNeighbours, getCost, true, isEnd);
        }
    }

    public class Program
    {

        public class Node
        {
            public string Word { get; private set; }

            public Node(string word)
            {
                Word = word;
                Children = new List<Node>();
            }

            public List<Node> Children { get; private set; }
        }

        static void Main(string[] args)
        {
            //var input = Console.In;
            var input = new StringReader("3\nTIC\nBAC\n5\nTOC\nTIC\nBOC\nBIC\nBAC");

            var L = int.Parse(input.ReadLine());
            var WORD = input.ReadLine();
            var WORD2 = input.ReadLine();
            var N = int.Parse(input.ReadLine());


            var many = Enumerable.Range(0, N)
                .Select(_ =>
                    input.ReadLine())
                        .ToArray();

            var nodes = many.Select(s => new Node(s)).ToDictionary(node => node.Word, node => node);

            var queue = new Queue<string>();

            foreach (var node in nodes)
            {
                


                foreach (var node2 in nodes.Where(pair => pair.Key != node.Key))
                {
                    var change = 0;
                    for (int i = 0; i < node.Value.Word.Length; i++)
                    {
                        if (node.Key[i] != node2.Key[i])
                            change++;
                    }
                    if(change < 2)
                    { node.Value.Children.Add(node2.Value);}
                }


               
            }

            queue.Enqueue(WORD2);
            var currentWord = WORD2;


           var path = Dijkstra.FindPath(WORD2,
                s => nodes.Values.Where(node => node.Children.Any(node1 => node1.Word == s)).Select(node => node.Word),
                (s, s1) => 1, 
                s => s == WORD);

            if (path.Any())
            {
                 var output = string.Join(" ", path);

            Console.WriteLine(output);

            }
            else
            {
                Console.WriteLine("IMPOSSIBLE");
            }
           
        }


    }
}
