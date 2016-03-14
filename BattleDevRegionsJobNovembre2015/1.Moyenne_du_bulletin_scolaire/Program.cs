using System;
using System.Linq;

namespace BattleDevRegionsJobNovembre2015._1.Moyenne_du_bulletin_scolaire
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            var count = int.Parse(input.ReadLine());

            var reuslt = (int)Enumerable.Range(0, count)
                .Select(i => input.ReadLine())
                .Select(int.Parse)
                .Average();

            Console.WriteLine(reuslt);

        }
    }
}
