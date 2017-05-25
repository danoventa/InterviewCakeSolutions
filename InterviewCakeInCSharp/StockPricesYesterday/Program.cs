using System;
using System.Collections.Generic;
using System.Threading;

namespace StockPricesYesterday
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int> {8, 8, 8, 8};
            var stockPrices = new List<List<int>>
            {
                list,
                new List<int>
                {
                    1,2,3,4,5,6,7,8
                },
                new List<int>
                {
                    8,7,6,5,4,3,2,1
                },
                new List<int>
                {
                    1,4,6,2,8,9,3,5,8,2,13,5
                }
            };

            foreach (var l in stockPrices)
            {
                Console.WriteLine("Best you could do is: " + BestPossibleIncrease(l));
            }
        }

        public static int BestPossibleIncrease(List<int> stocks)
        {
            var topWin = int.MinValue;
            var localWin = int.MinValue;
            var count = 0;
            
            while (count < stocks.Count)
            {
                if (localWin == int.MinValue)
                {
                    localWin = 0;
                    topWin = Math.Max(localWin, topWin);
                    count++;
                    continue;
                }
                if (stocks[count] - stocks[count -1] < 0)
                {
                    topWin = Math.Max(localWin, topWin);
                    localWin = 0;
                    count++;
                    continue;
                }
                localWin += stocks[count] - stocks[count - 1];    
                count++;
            }
            topWin = Math.Max(localWin, topWin);
            
            return topWin;
        }
    }
}