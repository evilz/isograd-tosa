using System;
using System.Linq;

namespace SocieteGeneralOctober2015._1.ClosingBalance
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            var openingBalance = int.Parse(input.ReadLine());
            var count = int.Parse(input.ReadLine());

            var final = Enumerable.Range(0, count)
                          .Select(i => input.ReadLine().Split(' ').Select(int.Parse).First())
                          .Aggregate(openingBalance, (current, transaction) => current + transaction);

            Console.WriteLine(final);

        }
    }
}
