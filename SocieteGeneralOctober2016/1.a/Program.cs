using System;
using System.IO;
using System.Linq;

namespace SocieteGeneralOctober2016._1.a
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            //var input = new StringReader("5\n18:03:00\n12:23:00 21:28:00\n18:13:00 22:48:00\n23:41:00 23:52:00\n11:46:00 20:58:00\n14:57:00 17:57:00");
            //input = File.OpenText(@"sample\input1.txt");

            var today = DateTime.Today;
            var customers = int.Parse(input.ReadLine());
            var t = input.ReadLine().Split(':').Select(int.Parse).ToArray();
            var time = new DateTime(2000,10,21,t[0], t[1], t[2]);


            var many = Enumerable.Range(0, customers)
                .Select(_ =>
                    input.ReadLine()
                        .Split(' ')
                        .Select(s => { var t2 = s.Split(':').Select(int.Parse).ToArray(); return new DateTime(2000, 10, 21, t2[0], t2[1], t2[2]); }) 
                        .ToArray())
                        .ToArray();

            var output =  many.Where(times => times[0] <= time && times[1] >= time).Count();
            
            Console.WriteLine(output);

        }
    }
}
