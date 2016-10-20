using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BattleDevRegionsJobNovembre2015._4.Logigraphes
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var input = Console.In;
            var input = File.OpenText("4.Logigraphes/samples/input1.txt");


            var size = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var height = size[0];
            var width = size[1];

            
            var lines = Enumerable.Range(0, height)
                .Select(i => input.ReadLine())
               .ToArray();

            foreach (var line in lines)
            {
                var matchs = Regex.Matches(line, "(x+)").Cast<Match>().Select(m => m.Length);

                Console.Write(string.Join("-",matchs));
                Console.Write(' ');
            }



            

            
        }
        //static char[][] RotateCW(char[][] mat)
        //{
        //    int M = mat.Length;
        //    int N = mat[0].Length;
        //    int[][] ret = new int[N][];
        //    for (int r = 0; r < M; r++)
        //    {
        //        for (int c = 0; c < N; c++)
        //        {
        //            ret[c][M - 1 - r] = mat[r][c];
        //        }
        //    }
        //    return ret;
        //}
    }
}
