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
            var tempVal = 0;
            var rLoc = new Random(arr.Length);
            for (var i = 0; i < arr.Length; i++)
            {
                var pos = rLoc.Next(arr.Length);
                tempVal = arr[i];
                arr[i] = arr[tempVal];
                arr[tempVal] = trmpVal;
            }
        }
    }
}