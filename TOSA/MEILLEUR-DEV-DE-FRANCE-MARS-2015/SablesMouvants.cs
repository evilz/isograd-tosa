using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace TOSA.SablesMouvants
{
   

    public class Program
    {
        
        static void Main(string[] args)
        {

            var sample =
@"8 10
..........
.########.
..####.##.
...##.###.
.##.####..
.##.#.#.#.
.#.######.
..........";


            const char TerreFerme = '.';
            const char SableMouvant = '#';
            
           // var input = Console.In;
           var input = new StringReader(sample);
            var size = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var H = size[0];
            var L = size[1];

           
            var matrix = Enumerable.Range(0, H)
                .Select(i => input.ReadLine().ToCharArray())
                .ToArray();

            var maxDistance = 0;
            
            for (int lineIndex = 0; lineIndex < H; lineIndex++)
            {
                for (int x = 0; x < L; x++)
                {
                    if (matrix[lineIndex][x] == SableMouvant)
                    {
                        var distance = int.MaxValue;

                        // left
                        for (int i = 1; i <= x; i++)
                        {
                            if (matrix[lineIndex][x-i] == TerreFerme)
                            {
                                distance = Math.Min(distance, i);
                                break;
                            }
                            if(i >= distance) break;
                        }

                        // right
                        for (int i = 1; i <= L - x; i++)
                        {
                            if (matrix[lineIndex][x+i] == TerreFerme)
                            {
                                distance = Math.Min(distance, i);
                                break;
                            }
                            if (i >= distance) break;
                        }
                        // top
                        for (int i = 1; i <= lineIndex; i++)
                        {
                            if (matrix[lineIndex-i][x] == TerreFerme)
                            {
                                distance = Math.Min(distance, i);
                                break;
                            }
                            if (i >= distance) break;
                        }
                        // bottom;
                        for (int i = 1; i <= H - lineIndex; i++)
                        {
                            if (matrix[lineIndex + i][x] == TerreFerme)
                            {
                                distance = Math.Min(distance, i);
                                break;
                            }
                            if (i >= distance) break;
                        }

                        Utils.LocalPrint(distance.ToString() + Environment.NewLine);
                        maxDistance = Math.Max(distance, maxDistance);
                    }
                }
            }

            //Utils.LocalPrint(count.ToString());
            //Utils.LocalPrintArray(new List<object>());
          
            Console.WriteLine(maxDistance);
        }


    }

}

// lire les bords en premier et revenir au centre
//....
//.##.
//.##.
//....

//    0;0
//    0;1
//    0;2
//    0;3

//    1;3
//    2;3
//    3;3

//    3;2
//    3;1
//    3;0

//    2;0
//    1;0

    // top
//    1;1
//    1;2

//    2;2
//    2;1


//..........
//.########.
//.########.
//.########.
//.########.
//.########.
//.########.
//.########.
//.########.
//..........

//0000000000
//0111111110
//0122222210
//0123333210
//0123443210
//0123443210
//0123333210
//0122222210
//0111111110
//0000000000

40 38
......................................
..###################################.
.####################################.
.##.##########.############.#########.
.###################################..
.####################################.
.#.##.###############################.
.############.####.##################.
.###########.########################.
.####################.#.#############.
.####.#############.#################.
.##########.#########################.
.##########.###.####.###.############.
.#######.########.###################.
.###############.####################.
.################.###################.
.#######.##.####.######.#############.
.#.##.###############################.
.####################################.
.#####.#.############################.
.##########.###############.#########.
.####################################.
.#####################.##############.
.##########.############.############.
.################.###################.
.####################################.
.#############.####################.#.
.###########..###############..######.
.#################################.##.
.#####.#.##.######.########.#######.#.
.###.#.#########.##############.#####.
..##################.################.
.#########.##########.#####.#######.#.
.####################################.
.##################.#############.###..##########.#########################..################################.###..######################.#############..###.################################.......................................

13 

40 38
.......................................#####.#.######..#.##.##.####.#.#####..#.#.#####..###.##.###..#.##....#####..###.##.#...#.####.####.