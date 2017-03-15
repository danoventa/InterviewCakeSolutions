using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace URLShortener
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Customize your Shortened Address? ");
            var custom = Console.Read();
            var url = Console.ReadLine();

            if (custom.ToString().ToLower() != "yes")
            {

                url = generateShortURL(url);
            }
            else
            {
                url = generateCustomURL(url);
            }

            Console.WriteLine(url);
        }

        public static string generateShortURL(string url)
        {
            return "URL";
        }

        public static string generateCustomURL(string url)
        {
            return "URL";
        }

        // modify or delete?

        // secure?

        // exists forever?

        // custom shorter link is available

        // analytics


    }
}