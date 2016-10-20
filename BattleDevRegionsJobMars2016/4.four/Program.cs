using System;
using System.IO;
using System.Linq;

namespace BattleDevRegionsJobMars2016._4.four
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var input = Console.In;
            var input = File.OpenText("4.four/samples/input1.txt");

            // READ COUNT
            var count = int.Parse(input.ReadLine());

            // READ LINES of INTs
            var pylone = Enumerable.Range(0, count)
                .Select(i => input.ReadLine())
                .Select(int.Parse)
                .ToArray();


            for (int i = 0; i < pylone.Length; i++)
            {
                var nb = 0;
                var maxbetten = 0;
                for (int j = 0; j < pylone.Length; j++)
                {
                    if (i == j)
                    {
                        maxbetten = 0;
                        continue;
                    }

                    var p1 = pylone[i];
                    var p2 = pylone[j];


                    // visible depuis un autre s'il n'existe pas de pylône 
                    // entre eux qui soit d'une hauteur supérieure ou égale à l'un ou l'autre.
                    if ( p2 > maxbetten)
                    {
                        nb++;
                    }
                    

                    maxbetten = Math.Max(maxbetten, p2);


                }
                Console.Write(nb + " ");
            }


        }
    }
}
