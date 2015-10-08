using System;
using System.Collections.Generic;
using System.Linq;

namespace SocieteGeneralOctober2015.HandlingCashRequests
{

    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            
            var amount = int.Parse(input.ReadLine());
            var numberOfTypes = int.Parse(input.ReadLine());

            var faceValues = Enumerable.Range(0, numberOfTypes)
                .Select(i => input.ReadLine())
                .Select(int.Parse)
                .OrderByDescending(i => i)
                .ToList();

            var dictionary = new Dictionary<int, int>();

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
