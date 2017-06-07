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

            var max = int.MinValue;
            var max2 = int.MinValue;
            var max3 = int.MinValue;

            var min = int.MaxValue;
            var min2 = int.MaxValue;

            foreach (var i in arints)
            {
                if (i <= min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
                
                
                if (max > int.MinValue && max2 < max * i)
                {
                    max2 = max * i;
                }
                else if (min < int.MaxValue && max2 < min * i)
                {
                    max2 = min * i;
                }

                if (max > int.MinValue && min2 > max * i)
                {
                    min2 = max * i;
                } else if (min < int.MaxValue && min2 > min * i)
                {
                    min2 = max * i;
                }

                
                if (min2 < int.MaxValue && max3 < min2 * i)
                {
                    max3 = min2 * i;
                }
                if (max2 > int.MinValue && max3 < max2 * i)
                {
                    max3 = max2 * i;
                }
                
                
                Console.WriteLine(max);
                Console.WriteLine(max2);
                Console.WriteLine(max3);
                Console.WriteLine(min);
                Console.WriteLine(min2);
                Console.WriteLine();
            }
            
            return max3;
        }
        
    }
}