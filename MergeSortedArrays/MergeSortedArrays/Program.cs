using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortedArrays
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] myArray = { 3, 4, 6, 10, 11, 15 };
            int[] alicesArray = { 1, 5, 8, 12, 14, 19 };

            // merge sort the arrays while we add them..
            PrintArray(Mergesorts(myArray, alicesArray));
        }

        public static int[] Mergesorts(int[] arrie1, int[] arrie2)
        {

            var arrie3 = arrie1.Concat(arrie2).ToArray();
            return arrie3;
        }

        public static void PrintArray(int[] arrg)
        {
            foreach (var n in arrg)
            {
                Console.WriteLine(Convert.ToString(n));
            }
        }
    }
}