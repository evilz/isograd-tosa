using System;
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

            var groupByType = ( from y in Enumerable.Range(0, H)
                                from x in Enumerable.Range(0, L)
                                select new {y, x})
                            .ToLookup(arg => matrix[arg.y][arg.x]);

            Func<int, int, int, int, int> manathan = (x1, x2, y1, y2) => Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

            var terres = groupByType[TerreFerme];
            var sables = groupByType[SableMouvant];

            var maxDistance = (from s in sables
                               from t in terres
                               group manathan(t.x,s.x,t.y,s.y) by s
                               into gDistance
                                select gDistance.Min()
                                )
                                .Max();
            
            Console.WriteLine(maxDistance);
        }
    }

}