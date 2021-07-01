using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0144 Binary Tree Preorder Traversal
/// </summary>
namespace CodeInCS._0144_Binary_Tree_Preorder_Traversal
{
	// Definition for a binary tree node.
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}
	public class Solution
	{
		public IList<int> PreorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			PreOrder(root, res);
			return res;
		}

		private void PreOrder(TreeNode node, IList<int> list)
		{
			if (node == null)
				return;

			list.Add(node.val);
			PreOrder(node.left, list);
			PreOrder(node.right, list);
		}
	}

	public class Solution2
	{
		public IList<int> PreorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			if (root == null)
				return res;

			// (TreeNode, bool)中 item2 = false 表示当前节点还未访问过，item2 == true表示当前节点已访问
			Stack<(TreeNode, bool)> stack = new Stack<(TreeNode, bool)>();
			stack.Push((root, false));
			while (stack.Count > 0)
			{
				(TreeNode, bool) top = stack.Pop();
				if (!top.Item2)
				{
					if (top.Item1.right != null)
						stack.Push((top.Item1.right, false));
					if (top.Item1.left != null)
						stack.Push((top.Item1.left, false));
					stack.Push((top.Item1, true));
				}
				else
					res.Add(top.Item1.val);
			}

			return res;
		}
	}

	public class Solution3
	{
		public IList<int> PreorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			if (root == null)
				return res;

			Stack<TreeNode> stack = new Stack<TreeNode>();
			stack.Push(root);

			while (stack.Count > 0)
			{
				TreeNode top = stack.Pop();
				res.Add(top.val);

				if (top.right != null)
					stack.Push(top.right);
				if (top.left != null)
					stack.Push(top.left);
			}
			return res;
		}
	}
}
