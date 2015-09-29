using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOSA
{
    public static class Utils
    {
        public static void LocalPrint(string message)
        {
            Console.WriteLine(message);
        }

        public static void LocalPrintArray(IEnumerable<object> collection)
        {
            collection.ForEach(Console.WriteLine);
        }
    }
}
