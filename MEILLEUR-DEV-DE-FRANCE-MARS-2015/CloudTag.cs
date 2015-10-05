using System;
using System.Linq;

namespace TOSA.CloudTag
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            var tagCount = int.Parse(input.ReadLine());
            
            Enumerable.Range(0,tagCount)
                .Select(i=>input.ReadLine())
                .GroupBy(s => s)
                .OrderByDescending(group => group.Count())
                .Take(5)
                .ForEach(pair => Console.WriteLine(pair.Key + " " + pair));
        }
    }
}
