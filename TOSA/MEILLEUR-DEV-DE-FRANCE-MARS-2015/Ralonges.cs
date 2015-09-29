using System;
using System.Linq;

namespace TOSA.Ralonges
{
    public class Program
    {
        private class Ralonge
        {
            public string Type;
            public int Longueur;
        }
        
        static void Main(string[] args)
        {
            var input = Console.In;

            var ralongesCount = int.Parse(input.ReadLine());

            var ralonges = Enumerable.Range(0, ralongesCount)
                .Select(i => input.ReadLine().Split(' '))
                .Select(s => new Ralonge {Type = s[0], Longueur = int.Parse(s[1])})
                .OrderByDescending(ralonge => ralonge.Longueur)
                .GroupBy(ralonge => ralonge.Type)
                .ToList();
                

            var maleOnly = ralonges.Where(grouping => grouping.Key == "M-M").SelectMany(g => g).ToArray();
            var femaleOnly = ralonges.Where(grouping => grouping.Key == "F-F").SelectMany(g => g).ToArray();

            var maxOnly = Math.Min(maleOnly.Count(), femaleOnly.Count());

           var maxOnlyLongueur =  Enumerable.Range(0, maxOnly)
                .Select(i => maleOnly[i].Longueur + femaleOnly[i].Longueur)
                .Sum();

            var mixLongueur = ralonges.Where(grouping => grouping.Key == "M-F" || grouping.Key == "F-M")
                .SelectMany(g => g)
                .Sum(ralonge => ralonge.Longueur);
            
            Console.WriteLine(maxOnlyLongueur + mixLongueur);
        }


    }

}
