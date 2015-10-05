using System;
using System.Linq;

namespace TOSA.Ralonges
{
    public class Program
    {

        static void Main(string[] args)
        {
            var input = Console.In;

            var ralongesCount = int.Parse(input.ReadLine());

            var ralonges = Enumerable.Range(0, ralongesCount)
                .Select(i => input.ReadLine().Split(' '))
                .Select(s => new { Type = s[0], Longueur = int.Parse(s[1]) })
                .OrderByDescending(ralonge => ralonge.Longueur)
                .ToLookup(ralonge => ralonge.Type);

            var maleOnly = ralonges["M-M"].ToArray();
            var femaleOnly = ralonges["F-F"].ToArray();

            var maxOnly = Math.Min(maleOnly.Count(), femaleOnly.Count());

            var maxOnlyLongueur = 
                maleOnly.Take(maxOnly).Sum(arg => arg.Longueur)
                + femaleOnly.Take(maxOnly).Sum(x => x.Longueur);
               
            var mixLongueur = ralonges["M-F"].Sum(x => x.Longueur) + ralonges["F-M"].Sum(x => x.Longueur);

            Console.WriteLine(maxOnlyLongueur + mixLongueur);
        }


    }

}
