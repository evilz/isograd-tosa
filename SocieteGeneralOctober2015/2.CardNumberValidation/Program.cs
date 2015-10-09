using System;
using System.Linq;

namespace SocieteGeneralOctober2015._2.CardNumberValidation
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.In;

            var count = int.Parse(input.ReadLine());

            var valids = 0;
            Enumerable.Range(0, count)
                .Select(i => input.ReadLine())
                .ToList()
                .ForEach(s =>
                {
                    var LuhneKey = int.Parse(s.Last().ToString());

                    var first15 = s.Substring(0, 15).Select(c => c)
                        .Select(c => int.Parse(c.ToString()))
                        .ToArray();

                    for (var i = 0; i < 15; i++)
                    {
                        if (i%2 != 0) continue;

                        first15[i] = first15[i]*2;
                        if (first15[i] > 9)
                            first15[i] -= 9;
                    }

                    var sum = first15.Sum() + LuhneKey;
                    var isValid = sum%10 == 0;

                    if (isValid)
                        valids++;
                }
                );
            Console.WriteLine(valids);
        }
    }
}
