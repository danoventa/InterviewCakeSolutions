using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var twoarie = new int[2][];
            twoarie[0] = new int[] {3, 4, 6, 10, 11, 15};
            twoarie[1] = new int[] {1, 5, 8, 12, 14, 19};


            var fast = ArrayOfSortedArraySort(twoarie);
            // PrintArray(first);
            // PrintArray(last);
            // PrintArray(fast);

            Console.WriteLine(Convert.ToString(VerifyArrays(first, last)));
            Console.WriteLine(Convert.ToString(VerifyArrays(fast, last)));

        }

        // use the built in sort O(nLogn)
        public static int[] MergesortsBuiltIn(int[] arrie1, int[] arrie2)
        {
            // Linq concat, could also use built in copyTo with new array of size (both arrays).
            var arrie3 = arrie1.Concat(arrie2).ToArray();
            Array.Sort(arrie3);
            return arrie3;
        }

        // merge multiple sorted arrays.
        public static int[] ArrayOfSortedArraySort(int[][] manyArray)
        {
            var arrayCount = manyArray.Length;
            var cursors = new int[arrayCount];
            var totalSize = 0;
            for (var i = 0; i < arrayCount; i++)
            {
                cursors[i] = 0;
                totalSize += manyArray[i].Length;
            }
            var finalArray = new int[totalSize];
            var nextNums = new int[arrayCount];
            for (var index = 0; index < totalSize; index++)
            {
                int mindex;
                for (var arrIndex = 0; arrIndex < arrayCount; arrIndex++)
                {
                    if (arrIndex >= manyArray[arrIndex].Length)
                    {
                        nextNums[arrIndex] = -1;
                    }
                    else if (cursors[arrIndex] < arrayCount)
                    {
                        Console.Write(Convert.ToString(manyArray[arrIndex][cursors[arrIndex]]) + " \n\n");
                        nextNums[arrIndex] = manyArray[arrIndex][cursors[arrIndex]];

                    }
                }
                mindex = indexOfNextMin(nextNums);
                cursors[mindex] += 1;

                if (cursors[mindex] >= manyArray[mindex].Length)
                {
                    PrintArray(finalArray);
                }
                else
                {
                    finalArray[index] = manyArray[mindex][cursors[mindex]];

                }
            }

            return finalArray;
        }

        // check the next set of numbers, and then return the index of the next number
        // potential issue, if some run out, but not others.
        public static int indexOfNextMin(int[] nextNums)
        {
            Console.Write("---------------\n");
            PrintArray(nextNums);
            Console.Write("\n---------------\n");

            var min = nextNums[0];
            var mindex = 0;
            for(var i = 0; i < nextNums.Length; i++)
            {
                // negative one indicates no number since Id's should not be negative
                if (nextNums[i] >= min || nextNums[i] == -1) continue;

                min = nextNums[i];
                mindex = i;
            }
            return mindex;
        }


        // traversing it in O(n) since it's already sorted.
        public static int[] MergeSortedSorts(int[] arrie1, int[]arrie2)
        {
            var nlen = arrie1.Length + arrie2.Length;
            var arrie3 = new int[nlen];
            var curs1 = 0;
            var curs2 = 0;

            // add to the new items.
            for (int i = 0; i < nlen; i++)
            {
                // still have some numbers in either array
                if (curs1 < arrie1.Length && curs2 < arrie2.Length)
                {
                    // if else if whichever is lower gets placed next
                    // and it's cursor incremented.
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
                    // both are equal
                    else
                    {
                        arrie3[i] = arrie1[curs1];
                        arrie3[i + 1] = arrie2[curs2];
                        i += 2;
                        curs1++;
                        curs2++;
                    }
                }
                // only one number left
                else
                {
                    // check if it's the first, else in the second
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
            return !arrie1.Where((t, i) => t != arrie2[i]).Any();
        }

        // print the arrays.
        public static void PrintArray(int[] arrg)
        {
            foreach (var n in arrg)
            {
                Console.Write(Convert.ToString(n) + " | " );
            }
        }
    }
}