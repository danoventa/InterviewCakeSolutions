using System;
using System.Collections.Generic;
using System.Linq;

namespace MakingChange
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var combinations = GetCombinations(5, new []{10,2 , 3, 4});

            Console.Write(Convert.ToString(combinations) + " ");
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