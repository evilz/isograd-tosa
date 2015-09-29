using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace TOSA.Poker
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            var initHand = int.Parse(input.ReadLine());
            var turnCount = int.Parse(input.ReadLine());

            var currentHand = initHand;

            var finalHand = Enumerable.Range(0, turnCount)
                .Select(i => input.ReadLine().Split(' ').Select(int.Parse).ToArray())
                .Aggregate(currentHand, (current, turn) => current - turn[0] - turn[1]);
             
            Console.WriteLine(finalHand);
        }
    }

}
