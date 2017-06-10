using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace TemperatureTracker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var testList = new List<TempTracker2>
            {
                new TempTracker2(),
                new TempTracker2(),
                new TempTracker2(),
                new TempTracker2(),
                new TempTracker2()
            };
            var counter = 0;
            foreach (var test in testList)
            {
                var rand = new Random();
                Console.WriteLine();
                Console.WriteLine("Load this one: ");
                var cap = rand.Next(9 + counter);
                for (var i = 0; i < cap; i++)
                {
                    var next = rand.Next(9 + i + counter);
                    Console.WriteLine("Next: " + Convert.ToString(next));
                    test.Insert(next);
                }
                counter++;
                Console.WriteLine("Test This one ");
                Console.WriteLine("Max: " + Convert.ToString(test.GetMax()));
                Console.WriteLine("Min: " + Convert.ToString(test.GetMin()));
                Console.WriteLine("Mode: " + Convert.ToString(test.GetMode()));
                Console.WriteLine("Mean: " + Convert.ToString(test.GetMean(), CultureInfo.InvariantCulture));
                Console.WriteLine();

                if (test.GetMax() > 0 && test.GetMin() > 0)
                {
                    Console.WriteLine("This Works");
                }
            }

            // var sums = new List<int> {-4, -3, -2, -2, -2, -3, -4, -1};
            // var sums = new List<int> {-4, -3, -2, -2, 0, -3, -4, -1};
            var sums = new List<int> {1 ,2, 3, -2, 4, -3, 1, -1};
            // var sums = new List<int> {1, 2, 3, 4, 5};


            Console.WriteLine(Convert.ToString(getMaxSum(sums)));

            Console.WriteLine(Convert.ToString(getMaxSum2(sums)));
        }

        public static int getMaxSum2(List<int> sums)
        {
            var maxSum = int.MinValue;
            var curSum = int.MinValue;

            foreach (var n in sums)
            {
                if (curSum == int.MinValue)
                {
                    curSum = n;
                    continue;
                }
                if (curSum >= curSum + n)
                {
                    maxSum = Math.Max(maxSum, curSum);
                    curSum = curSum > n ? int.MinValue : n;
                    continue;
                }
                curSum += n;
            }
            var max = Math.Max(maxSum, curSum);
            return max;
        }

        public static int getMaxSum(List<int> sums) {

            if(sums.Count == 0){
                return 0;
            }

            if(sums.Count == 1) {
                return sums[0];
            }

            var maxSum = int.MinValue;
            var currMax = int.MinValue;
            foreach (var t in sums)
            {
                if (t < 0)
                {
                    if (maxSum < currMax)
                    {
                        maxSum = currMax;
                        currMax = int.MinValue;
                        continue;
                    }
                    if (maxSum == currMax)
                    {
                        maxSum = t;
                        continue;
                    }
                    if (maxSum < t)
                    {
                        maxSum = t;
                        continue;
                    }
                }

                if (currMax == int.MinValue )
                {
                    currMax = t;
                    continue;
                }
                maxSum = Math.Max(Math.Max(maxSum, currMax), t);
                currMax += t;
            }

            return Math.Max(maxSum, currMax);
        }

        public class TempTracker2
        {
            private int _Max = int.MinValue;
            private int _Min = int.MaxValue;

            private int _Sum = 0;
            private int _Count = 0;

            private double _Mean = 0.0;

            private Dictionary<int, int> _TempCount = new Dictionary<int, int>();
            private int _ModeCount = 0;
            private int _Mode = 0;

            public void Insert(int temperature)
            {
                if (temperature > _Max) _Max = temperature;
                if (temperature < _Min) _Min = temperature;

                _Sum += temperature;
                _Count++;

                _Mean = Math.Floor((double) _Sum / _Count);

                if (_TempCount.ContainsKey(temperature))
                {
                    _TempCount[temperature]++;
                }
                else
                {
                    _TempCount.Add(temperature, 1);
                }
                if (_TempCount[temperature] > _ModeCount)
                {
                    _ModeCount = _TempCount[temperature];
                    _Mode = temperature;
                }
            }

            public int GetMax()
            {
                return _Max;
            }
            public int GetMin ()
            {
                return _Min;
            }
            public double GetMean()
            {
                return _Mean;
            }

            public int GetMode ()
            {
                return _Mode;
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
                _mean = _sum / (double)_count;
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