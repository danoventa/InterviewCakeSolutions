using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;

namespace RectangularLove
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var person1 = new Rectangle(0, 0, 3, 4);

            var person2 = new Rectangle(2, 2, 4, 4);

            var loveTriangle = GetLoveTriangle(person1, person2);

            Console.WriteLine(Convert.ToString(loveTriangle.LeftX));
            Console.WriteLine(Convert.ToString(loveTriangle.BottomY));
            Console.WriteLine(Convert.ToString(loveTriangle.Width));
            Console.WriteLine(Convert.ToString(loveTriangle.Height));

        }

        public static Rectangle GetLoveTriangle(Rectangle person1, Rectangle person2)
        {

            var leastBottomest = Math.Max(person1.BottomY, person2.BottomY);
            var leastLeftest = Math.Max(person1.LeftX, person2.LeftX);

            var leastToppest = Math.Min(person1.BottomY + person1.Height, person2.BottomY + person2.Height);
            var leastRightest = Math.Min(person1.LeftX + person1.Width, person2.LeftX + person2.Width);

            var loveWidth = leastRightest - leastLeftest;
            var loveHeight = leastToppest - leastBottomest;

            if (loveWidth <= 0 || loveHeight <= 0)
            {
                throw new Exception("There is no love here...");
            }

            var loveRectangle = new Rectangle(leastLeftest, leastBottomest, loveWidth, loveHeight);

            return loveRectangle;

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