using System;
using System.Collections.Generic;

namespace MakingChange
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var combinations = GetCombinations(5, new []{10,2 , 3, 4});

            foreach (var combination in combinations)
            {
                Console.WriteLine();
                foreach (var denom in combination)
                {
                    Console.Write(Convert.ToString(denom) + " ");
                }
            }
        }

        public static List<int[]> GetCombinations(int money, int[] denominations)
        {




            return new List<int[]>();
        }
    }
}