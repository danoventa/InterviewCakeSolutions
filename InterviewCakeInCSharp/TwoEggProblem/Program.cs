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
            var bPoint = 1;
            var eggs = 2; // this is built for 2 eggs, later can enhance to handle more.

            var floorFound = FindHighestFloor(eggs, bPoint, floors);
            Console.WriteLine(floorFound.ToString());
        }

        public static int FindHighestFloor(int eggs, int bPoint, int floors)
        {
            var atPoint = 1;
            var counter = 0;
            var nextVal = 0;
            while (true)
            {
                counter++;
                Console.WriteLine($"atPoint: {atPoint}");
                Console.WriteLine($"Counter: {counter}");
                if (eggs > 1)
                {

                    nextVal += _solveQuadratic(floors - nextVal);
                    if (nextVal < bPoint)
                    {
                        atPoint = nextVal;
                    }
                    else if (nextVal == bPoint)
                    {
                        break;
                    }
                    else
                    {
                        eggs--;
                    }
                }
                else
                {
                    if (atPoint != bPoint)
                    {
                        atPoint++;
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
            if (inner == Double.NaN){ throw new Exception("Issue over here?");}
            Console.WriteLine($"Inner: {inner}");
            var plus = (1.0 + inner) / 2.0;
            var minus = (1.0 - inner) / 2.0;
            var next = Math.Max(Math.Ceiling(plus), Math.Ceiling(minus));

            return (int)next;
        }
    }
}