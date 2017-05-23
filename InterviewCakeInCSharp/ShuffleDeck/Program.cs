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
        }
        
        public static int[] RuffleDeck(ref int[] deck)
        {
            var size = deck.Length;
            var half = size / 2;
            var newdeck = new int[52];

            var nextNum = new Random(52);
            var ruffled = false;
            var topDone = false;
            var bottomDone = false;
            var topHalf = half;
            var bottomHalf = 0;

            int atDeck = 0;
            while(!ruffled)
            {
                topHalf  = nextNum.Next(topHalf, 51);
                Console.WriteLine("TOP at: " + topHalf);
                for (var i = topHalf; i < topHalf; i++)
                {
                    newdeck[atDeck] = i;
                    atDeck++;
                }
                if (topHalf == 51)
                {
                    topDone = true;
                }

                bottomHalf = nextNum.Next(bottomHalf, half - 1);
                Console.WriteLine("Bottom at: " + bottomHalf);
                for (var i = bottomHalf; i < bottomHalf; i++)
                {
                    newdeck[atDeck] = i;
                    atDeck++;
                }
                if (bottomHalf == half)
                {
                    bottomDone = true;
                }

                ruffled = topDone && bottomDone;
            }
            
            

            return newdeck;
        }
    }
}