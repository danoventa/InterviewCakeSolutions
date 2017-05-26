using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Policy;

namespace ProductOfAllOtherNumbers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // find
            var x = new List<List<int>>
            {
                new List<int> {1, 2, 3}, // {6, 3, 2}
                new List<int> {2, 3, 4}, // {12, 8, 6}
                new List<int> {9, 8, 7}, // {56, 63, 72} 
                new List<int> {0, 1, 2}, // {2, 0, 0}
                new List<int> {-1, 1, 0} // {0, 0, -1}
            };

            foreach (var l in x)
            {
                PrintList(BadProductOfAllOtherNumbers(l));
            }
            Console.WriteLine();
            foreach (var l in x)
            {
                PrintList(BalancedProductOfAllOtherNumbers(l));
            }
            Console.WriteLine();
            foreach (var l in x)
            {
                PrintList(BetterProductOfAllOtherNumbers(l));
            }
        }
        
        public static void PrintList(List<int> lintz)
        {
            Console.WriteLine();
            Console.Write("{ ");
            foreach (var i in lintz)
            {
                Console.Write(i + " ");
            }
            Console.Write("}");
        }

        public static List<int> BetterProductOfAllOtherNumbers(List<int> lint)
        {
            var allList = new List<int>();
            var trailProd = 1;
            foreach (var t in lint)
            {
                allList.Add(trailProd);
                trailProd *= t;
            }
            var leadProd = 1;
            for (var i = lint.Count - 1; i > -1; i--)
            {
                allList[i] *= leadProd;
                leadProd *= lint[i];
            }
            return allList;
        }

        public static List<int> BalancedProductOfAllOtherNumbers(List<int> lint)
        {
            var index = 0;
            var proBefore = 1;
            var newList = new List<int>();
            while (index < lint.Count)
            {
                if (index != 0)
                {
                    proBefore *= lint[index - 1];
                }
                var proAfter = 1;
                for (var i = index + 1; i < lint.Count; i++)
                {
                    proAfter *= lint[i];
                }
                index++;
                newList.Add(proBefore * proAfter);
            }   
            return newList;
        }
        

        // find product of every integer, except the integer at that point. 
        public static List<int> BadProductOfAllOtherNumbers(List<int> lint)
        {
            var index = 0;
            var newList = new List<int>();
            while (index < lint.Count)
            {
                var proBefore = 1;
                for (var i = 0; i < index; i++)
                {
                    proBefore *= lint[i];
                }
                var proAfter = 1;
                for (var i = index + 1; i < lint.Count; i++)
                {
                    proAfter *= lint[i];
                }
                index++;
                newList.Add(proBefore * proAfter);
            }   
            return newList;
        }
    }
}