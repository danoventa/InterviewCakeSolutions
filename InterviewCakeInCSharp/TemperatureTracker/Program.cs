using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TemperatureTracker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public class TempTracker
        {
            public List<Node> Temperature { get; set; }
            public Node Head { get; set; }

            public void Insert(int temp)
            {
                // insert at proper location
                // BST
            }

            public int GetMax()
            {
                var node = Head;

                while (node.Right != null)
                {
                    node = node.Right;
                }
                return node.Value;
            }

            public int GetMin()
            {
                var node = Head;

                while (node.Left != null)
                {
                    node = node.Left;
                }
                return node.Value;
            }

            public int GetMode()
            {
                return 0;
            }

            public double GetMean()
            {
                var node = Head;
                return GetMeandR(node, 0, 0);
            }

            private static double GetMeandR(Node node, int sum, int count)
            {
                if (node == null)
                {
                    return sum / count;
                }
                return (GetMeandR(node.Left, sum + node.Value , count + 1) +
                          GetMeandR(node.Right, sum + node.Value , count + 1)) / 2;
            }
        }

        public class Node
        {
            public int Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }
    }
}