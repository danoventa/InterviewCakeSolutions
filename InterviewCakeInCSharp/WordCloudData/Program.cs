using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;

namespace WordCloudData
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = "We came, we saw, we conquered...then we ate Bill's (Mille-Feuille) cake.";
            var d = new Dictionary<string, int>();

            CacheWords(d, s);

            foreach (var k in d)
            {
                 Console.WriteLine("Key: " + Convert.ToString(k.Key) + " Velue: " + Convert.ToString(k.Value));
            }
        }

        public static void CacheWords(Dictionary<string, int> dict, string str)
        {
            var l = Split(str);
            foreach (var word in l)
            {
                if (dict.ContainsKey(word.ToLower()))
                {
                    dict[word.ToLower()]++;
                    continue;
                }
                dict.Add(word.ToLower(), 1);
            }
        }

        // String builder has a Clear() function to clear a string
        // Could use string builder, which uses a char[] instead of an immutable string.
        public static List<string> Split(string inputString)
        {
            var returnList = new List<string>();
            var waitForBlank = false;

            var nextWord = "";
            var temp = "";
            foreach (var c in inputString)
            {
                Console.WriteLine(temp);
                if (c == ' ' || c == '-' || c == '(' || temp == "..")
                {
                    if (waitForBlank)
                    {
                        waitForBlank = false;
                        temp = "";
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
                temp += c;
                waitForBlank = true;
            }
            returnList.Add(nextWord);
            return returnList;
        }
    }
}