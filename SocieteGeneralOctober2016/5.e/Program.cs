using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SocieteGeneralOctober2016._5.e
{


    public class Program
    {
        private class key
        {
            
            public key(string value)
            {
                Value = value;
                Children = new List<key>();
            }

            public int Level
            {
                get
                {
                    if(Children.Any())
                    { return Children.Select(key1 => key1.Level).Max() + 1;}
                    return 1;
                }
            }

            public string Value { get; set; }
            public List<key> Children { get; private set; } 
        }
       
        static void Main(string[] args)
        {
            var input = Console.In;
            //var input = new StringReader("6\nhome office\nhome garage\nhome parents_home\noffice lab\noffice library\nlibrary main_entrance");

            var count = int.Parse(input.ReadLine());

            var many = Enumerable.Range(0, count)
                .Select(_ =>
                    input.ReadLine()
                        .Split(' ')
                        
                        .ToArray())
                        .ToArray();

            var dic = new Dictionary<string,key>();

            foreach (var key in many)
            {
                dic[key[0]] = new key(key[0]);
                dic[key[1]] = new key(key[1]);
            }

            foreach (var key in many)
            {
                var master = dic[key[0]];
                var slave = dic[key[1]];


                master.Children.Add(slave);
            }


            var master2 = dic.Values.OrderByDescending(key => key.Level).First();
            Console.WriteLine(master2.Level);

        }
    }
}
