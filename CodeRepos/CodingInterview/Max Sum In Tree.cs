using System;
using System.Collections.Generic;

/// <summary>
/// [题目]:
/// 二叉树每个结点都有一个int型权值，给定一棵二叉树，要求计算出从根结点到叶结点的所有路径中，权值和最大的值为多少。
/// </summary>
namespace CodingInterview.Max_Sum_In_Tree
{
	class MaxSumInTree
	{
		public class Node
		{
			public int value;
			public Node left;
			public Node right;

			public Node(int val)
			{
				value = val;
			}
		}

		public static int MaxSumRecursive(Node root)
		{
			return Process2(root);
		}

		private static int Process(Node node, int pre)
		{
			if (node == null)
				return int.MinValue;

			if (node.left == null && node.right == null)
				return pre + node.value;

			int left = Process(node.left, pre + node.value);
			int right = Process(node.right, pre + node.value);

			return Math.Max(left, right);
		}

		private static int Process2(Node node)
		{
			int next = int.MinValue;

			if (node.left != null)
				next = Math.Max(next, Process2(node.left));

			if (node.right != null)
				next = Math.Max(next, Process2(node.right));

			return node.value + (node.left == null && node.right == null ? 0 : next);
		}

		public static int MaxSumUnrecursive(Node root)
		{
			int max = 0;
			int preSum = 0;
			Stack<(Node, bool)> stack = new Stack<(Node, bool)>();
			stack.Push((root, false));

			while (stack.Count > 0)
			{
				(Node, bool) peek = stack.Pop();

				if (!peek.Item2)
				{
					stack.Push((peek.Item1, true));
					preSum += peek.Item1.value;
					if (peek.Item1.right != null)
						stack.Push((peek.Item1.right, false));
					if (peek.Item1.left != null)
						stack.Push((peek.Item1.left, false));
				}
				else
				{
					if (peek.Item1.left == null && peek.Item1.right == null)
						max = Math.Max(max, preSum);
					preSum -= peek.Item1.value;
				}
			}
			return max;
		}

		//public static void Main()
		//{
		//	Node root = new Node(4);
		//	root.left = new Node(1);
		//	root.left.left = new Node(10);
		//	root.left.right = new Node(5);
		//	root.right = new Node(-7);
		//	root.right.left = new Node(3);
		//	root.right.right = new Node(2);
		//	root.right.right = new Node(100);
		//	Console.WriteLine($"MaxSumRecursive: {MaxSumRecursive(root)} - MaxSumUnrecursive: {MaxSumUnrecursive(root)}");
		//	Console.ReadLine();
		//}
	}
}
