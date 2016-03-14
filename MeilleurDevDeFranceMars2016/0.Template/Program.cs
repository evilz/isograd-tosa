using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDevRegionsJobNovembre2015._1.Moyenne_du_bulletin_scolaire
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            // READ COUNT
            var count = int.Parse(input.ReadLine());

            // READ LINES of INTs
            var lines = Enumerable.Range(0, count)
                .Select(i => input.ReadLine().Split(' ').Select(int.Parse).ToArray());

            // READ LINES of string
            var linesOfString = Enumerable.Range(0, count)
                .Select(i => input.ReadLine())
                .ToArray();


            Utils.LocalPrint(count.ToString());
            Utils.LocalPrintArray(new List<object>());

            Console.WriteLine(string.Empty);

        }
    }
}
