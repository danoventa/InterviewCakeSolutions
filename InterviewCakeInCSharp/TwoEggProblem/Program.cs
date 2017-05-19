using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;

namespace TwoEggProblem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var floors = 100;
            var bPoint = 50;
            var eggs = 5;

            var floorFound = FindHighestFloor(eggs, bPoint, floors);
            Console.WriteLine(floorFound.ToString());
        }

        public static int FindHighestFloor(int eggs, int bPoint, int floors)
        {
            var atPoint = 1;
            var counter = 0;
            var nextVal = _solveQuadratic(floors);

            while (counter < floors)
            {
                counter++;

                if (eggs > 1)
                {
                    if (nextVal < bPoint)
                    {
                        atPoint = nextVal;
                        nextVal += Math.Min(_solveQuadratic((floors - nextVal) + nextVal), floors);
                    }
                    else if (nextVal == bPoint || atPoint == bPoint)
                    {
                        atPoint = nextVal;
                        break;
                    }
                    else
                    {
                        nextVal -= Math.Max(_solveQuadratic((floors - nextVal) + nextVal), 0)/2;
                        eggs--;
                    }
                }
                else
                {
                    if (atPoint < bPoint)
                    {
                        atPoint++;
                        continue;
                    }
                    if (atPoint > bPoint)
                    {
                        atPoint--;
                        continue;
                    }
                    break;
                }
            }

            return counter;
        }

        private static int _solveQuadratic(int floors)
        {
            int enclosed = 4 * floors * 2;
            var inner = Math.Sqrt(1.0 + (double)enclosed);
            if (inner == Double.NaN){ throw new Exception("Issue over here, look at me, I'm Mr. Meseeks!");}

            var plus = (inner) / (2.0 );
            var minus = (inner) / (2.0 );
            var next = Math.Max(Math.Ceiling(plus), Math.Ceiling(minus));

            return (int)next;
        }
    }
}