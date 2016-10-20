using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace MeilleurDevDeFranceMars2016._1._2.Snake
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            var size = int.Parse(input.ReadLine());
            var nbMoves = int.Parse(input.ReadLine());

            var moves = Enumerable.Range(0, nbMoves)
                .Select(i => input.ReadLine()[0])
                .ToArray();
            
            var positions = new LinkedList<Point>();
            for (int i = 0; i < size; i++)
            {
                positions.AddLast(new Point(i, 0));
            }
            
            var last = positions.Last.Value;
            foreach (var move in moves)
            {
                positions.RemoveFirst();
                switch (move)
                {
                    case 'D': last = new Point(last.X + 1, last.Y); break;
                    case 'G': last = new Point(last.X - 1, last.Y); break;
                    case 'H': last = new Point(last.X, last.Y - 1); break;
                    case 'B': last = new Point(last.X, last.Y + 1); break;
                }
                positions.AddLast(last);
            }
            
            var first = positions.First.Value;
            Console.WriteLine(first.X + " " + first.Y);
        }
    }
}


