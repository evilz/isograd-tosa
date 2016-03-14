using System;
using System.Linq;

namespace BattleDevRegionsJobNovembre2015._2.TV
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            var initial = 1.0;
            var numbers = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var T = numbers[0];
            var D = numbers[1];

            var total = Enumerable.Range(0, D).Aggregate(initial, (current, next) => current * (1 + T/100.0));
            
            var reuslt = Math.Round((total - initial)*100,2);

            Console.WriteLine(reuslt);

        }
    }
}
