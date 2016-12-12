using System;
using System.Linq;

namespace SocieteGeneralOctober2016._4.d
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
          //var input = new StringReader("5 2 3.27\n1 2\n3 1\n0 4\n2 2\n3 7");

            var nubers = input.ReadLine().Split(' ').ToArray();
            var N = int.Parse(nubers[0]);
            var K = int.Parse(nubers[1]);
            var R = double.Parse(nubers[2]);

            var many = Enumerable.Range(0, N)
                .Select(i =>
                {
                    var corr = input.ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();
                    return new {id = i+1, x = corr[0], y = corr[1]};
                }
                    )
                        .ToArray();

            var ids = new List<string>();
            
            foreach (var p1 in many)
            {
                var distances =
                    many.Where(arg => arg.id != p1.id  ).Select(arg => Math.Sqrt(Math.Pow((arg.x - p1.x), 2) + Math.Pow((arg.y - p1.y), 2))).ToArray();

                var count =distances.Where(arg => arg <= R).Count();
                if (count >= K)
                {
                    ids.Add(p1.id.ToString());
                   
                }
            }

            if (ids.Any())
            {
                Console.WriteLine(string.Join(" ",ids));
            }
            else
            { var output = "No danger";

            Console.WriteLine(output);
            }

        }
    }
}
