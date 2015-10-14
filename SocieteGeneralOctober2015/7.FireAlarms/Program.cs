using System;
using System.Linq;

namespace SocieteGeneralOctober2015._7.FireAlarms
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var input = Console.In;

            // Row 1: two space-separated integers W and L between 2 and 50 representing the width and length of the map.
            var infos = input.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray();

            var W = infos[0];
            var L = infos[1];

            // Rows 2 to W + 1: L characters representing either:
            // - a bank 'B';
            // - a fire station 'F';
            // - an empty space '.'(dot).
            var map = (from i in Enumerable.Range(0, W)
                       select input.ReadLine().ToCharArray())
                       .ToArray();

            // Row W + 2: an integer N between 1 and 20,000 representing the number of fire alarms in the city.
            var nbFireAlarm = int.Parse(input.ReadLine());

            // Rows W + 3 to W + 2 + N: two space-separated integers I and J representing the coordinates of a detected fire in a bank of the city.
            var fires = (from i in Enumerable.Range(0, nbFireAlarm)
                       select input.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray())
                        .ToArray();

            foreach (var fire in fires)
            {
                var distance = GetClosestFireStation(map, fire[0], fire[1]);
            }
        }
    }
}
