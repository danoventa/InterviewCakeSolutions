using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace RectangularLove
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var person1 = new Rectangle();
            person1.BottomY = 0;
            person1.LeftX = 0;
            person1.Height = 4;
            person1.Width = 3;

            var person2 = new Rectangle();
            person2.BottomY = 0;
            person2.LeftX = 0;
            person2.Height = 4;
            person2.Width = 3;

            var loveTriangle = GetLoveTriangle(person1, person2);
        }

        public static Rectangle GetLoveTriangle(Rectangle person1, Rectangle person2)
        {

            // identify perimeter boundaries
            // see if any love rectangle exists, if not return 0000 rectangle or error

            // see which is left most, see which is bottom most.
            // see which is right most, see which is top most.

            // generate rectangle

            return new Rectangle();

        }

        // Recrtangle provided by InterviewCake
        public class Rectangle
        {
            // Coordinates of bottom left corner
            public int LeftX { get; set; }
            public int BottomY { get; set; }

            // Dimensions
            public int Width { get; set; }
            public int Height { get; set; }

            public Rectangle() {}

            public Rectangle(int leftX, int bottomY, int width, int height)
            {
                LeftX = leftX;
                BottomY = bottomY;
                Width = width;
                Height = height;
            }
        }
    }
}