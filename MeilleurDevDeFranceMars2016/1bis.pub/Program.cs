using System;
using System.Linq;

namespace MeilleurDevDeFranceMars2016._1bis.pub
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            //var input = File.OpenText("CURRENT_FOLDER_NAME/samples/input1.txt");

            // READ COUNT
            var X = int.Parse(input.ReadLine());
            var N = int.Parse(input.ReadLine());

          
            // READ LINES of string
            var linesOfString = Enumerable.Range(0, N)
                .Select(i => input.ReadLine())
                .Select(int.Parse)
                .ToArray();

           var result = linesOfString.Aggregate(X, (current, next) => current - next);

          //  Utils.LocalPrint(count.ToString());
          //  Utils.LocalPrintArray(new List<object>());

            Console.WriteLine(result);

        }
    }
}
