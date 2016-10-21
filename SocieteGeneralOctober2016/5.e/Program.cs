using System;
using System.Linq;

namespace SocieteGeneralOctober2016._5.e
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            //var input = new StringReader("string");

            var count = int.Parse(input.ReadLine());

            var many = Enumerable.Range(0, count)
                .Select(_ =>
                    input.ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray())
                        .ToArray();

            var output = "";

            Console.WriteLine(output);

        }
    }
}
