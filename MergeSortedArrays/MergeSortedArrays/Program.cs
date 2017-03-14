using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Xml.Xsl.Runtime;

namespace MergeSortedArrays
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] myArray = { 3, 4, 6, 10, 11, 15 };
            int[] alicesArray = { 1, 5, 8, 12, 14, 19 };

            // merge sort the arrays while we add them..
            var first = MergesortsBuiltIn(myArray, alicesArray);
            var last = MergeSortedSorts(myArray, alicesArray);
            // PrintArray(first);
            // PrintArray(last);

            Console.WriteLine(Convert.ToString(VerifyArrays(first, last)));

        }

        // use the built in sort O(nLogn)
        public static int[] MergesortsBuiltIn(int[] arrie1, int[] arrie2)
        {
            // Linq concat, could also use built in copyTo with new array of size (both arrays).
            var arrie3 = arrie1.Concat(arrie2).ToArray();
            Array.Sort(arrie3);
            return arrie3;
        }

        // traversing it in O(n) since it's already sorted.
        public static int[] MergeSortedSorts(int[] arrie1, int[]arrie2)
        {
            var nlen = arrie1.Length + arrie2.Length;
            var arrie3 = new int[nlen];
            var curs1 = 0;
            var curs2 = 0;

            for (int i = 0; i < nlen; i++)
            {
                if (curs1 < arrie1.Length && curs2 < arrie2.Length)
                {
                    if (arrie1[curs1] > arrie2[curs2])
                    {
                        arrie3[i] = arrie2[curs2];
                        curs2++;
                    }
                    else if (arrie1[curs1] < arrie2[curs2])
                    {
                        arrie3[i] = arrie1[curs1];
                        curs1++;
                    }
                    else
                    {
                        arrie3[i] = arrie1[curs1];
                        arrie3[i + 1] = arrie2[curs2];
                        i += 2;
                        curs1++;
                        curs2++;
                    }
                }
                else
                {
                    if (curs1 < arrie1.Length)
                    {
                        arrie3[i] = arrie1[curs1];
                    }
                    else
                    {
                        arrie3[i] = arrie2[curs2];
                    }
                }
            }
            return arrie3;
        }

        // make sure the system sort and mine are equivallent
        public static bool VerifyArrays(int[] arrie1, int[] arrie2)
        {
            if (arrie1.Length != arrie2.Length)
            {
                return false;
            }
            for(int i = 0; i < arrie1.Length; i++)
            {
                if (arrie1[i] != arrie2[i])
                {
                    return false;
                }
            }
            return true;
        }

        // print the arrays.
        public static void PrintArray(int[] arrg)
        {
            foreach (var n in arrg)
            {
                Console.WriteLine(Convert.ToString(n));
            }
        }
    }
}