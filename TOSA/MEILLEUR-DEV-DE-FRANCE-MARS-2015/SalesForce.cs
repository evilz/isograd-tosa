using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TOSA.SalesForce
{
    public class Program
    {
        private class Client
        {
            public string Nom;
            public string Prénom;
            public string Société;
            public string Téléphone;
            public string Pays;

        }

        static void Main(string[] args)
        {
            var input = Console.In;
            
            var linesCount = int.Parse(input.ReadLine());
            var countries = input.ReadLine().Split(';');

            var clients = Enumerable.Range(0, linesCount)
                .Select(i => input.ExtractValues<string>(';').ToArray())
                .Select(client => new Client
                {
                    Nom = client[0],
                    Prénom = client[1],
                    Société = client[2],
                    Téléphone = client[3],
                    Pays = client[4]
                })
                .ToList();

            var groupedClients = clients
                .GroupBy(client => client.Nom + client.Prénom + client.Société).ToList();

            var doublons = groupedClients
                .Count(grouping => grouping.Count() > 1);

            var keep = groupedClients
                .Select(grouping => grouping.First()).ToList();

            var wrongNumber = keep.Count(client => !Regex.Match(client.Téléphone, @"^\+\d{1,3}\-\d{9,11}$",RegexOptions.IgnoreCase).Success);

            var horsZone = keep.Count(client => !countries.Contains(client.Pays));

            Console.WriteLine(doublons + " " + wrongNumber + " " + horsZone);
        }
    }
}
