using System.Collections.Generic;

namespace System
{
    public static class Utils
    {
        public static void LocalPrint(string message)
        {
            Console.WriteLine(message);
        }

        public static void LocalPrintArray(IEnumerable<object> source)
        {
            foreach (var o in source)
            {
                Console.WriteLine(o);
            }
        }
    }
}
