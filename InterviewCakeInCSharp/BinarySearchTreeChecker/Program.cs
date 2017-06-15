using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.AccessControl;
using System.Xml.Xsl.Runtime;

namespace BinarySearchTreeChecker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var head1 = new BinaryTreeNode(0);
            head1.InsertLeft(1);
            head1.InsertRight(2);

            var head2 = new BinaryTreeNode(0);
            head2.InsertLeft(1).InsertLeft(2).InsertLeft(3);
            head2.InsertRight(4);

            var head3 = new BinaryTreeNode(0);
            head3.InsertLeft(1).InsertLeft(2);
            head3.Left.InsertRight(3);
            head3.InsertRight(4);

            var head4 = new BinaryTreeNode(0);
            head4.InsertLeft(1).InsertLeft(2).InsertLeft(3);
            head4.InsertRight(4).InsertLeft(5).InsertRight(6);

            var head5 = new BinaryTreeNode(0);
            head5.InsertLeft(1).InsertLeft(2).InsertLeft(3).InsertLeft(4);
            head5.InsertRight(5).InsertRight(6).InsertRight(7).InsertRight(8);
            head5.Right.InsertLeft(9);
            
            Console.WriteLine(CheckTreeBalance(head1, "head1")); // true
            Console.WriteLine(CheckTreeBalance(head2, "head2")); // false
            Console.WriteLine(CheckTreeBalance(head3, "head3")); //true
            Console.WriteLine(CheckTreeBalance(head4, "head4")); //true
            Console.WriteLine(CheckTreeBalance(head5, "head5")); // false
        }

        public static bool CheckTreeBalance(BinaryTreeNode head, string name)
        {
            Console.WriteLine("In tree: " + name);
            return _TreeBalanced(head, 0, new HashSet<int>());
        }

        private static bool _TreeBalanced(BinaryTreeNode node, int depth, HashSet<int> depths)
        {
            if (node.Left == null && node.Right == null)
            {
                depths.Add(depth);
                if (depths.Count > 2 || depths.Max() - depths.Min() > 1) return false;
                
            }
            
            var left = node.Left == null || _TreeBalanced(node.Left, depth + 1, depths);
            var right = node.Right == null || _TreeBalanced(node.Right, depth + 1, depths);
            
            return left && right;
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