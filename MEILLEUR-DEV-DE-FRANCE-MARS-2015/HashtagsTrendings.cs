using System;
using System.Linq;

namespace TOSA.Trending
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.In;

            var tagCount = int.Parse(input.ReadLine());

            var tags = Enumerable.Range(0, tagCount)
                .Select(i => input.ReadLine())
                .ToList();


            for (int i = 0; i < tagCount; i++)
            {
                var trending = tags
                    .Skip(i)
                    .Take(60)
                    .GroupBy(s => s)
                    .Where(grouping => grouping.Count() >= 40)
                    .Select(grouping => grouping.Key)
                    .FirstOrDefault();

                if (trending != null)
                {
                    Console.WriteLine(trending);
                    break;
                }
            }
            
            Console.WriteLine("Pas de trending topic");
        }

    }
}