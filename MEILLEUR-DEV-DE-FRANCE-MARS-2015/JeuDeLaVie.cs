using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace TOSA.JeuDeLaVie
{
    public static class Program
    {

        private static void Main(string[] args)
        {
            try
            {


                //                var sample = @"3
                //5 1 5 1
                //2 2 4 2
                //2 3 2 4";
                //                var input = new StringReader(sample);
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

                var aliveCells = (from r in rectangles
                                  from x in Enumerable.Range(r.X1, r.X2 - r.X1)
                                  from y in Enumerable.Range(r.Y1, r.Y2 - r.Y1)
                                  select new Point(x, y))
                                .ToList();

                // var aliveCellsDebug = aliveCells.ToArray();
                
                


                var turn = 0;

                Utils.LocalPrint(aliveCells.Count.ToString());

                while (aliveCells.Any())
                {
                    var maxX = aliveCells.Max(p => p.X) + 1;
                    var minX = aliveCells.Min(p => p.X) - 1;
                    minX = Math.Max(0, minX);

                    var maxY = aliveCells.Max(p => p.Y) + 1;
                    var minY = aliveCells.Min(p => p.Y) - 1;
                    minY = Math.Max(0, minY);

                    turn++;

                    var enumerable = (from x in Enumerable.Range(minX, maxX - minX)
                                      from y in Enumerable.Range(minY, maxY - minY)
                                      select new Point(x, y))
                        .OrderBy(p => Math.Abs(maxX - p.X) + Math.Abs(maxY - p.Y))
                        .ToArray();


                    foreach (var cell in enumerable)
                    {
                        var currentExist = aliveCells.Any(p => p.X == cell.X && p.Y == cell.Y);
                        var newState = NextState(cell, aliveCells);
                        if (newState && currentExist)
                        {
                            aliveCells.Add(cell);
                        }
                        else if (currentExist)
                        {
                            aliveCells.Remove(cell);
                        }

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

        static bool NextState(Point cell, List<Point> m)
        {
            var currentState = m.Any(tuple => tuple.X == cell.X && tuple.Y == cell.Y);
            var left = m.Any(tuple => tuple.X == (cell.X - 1) && tuple.Y == cell.Y);
            var top = m.Any(tuple => tuple.X == cell.X && tuple.Y == (cell.Y - 1));

            if (!top && !left) { return false; }
            if (top && left) { return true; }
            return currentState;
        }

    }
}
