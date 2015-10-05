using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TOSA.BATTLEDEVESILV.DetectionDeSession
{
    public class Program
    {
        static void Main(string[] args)
        {

            var sample = "1 2 9 A B 11 3 4 5";
            var input = new StringReader(sample);
            //var input = Console.In;

            var sequence = input.ReadLine()
                .Split(' ')
                .Select(s => int.Parse(s, NumberStyles.HexNumber))
                .ToList();

            var result = new List<List<int>> { new List<int> { sequence.First() } };


            result = sequence.Skip(1).Aggregate(result, (list, i) =>
            {
                if (i == list.Last().Last() + 1)
                {
                    list.Last().Add(i);
                }
                else
                {
                    list.Add(new List<int> { i });
                }
                return list;
            });

            var max = result.Max(ints => ints.Count());
            var maxSession = result.First(ints => ints.Count() == max);
            foreach (var i in maxSession)
            {
                Console.Write(i.ToString("X") + " ");
            }

        }

    }


}

