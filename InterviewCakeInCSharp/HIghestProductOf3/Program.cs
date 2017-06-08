using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace HIghestProductOf3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var testCases = new List<List<int>>
            {
                new List<int> {1, 2, 3, 4, 5, 6, 7, 8}, // 336
                new List<int> {9, 8, 7, 6, 5, 4, 3, 2}, // 504
                new List<int> {-10, -5, 0, 2, 3, 5, 6}, // 300
                new List<int> {-1, -2, -3, -4, -5} // -6
            };
            foreach(var test in testCases)
            {
                Console.WriteLine(HighestProductFromThree(test));
            }

        }

        public static int HighestProductFromThree(List<int> arints)
        {
            if (arints.Count < 3)
            {
                throw new Exception("This function requires at least 3 integers in the List.");
            }

            var max = arints[0];
            var max2 = max * arints[1];
            var max3 = max2 * arints[2];

            var min = max;
            var min2 = max2;

            for(var i = 0; i < arints.Count; i++)
            {
                if(arints.Count < 3) throw new Exception("Insufficient Vespine Gas");

                if (i > 2)
                {
                    max3 = Math.Max(max3, Math.Max(max2 * arints[i], min2 * arints[i]));
                }
                if (i > 1)
                {
                    max2 = Math.Max(max2, Math.Max(max * arints[i], min * arints[i]));
                    min2 = Math.Min(min2, Math.Min(max * arints[i], min * arints[i]));
                }
                max = Math.Max(max, arints[i]);
                min = Math.Min(min, arints[i]);
            }
            
            return max3;
        }
        
    }
}