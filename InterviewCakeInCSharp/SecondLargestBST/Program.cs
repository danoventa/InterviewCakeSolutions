using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SecondLargestBST
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var head1 = new BinaryTreeNode(0);
            head1.InsertRight(1).InsertRight(2); // should be 1

            var head2 = new BinaryTreeNode(0);
            head2.InsertRight(1); // should be 0

            var head3 = new BinaryTreeNode(2);
            head3.InsertLeft(1); // should be 1
            
            var head4 = new BinaryTreeNode(0); // Error, only 1

            var s = "string strin string";
            var b = s[0] == s.ToUpper()[0];
            Console.WriteLine(b);
            
            // var head5 = null; // error, node is null
            
            Console.WriteLine("Tree 1: " + SecondLargestElement(head1));
            Console.WriteLine("Tree 2: " + SecondLargestElement(head2));
            Console.WriteLine("Tree 3: " + SecondLargestElement(head3));
            try
            {
                Console.WriteLine("Tree 4: " + SecondLargestElement(head4));
            }
            catch
            {
                Console.WriteLine("Tree four throws expected error");
            }
           
        }

        public static int SecondLargestElement(BinaryTreeNode node)
        {
            while (true)
            {
                if (node == null) throw new Exception("Given node is null");
                if (node.Right == null)
                {
                    if (node.Left != null) return node.Left.Value;
                    throw new Exception("Only head node exists.");
                }
                if (node.Right != null)
                {
                    if (node.Right.Right == null)
                    {
                        return node.Value;
                    }
                }
                node = node.Right;
            }
        }
    }
   
    
    internal class BinaryTreeNode
    {
        public int Value { get; }
        public BinaryTreeNode Left { get; private set; }
        public BinaryTreeNode Right { get; private set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public BinaryTreeNode InsertLeft(int leftValue)
        {
            Left = new BinaryTreeNode(leftValue);
            return Left;
        }

        public BinaryTreeNode InsertRight(int rightValue)
        {
            Right = new BinaryTreeNode(rightValue);
            return Right;
        }
    }
}