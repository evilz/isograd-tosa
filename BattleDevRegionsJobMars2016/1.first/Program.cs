using System;
using System.Linq;

namespace BattleDevRegionsJobMars2016._1.first
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;

            var wordCount = int.Parse(input.ReadLine());

            var dictionnaryWords = Enumerable.Range(0, wordCount)
                                        .Select(i => input.ReadLine())
                                        .ToArray();
            
            var maxLengthWord = dictionnaryWords.OrderByDescending(s => s.Length).First().Length;
            Console.WriteLine(maxLengthWord);

        }
    }
}
