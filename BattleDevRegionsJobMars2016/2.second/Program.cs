using System;
using System.Linq;

namespace BattleDevRegionsJobMars2016._2.second
{
    public class Program
    {
        static void Main(string[] args)
        {
/*
            Énoncé

Dans ce challenge, vous devez déterminer le nombre de personnes situées dans une zone rectangulaire.
Les coordonnées des personnes et de la zone sont fournies sous forme de latitude et de longitude.

Format des données

Entrée
Ligne 1 : quatre nombres flottants from_lat, from_lng, to_lat et to_lng tous compris entre 0 et 51 utilisant le "." comme séparateur décimal et séparés par des espaces, indiquant respectivement la latitude minimale, la longitude minimale, la latitude maximale et la longitude maximale de la zone rectangulaire à contrôler.
Ligne 2 : un entier N représentant le nombre de personnes géolocalisées.
Lignes 3 à N+2 : deux nombres flottants lat et lng utilisant le "." comme séparateur décimal et séparés par un espace représentant les coordonnées d'une personne géolocalisée.

Sortie
Un entier représentant le nombre de personnes se trouvant dans la zone à contrôler(les bords sont inclus).
*/
            var input = Console.In;


            // READ COUNT
            var numbers = input.ReadLine().Split(' ').Select(s => double.Parse(s)).ToArray();
            var from_lat = numbers[0];
            var from_lng = numbers[1];
            var to_lat = numbers[2];
            var to_lng = numbers[3];

            var N = int.Parse(input.ReadLine());

            // READ LINES of INTs
            var people = Enumerable.Range(0, N)
                .Select(i => input.ReadLine().Split(' ').Select(double.Parse).ToArray()).Select(doubles => new {lat = doubles[0], lng = doubles[1]});

            // READ LINES of string
            var tocontrol = people
                        .Count(coor => coor.lat >= from_lat && coor.lat <= to_lat && coor.lng >= from_lng && coor.lng <= to_lng);
            

          //  Utils.LocalPrint(count.ToString());
          //  Utils.LocalPrintArray(new List<object>());

            Console.WriteLine(tocontrol);

        }
    }
}
