using System;

// C# program to find if there 
// is a subtree with given sum 
public class GFGa
{

	/* A binary tree node has data, 
	pointer to left child and a 
	pointer to right child */
	public class Node
	{
		public int data;
		public Node left, right;
	}

	public class INT
	{
		public int v;
		public INT(int a)
		{
			v = a;
		}
	}

	/* utility that allocates a new 
	node with the given data and 
	null left and right pointers. */
	public static Node newnode(int data)
	{
		Node node = new Node();
		node.data = data;
		node.left = node.right = null;
		return (node);
	}

	// function to check if there exist 
	// any subtree with given sum 
	// cur_sum -. sum of current subtree 
	//		 from ptr as root 
	// sum_left -. sum of left subtree 
	//			 from ptr as root 
	// sum_right -. sum of right subtree 
	//			 from ptr as root 
	public static bool sumSubtreeUtil(Node ptr, INT cur_sum, int sum)
	{
		// base condition 
		if (ptr == null)
		{
			cur_sum = new INT(0);
			return false;
		}

		// Here first we go to left 
		// sub-tree, then right subtree 
		// then first we calculate sum 
		// of all nodes of subtree having 
		// ptr as root and assign it as 
		// cur_sum. (cur_sum = sum_left + 
		// sum_right + ptr.data) after that 
		// we check if cur_sum == sum 
		INT sum_left = new INT(0), sum_right = new INT(0);
		return (sumSubtreeUtil(ptr.left, sum_left, sum)
				|| sumSubtreeUtil(ptr.right, sum_right, sum)
				|| ((cur_sum.v = sum_left.v + sum_right.v + ptr.data) == sum));
	}

	// Wrapper over sumSubtreeUtil() 
	public static bool sumSubtree(Node root, int sum)
	{
		// Initialize sum of 
		// subtree with root 
		INT cur_sum = new INT(0);

		return sumSubtreeUtil(root, cur_sum, sum);
	}

	// Driver Code 
	public static void Main1(string[] args)
	{
		Node root = newnode(8);
		root.left = newnode(5);
		root.right = newnode(4);
		root.left.left = newnode(9);
		root.left.right = newnode(7);
		root.left.right.left = newnode(1);
		root.left.right.right = newnode(12);
		root.left.right.right.right = newnode(2);
		root.right.right = newnode(11);
		root.right.right.left = newnode(3);
		int sum = 22;

		var a = abc.a;


		if (sumSubtree(root, sum))
		{
			Console.WriteLine("Yes");
		}
		else
		{
			Console.WriteLine("No");
		}
	}
}

public static class abc
{
	public static int a = 10;
	static abc()
	{
		Console.WriteLine("this is jay");
	}
}
