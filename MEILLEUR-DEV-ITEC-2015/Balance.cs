using System;
using System.Linq;

namespace TOSA.MEILLEUR.DEV.ITEC
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
                          .Aggregate(openingBalance, (current, trans) => current + trans);

            Console.WriteLine(final);

        }


    }

}
