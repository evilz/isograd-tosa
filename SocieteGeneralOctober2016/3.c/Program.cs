using System;
using System.Linq;

namespace SocieteGeneralOctober2016._3.c
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            //var input = new StringReader("01000110\n01000001\n01000011\n01000101\n01000010\n01001111\n01001111\n01001011");

           
            var many = Enumerable.Range(0, 8)
                .Select(_ =>
                {
                    var raw = Convert.ToInt32(input.ReadLine(),2);
                    var c = (char)raw;
                    return c;
                })
                        .ToArray();

            var output = string.Join(String.Empty,many);

            Console.WriteLine(output);

        }
    }
}
