using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace TOSA.JeuDeLaVie
{
    public static class Program
    {
       
        private static void Main(string[] args)
        {
            try
            {

               
//            var sample = @"3
//5 1 5 1
//2 2 4 2
//2 3 2 4";
//                                            var input = new StringReader(sample);
               var input = Console.In;
                
                var rectCount = int.Parse(input.ReadLine());
                
                var rectangles = Enumerable.Range(0, rectCount)
                    .Select(i => input.ReadLine().Split(' ').Select(int.Parse).ToArray())
                    .Select(i => new { X1 = i[0] - 1, Y1 = i[1] - 1, X2 = i[2], Y2 = i[3] })
                    .ToList();

                var H = rectangles.Max(r => r.Y2) + 1;
                var L = rectangles.Max(r => r.X2) + 1;

                Utils.LocalPrint(H.ToString());
                Utils.LocalPrint(L.ToString());

               
               // var matrix = new bool[H, L];
               
                var aliveCells = new List<Tuple<int,int>>();
                foreach (var r in rectangles)
                {
                    for (int x = r.X1; x < r.X2; x++)
                        for (int y = r.Y1; y < r.Y2; y++)
                        {
                            aliveCells.Add(new Tuple<int, int>(x,y));
                        }
                }

                Func<int,int, List<Tuple<int,int>>, bool> nextState = (X,Y, m) =>
                  {
                      var currentState = m.Any(tuple => tuple.Item1 == X && tuple.Item2 == Y);
                      var left = m.Any(tuple => tuple.Item1 == (X - 1) && tuple.Item2 == Y);
                      var top = m.Any(tuple => tuple.Item1 == X && tuple.Item2 == (Y - 1));

                      if (!top && !left) { return false; }
                      if (top && left) { return true; }
                      return currentState;
                  };

                var turn = 0;

                Utils.LocalPrint(aliveCells.Count.ToString());
                
                while (aliveCells.Any())
                {
                    var maxX = aliveCells.Max(tuple => tuple.Item1) + 1;
                    var minX = aliveCells.Min(tuple => tuple.Item1) - 1;

                    var maxY = aliveCells.Max(tuple => tuple.Item2) + 1;
                    var minY = aliveCells.Min(tuple => tuple.Item2) - 1;

                    turn++;
                   var newState = (from y in Enumerable.Range(minY, maxY)
                        from x in Enumerable.Range(minX, maxX)
                        select new Tuple<int,int>(x, y))
                        .Where(cell => cell.Item1*cell.Item2 != 0)
                        .Where(cell => nextState(cell.Item1,cell.Item2, aliveCells))
                        .ToList();

                    try
                    {
                        aliveCells = newState;
                    }
                    catch (Exception)
                    {
                        Utils.LocalPrint("Impossible d affacter la nouvelle valeur");

                    }


                    Utils.LocalPrint(aliveCells.Count.ToString());


                }

                Console.WriteLine(turn);

            }
            catch (Exception e)
            {
                Utils.LocalPrint(e + " " + e.StackTrace);
                Console.WriteLine(-1);
            }
        }

    }
}
