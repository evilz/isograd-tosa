using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;


namespace TOSA.CloudTag
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            var tagCount = int.Parse(input.ReadLine());

            var tags = new List<string>();
            
            Enumerable.Range(0,tagCount)
                .Select(i=>input.ReadLine())
                .GroupBy(s => s)
                .OrderByDescending(ints => ints.Count())
                .Take(5)
                .ForEach(pair => Console.WriteLine(pair.Key + " " + pair));
        }
    }
}
