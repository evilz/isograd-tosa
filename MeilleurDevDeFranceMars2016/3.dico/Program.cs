using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MeilleurDevDeFranceMars2016._3.dico
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var input = Console.In;
            var input = File.OpenText("3.dico/samples/input1.txt");

            // READ COUNT
            var D = int.Parse(input.ReadLine());


            // READ LINES of string
            var words = Enumerable.Range(0, D)
                .Select(i => input.ReadLine())
                .ToArray();

            var N = int.Parse(input.ReadLine());

            var userWords = Enumerable.Range(0, D)
               .Select(i => input.ReadLine())
               .ToArray();

            words = new[] {"logarithme"};
            userWords = new[] {"algorithme"};

            foreach (var userWord in userWords)
            {



                if (words.Contains(userWord))
                {
                    Console.WriteLine(0);
                    return;
                }


                foreach (var dicoWord in words)
                {
                   var distance = LevenshteinDistance(userWord, dicoWord);
                }


                //var dico = new Dictionary<string, int>();
                //foreach (var word in words)
                //{
                //    var score = 0;
                //    var userWordMutable = userWord.ToCharArray();

                    //    //algo -> lgo -> logo -> loga
                    //    var charsToRemoveOrReplace = new bool[userWord.Length];

                    //    var part = userWord;
                    //    var indexOfPArt = -1;
                    //    for (int i = 0; i < userWord.Length; i++)
                    //    {
                    //        part = userWord.Substring(i);
                    //         indexOfPArt = word.IndexOf(part);
                    //        if (indexOfPArt >= 0)
                    //        {
                    //            break;
                    //        }
                    //    }


                    //    // swap +3pts

                    //    // delete +2pts
                    //    for (int i = 0,j=0; i < userWordMutable.Length;i++)
                    //    {
                    //        if (userWordMutable[i] != word[j])
                    //        {
                    //            userWordMutable[i] = ' ';
                    //            score += 2;
                    //        }
                    //        else
                    //        {
                    //            j++;
                    //        }

                    //    }

                    //    userWordMutable = new string(userWordMutable).Trim().ToCharArray();


                    //    if (!dico.ContainsKey(word))
                    //        dico.Add(word, 0);



                    //    //add or Sup
                    //    if (userWord.Length != word.Length)
                    //    {
                    //        dico[word] += Math.Abs(word.Length - word.Length) * 2;
                    //    }


                    //        var wordLookup = word.ToLookup(c => c);
                    //        var userLookup = userWord.ToLookup(c => c);

                    //        foreach (var g1 in wordLookup)
                    //        {
                    //            if (userLookup.Contains(g1.Key))
                    //            {
                    //                dico[word] += Math.Abs(userLookup[g1.Key].Count() - g1.Count()) * 3;
                    //            }
                    //            else
                    //            {
                    //                dico[word] += g1.Count() * 3;
                    //            }

                    //        }


            }

                //var best = dico.OrderBy(pair => pair.Value).First();



                //  Utils.LocalPrint(count.ToString());
                //  Utils.LocalPrintArray(new List<object>());

               // Console.Write(best.Key + " ");
            }

        static int LevenshteinDistance(string s, string t)
        {
            // degenerate cases
            if (s == t) return 0;
            if (s.Length == 0) return t.Length;
            if (t.Length == 0) return s.Length;

            // create two work vectors of integer distances
            // initialize v0 (the previous row of distances)
            // this row is A[0][i]: edit distance for an empty s
            // the distance is just the number of characters to delete from t
            Console.WriteLine(string.Join(" | ", new [] {' '}.Concat(t.ToCharArray())));

            int[] v0 = Enumerable.Range(0,t.Length + 1).ToArray();
            int[] v1 = new int[t.Length + 1];
            
            for (int i = 0; i < s.Length; i++)
            {
                // calculate v1 (current row distances) from the previous row v0

                // first element of v1 is A[i+1][0]
                //   edit distance is delete (i+1) chars from s to match empty t
                v1[0] = i + 1;

                // use formula to fill in the rest of the row
                for (int j = 0; j < t.Length; j++)
                {
                    var cost = (s[i] == t[j]) ? 0 : 1;

                   

                    v1[j + 1] = new[] {
                        v1[j] + 1   // delete
                        , v0[j + 1] + 1  // insert
                        , v0[j] + cost  // substitution
                    }.Min();
                }

                Console.WriteLine(string.Join(" | ",v1));
                // copy v1 (current row) to v0 (previous row) for next iteration
                for (int j = 0; j < v0.Length; j++)
                    v0[j] = v1[j];
            }

            return v1[t.Length];
        }
    }
    
}
