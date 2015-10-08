using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace TOSA.MEILLEUR.DEV.ITEC.cashDispenser
{

    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;


            //            Input
            //Row 1 : an integer between 1 and 100,000 representing the amount that you have to deliver.
            //Row 2 : an integer N representing the number of types of notes that the cash dispenser can use.
            //Row 3 to N+2 : an integer between 1 and 50,000 representing the face values of the notes that are available. The notes are sorted ascendingly.

            //You can assume that the dispenser will always hold the right notes to match the withdrawal.

            //Output

            //A series of pairs of integers Xi and Yi separated by a space. 
            //For each type of note used to fill the order, Xi represents the number of notes of value Yi that you want to deliver.The pairs have to be sorted in descending order of Yi. If we take the example above, the output would be:
//            1 100 1 50 2 20

            var amount = int.Parse(input.ReadLine());
            var numberOfTypes = int.Parse(input.ReadLine());

            var faceValues = Enumerable.Range(0, numberOfTypes)
                .Select(i => input.ReadLine())
                .Select(int.Parse)
                .OrderByDescending(i => i)
                .ToList();

            Dictionary<int,int> dictionary =new Dictionary<int, int>();
            while (amount > 0)
            {
                var toUse = faceValues.First(i => i <= amount);

                if (!dictionary.ContainsKey(toUse))
                {
                    dictionary.Add(toUse,0);
                }

                dictionary[toUse] = dictionary[toUse] + 1;
                amount -= toUse;
            }


            foreach (var pair in dictionary)
            {
                Console.Write(pair.Value + " " + pair.Key + " ");
            }


        }


    }

}
