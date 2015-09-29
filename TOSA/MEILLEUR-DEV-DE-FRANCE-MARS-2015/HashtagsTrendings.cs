using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TOSA.Trending
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.In;

            var tagCount = int.Parse(input.ReadLine());
            var queue = new FixedSizeQueue<string>(60);

            for (int i = 0; i < tagCount; i++)
            {
                queue.Enqueue(input.ReadLine());

                var check = queue.GroupBy(s => s)
                    .Where(g => g.Count() >= 40);
                if (check.Any())
                {
                    Console.WriteLine(check.First().Key);
                    return;
                }
            }
            
            Console.WriteLine("Pas de trending topic");
        }

        public class FixedSizeQueue<T> : IEnumerable<T>
        {
            private readonly Queue<T> _innerQueue = new Queue<T>();

            private readonly int _limit;
            public FixedSizeQueue(int limit) 
            {
                _limit = limit;
            }

            public void Enqueue(T item)
            {
               _innerQueue.Enqueue(item);
                if (_innerQueue.Count > _limit)
                    _innerQueue.Dequeue();
            }

            public IEnumerator<T> GetEnumerator()
            {
                return _innerQueue.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}