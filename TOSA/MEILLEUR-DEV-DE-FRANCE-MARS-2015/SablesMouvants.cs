using System;
using System.Collections.Generic;
using System.Linq;

namespace TOSA.SablesMouvants
{
    public class Program
    {
        static void Main(string[] args)
        {
            const char TerreFerme = '.';
            const char SableMouvant = '#';

            var input = Console.In;
            var size = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var H = size[0];
            var L = size[1];

            var matrix = Enumerable.Range(0, H)
                .Select(i => input.ReadLine().ToCharArray())
                .ToArray();

            var groupByType = (from y in Enumerable.Range(0, H)
                               from x in Enumerable.Range(0, L)
                               group new { y, x } by matrix[y][x] into g
                               select g)
                              .ToList();

            Func<int, int, int, int, int> manathan = (x1, x2, y1, y2) => Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

            var terres = groupByType.Where(g => g.Key == TerreFerme).SelectMany(g => g).ToList();
            var sables = groupByType.Where(g => g.Key == SableMouvant).SelectMany(g => g).ToList();

            var maxDistance = ( from t in terres
                                from s in sables
                                group manathan(t.x,s.x,t.y,s.y) by s
                                into gDistance
                                select gDistance.Min()
                )
                .Max();
            
            

            //var maxDistance = sables
            //                    .Select(s => terres
            //                                    .Select(t => manathan(s.x, t.x, s.y, t.y)).Min()
            //                            ).Max();
            

            Console.WriteLine(maxDistance);
        }
    }

}