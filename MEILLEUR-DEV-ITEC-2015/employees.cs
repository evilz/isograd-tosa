using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace TOSA.MEILLEUR.DEV.ITEC.employees
{


    /// <summary>
    /// - The first 6 correspond to the issuing bank,
    //- 9 digits are taken randomly,
    ///- the last digit is the Luhne key
    /// </summary>

    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            var totalNumberOfPeople = int.Parse(input.ReadLine());

            Utils.LocalPrint("totalNumberOfPeople: " + totalNumberOfPeople);

            var workTimes = Enumerable.Range(0, totalNumberOfPeople)
                .Select(i => input.ReadLine().Split(' ').Select(int.Parse).ToArray())
                .SelectMany(ints => Enumerable.Range(ints[0], ints[1] - ints[0]))
                .ToList();

            Utils.LocalPrint("workTimes.Count: " + workTimes.Count().ToString());

            var ordered = workTimes.GroupBy(i => i)
                .OrderByDescending(ints => ints.Count())
                .Select(ints => ints)
                .ToList();

            Utils.LocalPrint("ordered.Count: " + ordered.Count().ToString());

            var max = ordered.Select(ints => ints.Count()).First();

            Utils.LocalPrint("max: " + max.ToString());

            ordered.Where(i => i.Count() == max)
                .ToList().ForEach(i =>
                {

                    Utils.LocalPrint("RESULTAT: " + max.ToString());

                    Console.Write(i.Key);
                    Console.Write(" ");
                }
                );


        }


    }

}
