using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace TOSA.MEILLEUR.DEV.ITEC.cashDispenserBis
{

    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;


            //            Data Format

            //Input
            //Row 1 : an integer N between 1 and 1000 indicating the number of entries in the log file.
            //Row 2 to N +1 : a string of 8 alphanumeric characters and an integer number between 10 and 1000 separated by a space. 
            //They represent the identifier of the cash dispenser and the amount withdrawn.

            //Output
            //The identifiers of the 10 dispensers that have distributed the most money ordered by descending amounts.
            //Identifiers should be separated by a space.
            //If there are less than 10 dispensers in the log file, display them all.If multiple dispensers have delivered the same amount of cash then order them by identifier in ascending order.

            var count = int.Parse(input.ReadLine());


            var identifiers = new Dictionary<string,int>();
            for (int a = 0; a < count; a++)
            {
                var split = input.ReadLine().Split(' ').ToArray();
                Utils.LocalPrint(split[0]);
                Utils.LocalPrint(split[1]);
                var amount = int.Parse(split[1]);
                var id = split[0];
                if (!identifiers.ContainsKey(id))
                {
                    identifiers.Add(id,0);
                }

                identifiers[id] = identifiers[id] + amount;
            }

            var ten = identifiers
                .OrderByDescending(arg => arg.Value)
                .ThenBy(args2 => args2.Key)
                .Take(10)
                .ToList();

            Console.Write(string.Join(" ", ten.Select(arg => arg.Key.ToString())));
            

        }


    }

}
