using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TOSA.BATTLEDEVESILV.ScoreDeScrabble
{
    public class Program
    {
        static void Main(string[] args)
        {

//            var sample = @"7
//22 13 9 16 24 3 29
//7 19 18 27 5 21 30
//0 27 16 15 12 6 16
//14 23 25 21 4 7 13
//14 25 19 21 30 22 10
//26 12 0 8 3 11 12
//30 23 12 20 25 4 6";
//            var input = new StringReader(sample);
            var input = Console.In;

            var size = int.Parse(input.ReadLine());

            var matrix = new int[size,size];

            for (int y = 0; y < size; y++)
            {
                var numbers = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int x = 0; x < size; x++)
                {
                    matrix[y, x] = numbers[x];
                }
            }

            var max = -1;
            var list = new List<Tuple<int,int>>();
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {

                    if (matrix[y, x] == max)
                    {
                        list.Add(new Tuple<int, int>(x,y));
                    }
                     else if (matrix[y, x] > max)
                     {
                         list.Clear();
                        list.Add(new Tuple<int, int>(x, y));
                    }
                    
                }
            }


           var best = list.OrderBy(tuple => Math.Sqrt(Math.Pow(tuple.Item1, 2) + Math.Pow(tuple.Item2, 2)))
                .First();

            Console.WriteLine((size - best.Item1) + " " + (size - best.Item2));
        }

    }


}

