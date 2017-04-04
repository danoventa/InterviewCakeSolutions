using System;
using System.Collections;
using static System.Console;
using static System.Convert;
using System.Linq;
using System.Reflection;

namespace SpeakingCSh
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ReflectionFunction();

        }

        public static void ReflectionFunction()
        {

            var methodCount = 0;
            foreach (var r in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                var a = Assembly.Load(r.FullName);
                foreach (var t in a.DefinedTypes)
                {
                    methodCount += t.GetMethods().Count();

                }
                WriteLine($"{a.DefinedTypes.Count():N0} types with {methodCount:N0} methods in {r.Name} assembly.");



            }

            WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to \n\t\t\t\t {int.MaxValue:N0}.");
            WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to \n\t\t\t\t {double.MaxValue:N0}.");
            WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to \n\t\t\t\t {decimal.MaxValue:N0}.");


            // Foreach and collections use iterators, and hence cannot modify the assigned variable. :(
            // # readonly
            string[] names = { "Adam", "Barry", "Charlie" };
            foreach (string name in names)
            {
                WriteLine($"{name} has {name.Length} characters.");
            }

            IEnumerator e = names.GetEnumerator();
            while(e.MoveNext())
            {
                string name = (string)e.Current; // Current is read-only!
                WriteLine($"{name} has {name.Length} characters.");
            }

            double g = 9.8;
            int h = ToInt32(g);
            int j = (int)g;
            // Convert library takes the decimal into account, while a bare converstion loses the decimal.
            WriteLine($"g is {g} and h is {h} and j is {j}");
            // toint uses bankers rule (even rounds down, odd rounds up on the .5)
        }
    }
}