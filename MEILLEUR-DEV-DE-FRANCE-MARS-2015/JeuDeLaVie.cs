using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;

namespace TOSA.JeuDeLaVie
{
    public class UnionFind
    {
        private List<int> pere;
        private int[] rang;

        public UnionFind(int n)
        {
            pere = new List<int>(Enumerable.Range(0,n));
            rang = new int[n];
        }

        public int Find(int x)
        {
            if (pere[x] == x)
                return x;
            else
            {
                var repr_x = Find(pere[x]);
                pere[x] = repr_x;
                return repr_x;
            }
        }

        public bool Union(int x, int y)
        {
            var repr_x = Find(x);
            var repr_y = Find(y);
            if(repr_x == repr_y) {  return false;}
            if (rang[repr_x] == rang[repr_y])
            {
                rang[repr_x] += 1;
                pere[repr_y] = repr_x;
            }
            else if(rang[repr_x] > rang[repr_y])
            {
                pere[repr_y] = repr_x;
            }
            else
            {
                pere[repr_x] = repr_y;
            }
            return true;
        }
    }
    
    public static class Program
    {

        private static void Main(string[] args)
        {

            var sample = @"3
5 1 5 1
2 2 4 2
2 3 2 4";
            var input = new StringReader(sample);
            //var input = Console.In;

            var N = int.Parse(input.ReadLine());

            var uf = new UnionFind(N);

            var max_x = new int[N];
            var max_y = new int[N];
            var min_c = new int[N];
            var rectangles = new ArrayList(N);

            for (int i = 0; i < N; i++)
            {
                var points = input.ReadLine().Split(' ')
                    .Select(int.Parse).ToArray();
                var r = new {x1 = points[0] - 1, y1 = points[1] - 1, x2 = points[2], y2 = points[3]};

                max_x[i] = r.x2;
                max_y[i] = r.y2;
                min_c[i] = r.x1 + r.y1;

                for (int j = 0; j < i; j++)
                {
                    dynamic rectA = rectangles[j];

                    if (!(rectA.x2 + 1 < r.x1 || r.x2 + 1 < rectA.x1 || rectA.y2 + 1 < r.y1 || r.y2 + 1 < rectA.y1) &&
                        !(rectA.x2 + 1 == r.x1 && rectA.y2 + 1 == r.y1) &&
                        !(r.x2 + 1 == rectA.x1 && r.y2 + 1 == rectA.y1))
                    {
                        var ii = uf.Find(i);
                        var jj = uf.Find(j);
                        uf.Union(i, j);
                        var k = uf.Find(i);
                        max_x[k] = new[] {max_x[k], max_x[ii], max_x[jj]}.Max();
                        max_y[k] = new[] {max_y[k], max_y[ii], max_y[jj]}.Max();
                        min_c[k] = new[] {min_c[k], min_c[ii], min_c[jj]}.Max();
                    }

                }
                rectangles.Add(r);
            }

            var lifespan = 0;

            for (int i = 0; i < N; i++)
            {
                var k = uf.Find(i);
                if (max_x[k] + max_y[k] - min_c[k] + 1 > lifespan)
                    lifespan = max_x[k] + max_y[k] - min_c[k] + 1;
            }

            Console.WriteLine(lifespan);

        }
    }
}
