using System;
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
            private Node Head;
            private int _Max;
            private int _Min;
            private int _Mode;
            private double _Mean;

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
                return _Max;
            }

            public int GetMin()
            {
                return _Min;
            }

            public int GetMode()
            {
                return _Mode;
            }

            public double GetMean()
            {
                return _Mean;
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