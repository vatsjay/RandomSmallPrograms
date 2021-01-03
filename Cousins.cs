using System;

public class GFG
{
    static public void Main1()
    {
        //Code

        var root = GenerateTree();
        PrintCousins(root, root.Left.Left);
    }

    private static int FindLevelFromNodeValue(Node root, Node node, int level)
    {
        if (root == null)
            return 0;
        if (root == node)
            return level;

        int levelFromLeftTree = FindLevelFromNodeValue(root.Left, node, level + 1);

        if (levelFromLeftTree != 0)
            return levelFromLeftTree;

        int levelFromRightTree = FindLevelFromNodeValue(root.Right, node, level + 1);

        return levelFromRightTree;

    }

    private static void PrintCousins(Node root, Node node)
    {
        int level = FindLevelFromNodeValue(root, node, 1);

        PrintLevelWithoutSiblings(root, node, level);
    }


    private static void PrintLevelWithoutSiblings(Node root, Node node, int level)
    {
        if (root == null || level < 2)
            return;

        if (level == 2)
        {
            if (root.Left == node || root.Right == node)
                return;
            if (root.Left != null)
                Console.WriteLine(root.Left.Value);
            if (root.Right != null)
                Console.WriteLine(root.Right.Value);
        }
        else
        {
            PrintLevelWithoutSiblings(root.Left, node, level - 1);
            PrintLevelWithoutSiblings(root.Right, node, level - 1);
        }
    }


    private static Node GenerateTree()
    {
        Node root = newNode(1);
        root.Left = newNode(2);
        root.Right = newNode(3);
        root.Left.Left = newNode(4);
        root.Left.Right = newNode(5);
        root.Right.Left = newNode(6);
        root.Right.Right = newNode(7);
        root.Left.Left.Left = newNode(8);
        root.Left.Left.Right = newNode(9);

        return root;
    }

    private static Node newNode(int item)
    {
        Node temp = new Node();
        temp.Value = item;
        temp.Left = null;
        temp.Right = null;
        return temp;
    }
}

public class Node
{
    public int Value;
    public Node Left, Right;
}