using System;
using System.Collections.Generic;

namespace HIghestProductOf3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public static int HighestProductFromThree(List<int> arints)
        {
            if (arints.Count < 3)
            {
                throw new Exception("This function requires at least 3 integers in the List.");
            }
            
            return 1;
        }
    }
}