using System;
using System.Collections.Generic;
using System.Linq;

namespace MeilleurDevDeFranceMars2016._0.Template
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            //var input = File.OpenText("CURRENT_FOLDER_NAME/samples/input1.txt");

            // READ COUNT
            var count = int.Parse(input.ReadLine());

            // READ LINES of INTs
            var lines = Enumerable.Range(0, count)
                .Select(i => input.ReadLine().Split(' ').Select(int.Parse).ToArray());

            // READ LINES of string
            var linesOfString = Enumerable.Range(0, count)
                .Select(i => input.ReadLine())
                .ToArray();


          //  Utils.LocalPrint(count.ToString());
          //  Utils.LocalPrintArray(new List<object>());

            Console.WriteLine(string.Empty);

        }
    }
}
