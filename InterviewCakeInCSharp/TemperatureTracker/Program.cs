﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
            public Node Head { get; set; }

            public TempTracker()
            {
                Head = null;
            }

            public void Insert(int val)
            {
                if (Head == null)
                {
                    Head = new Node(val);
                    return;
                }
                var node = Head;

                while (true)
                {
                    if (node.Left == null && node.Right == null)
                    {
                        if (node.Value > val)
                        {
                            node.Right = new Node(val);
                            break;
                        }
                        node.Left = new Node(val);
                        break;
                    }

                    if (node.Value > val)
                    {
                        if (node.Right != null)
                        {
                            if (node.Right.Value < val)
                            {
                                node.Right = new Node(val, node.Right.Left, node.Right);
                                break;
                            }
                            node = node.Right;
                            continue;
                        }
                        node.Right = new Node(val);
                    }

                    if (node.Left == null)
                    {
                        node.Left = new Node(val);
                        break;
                    }
                    if (node.Left.Value > val)
                    {
                        node.Left = new Node(val, node.Left.Right, node.Left);
                        break;
                    }
                    node = node.Left;
                }
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
                var dictionary = new Dictionary<int, int>();
                GetCount(Head, dictionary);
                var max = 0;
                var mode = 0;
                foreach (var item in dictionary)
                {
                    if (item.Value <= max) continue;
                    max = item.Value;
                    mode = item.Key;
                }
                return mode;
            }

            public double GetMean()
            {
                var node = Head;
                var dictionary = new Dictionary<int, int>();
                GetCount(node, dictionary);
                var count = 0;
                var sum = 0;
                foreach (var item in dictionary)
                {
                    sum += item.Key;
                    count += item.Value;
                }

                return sum / count;
            }

            private static void GetCount(Node node, Dictionary<int, int> dictionary)
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
                GetCount(node.Left, dictionary);
                GetCount(node.Right, dictionary);
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

            public Node(int value, Node left, Node right)
            {
                Value = value;
                Left = left;
                Right = right;
            }
        }
    }
}