using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace TOSA.TEMPLATE
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            var count = int.Parse(input.ReadLine());
            
            Utils.LocalPrint(count.ToString());
            Utils.LocalPrintArray(new List<object>());
          
            Console.WriteLine(count);
        }


    }

}
