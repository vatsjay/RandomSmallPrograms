using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_Hackerank_1
{
    public class BinaryTree
    {
        public static void Main1(string[] args)
        {
            Node root = InitializeBinaryTree();
        }

        private static Node InitializeBinaryTree()
        {
            Node root = GenerateNode(1);
            root.Left = GenerateNode(2);
            root.Left = GenerateNode(3);
            root.Right.Left = GenerateNode(4);
            root.Right.Right = GenerateNode(5);
            root.Right.Left.Right = GenerateNode(6);
            root.Right.Left.Left = GenerateNode(7);
            root.Right.Right.Right = GenerateNode(8);
            root.Right.Right.Left = GenerateNode(9);

            return root;
        }

        private static Node GenerateNode(int value)
        {
            return new Node() { Value = value };
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
