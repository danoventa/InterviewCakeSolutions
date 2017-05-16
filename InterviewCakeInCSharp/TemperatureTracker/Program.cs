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
            var testList = new List<TempTracker>
            {
                new TempTracker(),
                new TempTracker(),
                new TempTracker(),
                new TempTracker(),
                new TempTracker()
            };

            foreach (var test in testList)
            {
                var rand = new Random(15);
                Console.WriteLine(rand.Next());
                for (var i = 0; i < rand.Next(); i++)
                {
                    var next = rand.Next();
                    Console.Write(Convert.ToString(next));
                    test.Insert(next);
                }
            }
        }

        public class TempTracker
        {
            private int _max = int.MinValue;
            private int _min = int.MaxValue;

            private int _modeMax;
            private int _mode;

            private double _mean;
            private int _count;
            private int _sum;

            private readonly Dictionary<int, int> _tracker = new Dictionary<int, int>();

            public void Insert(int val)
            {
                if (_tracker.ContainsKey(val))
                {
                    _tracker[val] += 1;
                }
                else
                {
                    _tracker.Add(val, 1);
                }

                if (_modeMax < _tracker[val])
                {
                    _modeMax = _tracker[val];
                    _mode = val;
                }

                if (val > _max)
                {
                    _max = val;
                }

                if (val < _min)
                {
                    _min = val;
                }

                _sum += val;
                _count += 1;
                _mean = _sum / _count;
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
    }
}