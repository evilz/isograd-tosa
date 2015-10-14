using System;
using System.Linq;

namespace SocieteGeneralOctober2015.CashUsage
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            
            var count = int.Parse(input.ReadLine());

            var top10 = Enumerable.Range(0,count)
                .Select(i => input.ReadLine().Split(' ').ToArray())
                .Select(arg => new {id= arg[0],amount= int.Parse(arg[1]) })
                .GroupBy(arg => arg.id)
                .OrderByDescending(arg => arg.Sum(x => x.amount))
                .ThenBy(x => x.Key)
                .Select(x =>x.Key)
                .Take(10)
                .ToList();
            
            Console.Write(string.Join(" ", top10));
        }
    }
}
