using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ShuffleDeck
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var deck = new int[52];
            for(var i = 0; i < 52; i++)
            {
                deck[i] = i + 1;
            }
            
            var newDeck = RuffleDeck(ref deck);

            Console.WriteLine("Ruffled Deck: ");
            foreach (var n in newDeck)
            {
                Console.Write(n + " " );
            }
            
            Array.Sort(newDeck);
            Console.WriteLine("\nSortedArray: ");
            foreach (var n in newDeck)
            {
                Console.Write(n + " " );
            }
        }
        
        public static int[] RuffleDeck(ref int[] deck)
        {
            var size = deck.Length;
            var half = size / 2;

            var nextNum = new Random(52);
            var ruffled = false;
            var topDone = false;
            var bottomDone = false;
            var topHalf = half - 1;
            var bottomHalf = 0;

            int atDeck = 0;
            while(!ruffled)
            {
                var top = topHalf;
                topHalf  = nextNum.Next(topHalf, 53);
                for (var i = top; i < topHalf; i++)
                {
                    deck[atDeck] = i+1;
                    atDeck++;
                }
                if (topHalf == 52)
                {
                    topDone = true;
                }
                var bottom = bottomHalf;
                bottomHalf = nextNum.Next(bottomHalf, half + 1);
                for (var i = bottom; i < bottomHalf; i++)
                {
                    deck[atDeck] = i+1;
                    atDeck++;
                }
                if (bottomHalf == half - 1)
                {
                    bottomDone = true;
                }

                ruffled = topDone && bottomDone;
            }
            
            

            return deck;
        }
    }
}