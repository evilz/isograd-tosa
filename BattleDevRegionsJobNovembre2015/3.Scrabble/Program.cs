using System;
using System.IO;
using System.Linq;

namespace BattleDevRegionsJobNovembre2015._3.Scrabble
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            //var input = File.OpenText("3.Scrabble/samples/input1.txt");


            var wordsCount = int.Parse(input.ReadLine());

            var letterValues = input.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var words = Enumerable.Range(0, wordsCount)
                .Select(i => input.ReadLine())
                .Select(w => new {Word = w, Score = GetWordPoint(w, letterValues)})
                .OrderByDescending(arg => arg.Score)
                .ThenBy(x => x.Word.Length)
                .ToArray();
            

            Console.WriteLine(words.First().Score + " " + words.First().Word.Length);

        }

        public static int GetWordPoint(string word, int[] letterValues)
        {
            return word.Aggregate(0, (current, c) => current + letterValues[c - 'A']);
        }
    }
}
