using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace InPlaceShuffle
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            var arr = new [] {2, 3, 4, 5, 6};
            foreach (var n in arr)
            {
                Console.WriteLine("Original Val: " + n);
            }
            var rLoc = new Random(arr.Length);
            for (var i = 0; i < arr.Length; i++)
            {
                var pos = rLoc.Next(0, arr.Length - 1);
                var tempVal = arr[i];
                arr[i] = arr[pos];
                arr[pos] = tempVal;
            }
            foreach (var n in arr)
            {
                Console.WriteLine("Shuffled Val: " + n);
            }
        }
    }
}