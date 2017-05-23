using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Security.Policy;

namespace SevenSidedDie
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            for (var i = 0; i < 50; i++)
            {
                Console.WriteLine(Rand7(i));
            }
        }

        public static int Rand7(int seed)
        {
            var val = int.MaxValue;
            var counter = 0;

            while (val > 7)
            {
                val = Rand5(seed + counter);
                counter++;
                val += Rand5(seed + counter);
            }
            
            return val;
        }

        public static int Rand5(int seed)
        {
            var rand = new Random(seed);
            
            return rand.Next(1,6);
        }
    }
}