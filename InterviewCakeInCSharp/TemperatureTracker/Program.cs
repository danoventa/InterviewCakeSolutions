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
            private Node _head;
            private int _max = int.MinValue;
            private int _min = int.MaxValue;
            private int _mode;
            private double _mean;

            public void Insert(int val)
            {
                if (_head == null)
                {
                    _max = val;
                    _min = val;
                    _mode = val;
                    _mean = val;
                    _head = new Node(val);
                    return;
                }


            }

            public int GetMax()
            {
                return _max;
            }

            public int GetMin()
            {
                return _min;
            }

            public int GetMode()
            {
                return _mode;
            }

            public double GetMean()
            {
                return _mean;
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