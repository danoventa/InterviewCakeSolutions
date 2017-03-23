using System;
using System.CodeDom;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Threading;

namespace MillionGazillion
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var trie = new Trie();
            var runtTrie = true;
            while (runtTrie)
            {
                runtTrie = WillAddNewAddress();
                if (runtTrie)
                {
                    AddNewAddress(trie);
                }
            }
        }

        public static void AddNewAddress(Trie trie)
        {
            Console.WriteLine("What is the new address");
            var newAddress = Console.ReadLine();

            trie.ProcessCurrentNode(newAddress);
        }

        public static bool WillAddNewAddress()
        {
            Console.WriteLine("Would you like to add another site?");
            var continueReading = Console.ReadLine()?.ToLower();


            return continueReading == "y" || continueReading == "yes";
        }
    }

    internal class Trie
    {
        private const char EndOfWord = '\0';

        private readonly TrieNode _root = new TrieNode();

        public bool ProcessCurrentNode(string word)
        {
            var currentNode = _root;
            bool isWordNew = false;

            foreach (var character in word)
            {
                if (!currentNode.NodeExists(character))
                {
                    isWordNew = true;
                    currentNode.AppendNewNode(character);

                }

                currentNode = currentNode.GetNode(character);
            }

            if(!currentNode.NodeExists(EndOfWord))
            {
                isWordNew = true;
                currentNode.AppendNewNode(EndOfWord);
            }

            return isWordNew;
        }


    }

    internal class TrieNode
    {
        private Dictionary<char, TrieNode> _trieNodes = new Dictionary<char, TrieNode>();

        public bool NodeExists(char character)
        {
            return _trieNodes.ContainsKey(character);
        }

        public void AppendNewNode(char character)
        {
            _trieNodes[character] = new TrieNode();
        }

        public TrieNode GetNode(char character)
        {
            return _trieNodes[character];
        }
    }
}