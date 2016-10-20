using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MeilleurDevDeFranceMars2016._1._3.Friandises
{
    public class Program
    {
        [DebuggerDisplay("{Count} of {Value}$" )]
        public struct TypePiece
        {
            public int Count { get; set; }
            public int Value { get; set; }
        }

        static void Main(string[] args)
        {
            //var input = Console.In;
            var input = File.OpenText("1.3.Friandises/samples/input1.txt");

            var aRendre = int.Parse(input.ReadLine());
            var nbTypePieces = int.Parse(input.ReadLine());

            // count / value
            var typePieces = Enumerable.Range(0, nbTypePieces)
                .Select(i => input.ReadLine().Split(' ').Select(int.Parse).ToArray())
               .Select(ints => new TypePiece {Count = ints[0], Value = ints[1]})
                .OrderByDescending(x => x.Value)
                .ToList();
            
            var MinCoinChange = new MinCoinChange();
            MinCoinChange.minCoinDynamic(aRendre, typePieces.Select(piece => piece.Value).ToArray());

            var nbPieceToUse = 0;
            while (aRendre != 0)
            {
                if (!typePieces.Any())
                {
                    Console.WriteLine("IMPOSSIBLE");
                    return;
                }

                var first = typePieces.First();

                if (aRendre >= first.Value)
                {
                    nbPieceToUse++;
                    aRendre -= first.Value;
                    first.Count-- ;
                    if(first.Count == 0)
                        typePieces.RemoveAt(0);
                }
                else
                {
                    typePieces.RemoveAt(0);
                }
            }

            Console.WriteLine(nbPieceToUse);
            
        }

        
    }

    public class MinCoinChange
    {
        
        public int minCoinDynamic(int amount, int[] coins)
        {
            // this will store the optimal solution
            // for all the values -- from 0 to given amount.
            int[] coinReq = new int[amount + 1];

            // resets for every smaller problems
            // and minimum in it is the optimal
            // solution for the smaller problem. 
            int[] CC = new int[coins.Length];

            // 0 coins are required to make the change for 0
            // now solve for all the amounts       
            coinReq[0] = 0; 
                            
            for (int amt = 1; amt <= amount; amt++)
            {
                for (int j = 0; j < CC.Length; j++)
                {
                    CC[j] = -1;
                }
                // Now try taking every coin one at a time and fill the solution in
                // the CC[]
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= amt)
                    { // check if coin value is less than amount
                        CC[j] = coinReq[amt - coins[j]] + 1; // if available,
                                                             // select the
                                                             // coin and add
                                                             // 1 to solution
                                                             // of
                                                             // (amount-coin
                                                             // value)
                    }
                }
                //Now solutions for amt using all the coins is stored in CC[]
                //			take out the minimum (optimal) and store in coinReq[amt]
                coinReq[amt] = -1;
                for (int j = 1; j < CC.Length; j++)
                {
                    if (CC[j] > 0 && (coinReq[amt] == -1 || coinReq[amt] > CC[j]))
                    {
                        coinReq[amt] = CC[j];
                    }
                }
            }
            //return the optimal solution for amount
            return coinReq[amount];

        }

        //public static void main(String[] args)
        //{
        //    int[] coins = { 1, 2, 3 };
        //    int amount = 20;
        //    MinCoinChange m = new MinCoinChange();
        //    System.out.println("(Dynamic Programming) Minimum Coins required to make change for "
        //            + amount + " are: " + m.minCoinDynamic(amount, coins));
        //}

    }
}


