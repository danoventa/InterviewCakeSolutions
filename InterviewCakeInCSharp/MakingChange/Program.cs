using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;

namespace MakingChange
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var combinations = GetCombinations(5, new []{1 ,2 , 3, 4});
            var combos = DenomicationPermutation(new List<int> {1, 2, 3, 4}, 5);

            Console.Write("Combinations: " + Convert.ToString(combinations) + " ");
            Console.Write("Combos " + Convert.ToString(combos) + " ");
        }

        public static int DenomicationPermutation(List<int> denominations, int target)
        {
            var availableNums = new List<int>();
            foreach (var denomination in denominations)
            {
                var numsToUse = Math.Floor((double)(target/denomination));
                for (var iter = 0; iter < numsToUse; iter++)
                {
                    availableNums.Add(denomination);
                }
            }

            var compositionCount = 0;
            for (var i = 1; i <= availableNums.Count; i++)
            {
                var trailAmount = target;
                
                for (var j = availableNums.Count - i; j > -1; j--)
                {
                    if (Math.Floor((double) trailAmount / availableNums[j]) > 0)
                    {
                        trailAmount -= availableNums[j];
                        continue;
                    }
                    if (trailAmount > 0 && trailAmount < availableNums[j])
                    {
                        continue;
                    }
                    compositionCount++;
                    break;
                }
            }
            
            return compositionCount;
        }
        
        public static int GetCombinations(int money, int[] denominations)
        {
            var maxDeno = new Dictionary<int, int>();
            foreach (var deno in denominations)
            {
                if(money / deno > 1)
                    maxDeno[deno] = 0;
            }

            var validDenominations = maxDeno.Keys.ToArray();
            Array.Reverse(validDenominations);

            var i = 0;
            foreach (var deno in validDenominations)
            {

                if(maxDeno[deno] <= 0)
                {
                    break;
                }
                var temp = maxDeno[deno];
                if (i + 1 < validDenominations.Length)
                {
                    var j = i;
                    while (temp < money)
                    {
                        if (validDenominations[j] + temp > money)
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            temp += validDenominations[j];
                        }
                    }
                }
                i++;
            }


            return 0;
        }
    }
}