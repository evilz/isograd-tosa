using System;
using System.Linq;

namespace SocieteGeneralOctober2016._2.b
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            //var input = new StringReader("10\n34\n4 3\n2 3\n3 1\n2 2\n4 3\n4 4\n3 1\n1 2\n3 1\n2 3\n1 2\n4 1\n2 3\n1 4\n1 3\n4 1\n1 2\n4 4\n2 1\n1 1\n3 1\n1 2\n2 1\n4 1\n2 1\n3 2\n2 3\n3 4\n1 4\n4 2\n2 3\n2 2\n1 1\n2 3");

            var s = int.Parse(input.ReadLine());
            var n = int.Parse(input.ReadLine());

            var steps = Enumerable.Range(0, n)
                .Select(_ =>
                    input.ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray())
                        .ToArray();

            var A = 0;
            var B = 0;
            for (int i = 0; i < steps.Length; i++)
            {
                A += steps[i][0];
                B += steps[i][1];
                if(A >= s && B >= s) Console.WriteLine("NO WINNER");
                if(A >= s ) Console.WriteLine("A");
                if(B >= s) Console.WriteLine("B");
            }

        }
    }
}
