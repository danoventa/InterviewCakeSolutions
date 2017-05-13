using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace RectangularLove
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var person1 = new Rectangle(0, 0, 3, 4);

            var person2 = new Rectangle(1, 2, 4, 4);

            var loveTriangle = GetLoveTriangle(person1, person2);
            
            Console.WriteLine(Convert.ToString(loveTriangle.LeftX));
            Console.WriteLine(Convert.ToString(loveTriangle.BottomY));
            Console.WriteLine(Convert.ToString(loveTriangle.Width));
            Console.WriteLine(Convert.ToString(loveTriangle.Height));

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