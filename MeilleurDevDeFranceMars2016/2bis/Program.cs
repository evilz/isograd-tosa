using System;
using System.Collections.Generic;
using System.Linq;

namespace MeilleurDevDeFranceMars2016._2bis
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            //var input = File.OpenText("CURRENT_FOLDER_NAME/samples/input1.txt");

            // READ COUNT
            var text = input.ReadLine();
           // var text = "ab-bcd-d-c-ae-e";
            var deep = 1;
            var map = new Dictionary<char,double>();
            var closing = false;
            foreach (var balise in text)
            {
                if (balise == '-')
                {
                    deep--;
                    closing = true;
                    continue;
                }
                else
                {
                    if (!map.ContainsKey(balise))
                    {
                        map[balise] = 0;
                    }

                    if (closing)
                    {
                        closing = false;
                        map[balise] += 1 / (double)deep;
                        continue;
                    }
                    else
                    {
                        deep++;
                    }
                }
               
                
            }

            var max =map.OrderByDescending(arg => arg.Value).ThenBy(arg => arg.Key).First();
            Console.WriteLine(max.Key);

        }
    }
}
