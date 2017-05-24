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
            
            Array.Sort(xar);
            var counter = 0;
            var last = 0;
            var dup = int.MinValue;
            while (true)
            {
                if (counter == 0)
                {
                    last = xar[counter];
                    counter++;
                    continue;
                }
                if (last == xar[counter])
                {
                    dup = xar[counter];
                    break;
                }
                last = xar[counter];
                counter++;
            }
            
            Console.WriteLine("Dup is: " + dup);
        }
    }
}