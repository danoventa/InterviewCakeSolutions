using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Policy;

namespace URLShortener
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var keepItUp = true;
            var url = "";

            var linkMap = new Dictionary<string, string>();
            // Probs want this to be in a server like architecture, in order to store all links, and reference them somehow.

            while (keepItUp)
            {
                Console.Write("Customize your link? ");
                var isCustom = Console.ReadLine();
                Console.Write("Your Address? ");
                url = Console.ReadLine();

                url = isCustom != null && isCustom.ToLower() != "yes" ? generateShortURL(url, linkMap) : generateCustomURL(url, linkMap);
                Console.WriteLine("This is your new URL: " + url);
                Console.Write("Another? ");

                var another = Console.ReadLine();
                keepItUp = another != null && another.ToLower() != "yes" ? false : true;
            }

            printKeys(linkMap);
        }

        public static void printKeys(Dictionary<String, String> linkMap)
        {
            foreach(var kp in linkMap)
            {
                 Console.Write("\n " + kp.Key +  " has " + kp.Value);
            }
        }

        public static string generateShortURL(string url, Dictionary<string, string> linkMap)
        {

            var hash = url.GetHashCode();
            var newUrl = "ca.ke/" + Convert.ToString(hash);
            linkMap.Add(newUrl, url);
            return newUrl;
        }

        public static string generateCustomURL(string url, Dictionary<string, string> linkMap)
        {
            Console.WriteLine("What would you like the custom name to be? ");
            var customName = Console.Read();
            var newUrl = "ca.ke/" + customName;
            linkMap.Add(newUrl, url);
            return newUrl;
        }

        // modify or delete?

        // secure?

        // exists forever?

        // custom shorter link is available

        // analytics

        // db design
        // can have users ?
        // sites


    }
}