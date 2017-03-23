using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace nthFibonacci
{
    internal class Program
    {
        private static double phi = (1 + Math.Sqrt(5)) / 2;
        public static void Main(string[] args)
        {
            const int nth = 45;

            // fib of 1 = 1
            //

            // nthFiboCalculated(nth); // precision is not important, use golden ratio
            Console.WriteLine(Convert.ToString(nthFiboCalculated(nth))); // recursive probs want to ameliorate
            // learn how do matrix multipliction to drop this down to log n
            Console.WriteLine(Convert.ToString(nthFiboRecursive(nth))); // recursive probs want to ameliorate
        }

        private static int dictionaryCheck(int number, Dictionary<int, int> visited)
        {
            int value;
            if (visited.TryGetValue(number, out value))
            {
                return value;
            }
            return number;
        }

        private static int nthFiboRecursiveHelper(int number, Dictionary<int, int> visited)
        {
            if (number == 0)
            {
                return 0;
            }
            if (number == 1)
            {
                return 1;
            }
            if (number == 5)
            {
                return 5;
            }
            var visNum = dictionaryCheck(number, visited);
            if (visNum != number )
            {
                return visNum;
            }

            return nthFiboRecursiveHelper(number - 1, visited) + nthFiboRecursiveHelper(number - 2, visited);
        }


        public static int nthFiboRecursive(int number)
        {
            return nthFiboRecursiveHelper(number, new Dictionary<int, int>());
        }

        public static double nthFiboCalculated(int nth)
        {
            return Math.Round((Math.Pow(phi, nth) - Math.Pow(-phi, -nth)) / (2*phi - 1));
        }
    }
}