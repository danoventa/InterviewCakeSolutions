using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace FindRepeatSpace
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var xar = new[] {3, 4, 6, 7, 2, 3, 5, 6, 4};
            
            Console.WriteLine("Dup is: " + FindFirstDuplicate(xar));
        }
        
        public static int FindFirstDuplicate(int[] arr) {
            Array.Sort(arr);

            var counter = 0;
            var last = 0;
            var dup = int.MinValue;
            while (true)
            {
                if (counter == 0)
                {
                    last = arr[counter];
                    counter++;
                    continue;
                }
                if (last == arr[counter])
                {
                    dup = arr[counter];
                    break;
                }
                last = arr[counter];
                counter++;
            }
            return dup;
        }
    }
}