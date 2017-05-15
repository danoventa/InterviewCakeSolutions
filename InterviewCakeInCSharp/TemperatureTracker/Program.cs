using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

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
                var dictionary = new Dictionary<int, int>();
                GetMeandR(node, dictionary);
                var count = 0;
                var sum = 0;
                foreach (var item in dictionary)
                {
                    sum += item.Key;
                    count += item.Value;
                }

                return sum / count;
            }

            private static void GetMeandR(Node node, Dictionary<int, int> dictionary)
            {
                if (node == null)
                {
                    return;
                }
                if (dictionary.ContainsKey(node.Value))
                {
                    dictionary[node.Value] += 1;
                }
                else
                {
                    dictionary.Add(node.Value, 1);
                }
                GetMeandR(node.Left, dictionary);
                GetMeandR(node.Right, dictionary);
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