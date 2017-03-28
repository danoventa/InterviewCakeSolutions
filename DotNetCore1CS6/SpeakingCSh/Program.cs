using System;
using System.Collections.Generic;
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
                Console.WriteLine($"{a.DefinedTypes.Count():N0} types with {methodCount:N0} methods in {r.Name} assembly.");



            }

            Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to \n\t\t\t\t {int.MaxValue:N0}.");
            Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to \n\t\t\t\t {double.MaxValue:N0}.");
            Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to \n\t\t\t\t {decimal.MaxValue:N0}.");


        }
    }
}