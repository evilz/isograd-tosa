using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace TOSA.MEILLEUR.DEV.ITEC.cardnumber
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

            var count = int.Parse(input.ReadLine());



            var valids = 0;
            Enumerable.Range(0,count)
                .Select(i => input.ReadLine())
                .ToList()
                .ForEach(s =>
                {
                    var first6 = s.Substring(0, 6);
                    var random9 = s.Substring(6, 9);
                    var LuhneKey = int.Parse(s.Last().ToString());

                    var first15 = s.Substring(0, 15).Select(c => c)
                        .Select(c => int.Parse(c.ToString()))
                        .ToArray();

                    for (int i = 0; i < 15; i++)
                    {
                        if (i%2 == 0)
                        {
                            first15[i] = first15[i]*2;
                            if (first15[i] > 9)
                                first15[i] -= 9;
                        }

                    
                    }

                    var sum = first15.Sum() + LuhneKey;
                    var isValid = sum%10 == 0;

                    if (isValid)
                        valids++;
                    //The Luhne key is based on the first 15 digits.
                    //One digit out of two is multiplied by 2 starting with the first one.
                    //If the result is greater than 9 then 9 is deduced from the result.
                    //This provides a new series of digits. 
                    // The Luhne key is the value that needs to be added to this sum to get a number that can be divided by 10.

                }
                );
            


            Console.WriteLine(valids);
        }


    }

}
