using System;
using System.IO;
using System.Linq;

namespace SocieteGeneralOctober2016._1.a
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            //var input = new StringReader("string");
            //input = File.OpenText(@"sample\input1.txt");
            
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

            //Utils.LocalPrint(count.ToString());
            //Utils.LocalPrintArray(new List<object>());

        }
    }
}
