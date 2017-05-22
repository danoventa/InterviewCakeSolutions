using System;
using System.Collections.Generic;
using System.IO;

namespace WordCloudData
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = "This is how split work! If you'll take a look at dis, we can discuss it b'tter";
            var l = Split(s);
            foreach (var word in l)
            {
                Console.WriteLine(word);
            }
        }

        public static List<string> Split(string inputString)
        {
            var returnList = new List<string>();
            var waitForBlank = false;

            var nextWord = "";
            foreach (var c in inputString)
            {
                if (c == ' ' )
                {
                    if (waitForBlank)
                    {
                        waitForBlank = false;
                    }
                    returnList.Add(nextWord);
                    nextWord = "";
                    continue;
                }
                if (char.IsLetter(c))
                {
                    if (!waitForBlank)
                    {
                        nextWord += c.ToString();
                    }
                    continue;
                }
                waitForBlank = true;
            }
            returnList.Add(nextWord);
            return returnList;
        }
    }
}