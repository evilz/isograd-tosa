using System;
using System.Linq;

namespace MeilleurDevDeFranceMars2016._1._1Peugeot
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            var nbOfDays = int.Parse(input.ReadLine());

            var nbCarsByDays = Enumerable.Range(0, nbOfDays)
                .Select(i => input.ReadLine())
                .Select(int.Parse).ToArray();

            Console.WriteLine(nbCarsByDays.Sum());

        }
    }
}
