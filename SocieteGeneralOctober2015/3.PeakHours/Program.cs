using System;
using System.Linq;

namespace SocieteGeneralOctober2015._3.PeakHours
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            var totalNumberOfPeople = int.Parse(input.ReadLine());
            
            var workTimes = Enumerable.Range(0, totalNumberOfPeople)
                .Select(i => input.ReadLine().Split(' ').Select(int.Parse).ToArray())
                .SelectMany(ints => Enumerable.Range(ints[0], ints[1] - ints[0]))
                .GroupBy(i => i)
                .OrderByDescending(ints => ints.Count())
                .Select(ints => ints)
                .ToList();
            
            var max = workTimes.Select(ints => ints.Count()).First();

            var result = string.Join(" ", workTimes.Where(i => i.Count() == max).Select(ints => ints.Key));
            Console.WriteLine(result);
        }
    }
}
