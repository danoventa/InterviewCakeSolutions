using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace BinarySearchTreeChecker
{
    internal class Program
    {
        public static void Main(string[] args)
        {


        }
    }

    internal class BinaryTree
    {
        public BinaryTreeNode _root { get; private set; }


        
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

        private BinaryTreeNode InsertLeft(int leftValue)
        {
            Left = new BinaryTreeNode(leftValue);
            return Left;
        }

        private BinaryTreeNode InsertRight(int rightValue)
        {
            Right = new BinaryTreeNode(rightValue);
            return Right;
        }
    }
}