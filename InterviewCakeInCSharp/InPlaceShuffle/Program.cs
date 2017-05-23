using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

namespace InPlaceShuffle
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            var arr = new [] {2, 3, 4, 5, 6};
            Console.WriteLine("Original: " );
            foreach (var n in arr)
            {
                Console.Write(n + " " );
            }
            
            ShuffleInPlace(ref arr);
            
            Console.WriteLine("\n\nShuffled:");
            foreach (var n in arr)
            {
                Console.Write(n + " " );
            }
            
            var arr2 = new [] {2, 3, 4, 5, 6};
            Console.WriteLine("\n\nOriginal 2: " );
            foreach (var n in arr2)
            {
                Console.Write(n + " " );
            }
            
            ShuffleInPlaceNotSame(ref arr2);
            
            Console.WriteLine("\n\nShuffled 2:");
            foreach (var n in arr2)
            {
                Console.Write(n + " " );
            }
        }

        public static void ShuffleInPlace(ref int[] arr)
        {
            var rLoc = new Random(arr.Length);

            for (var i = 0; i < arr.Length; i++)
            {
                var pos = rLoc.Next(0, arr.Length - 1);
                var tempVal = arr[i];
                arr[i] = arr[pos];
                arr[pos] = tempVal;
            }
        }
        
        public static void ShuffleInPlaceNotSame(ref int[] arr)
        {
            var rLoc = new Random(arr.Length);

            for (var i = 0; i < arr.Length; i++)
            {
                var pos = rLoc.Next(0, arr.Length - 1);
                while (i == pos)
                {
                    pos = rLoc.Next(0, arr.Length - 1);
                }
                var tempVal = arr[i];
                arr[i] = arr[pos];
                arr[pos] = tempVal;
            }
        }
    }
}