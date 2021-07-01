using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0145 Binary Tree Postorder Traversal
/// </summary>
namespace CodeInCS._0145_Binary_Tree_Postorder_Traversal
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
		public IList<int> PostorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			PostOrder(root, res);
			return res;
		}

		private void PostOrder(TreeNode node, IList<int> list)
		{
			if (node == null)
				return;
			PostOrder(node.left, list);
			PostOrder(node.right, list);
			list.Add(node.val);
		}
	}

	public class Solution2
	{
		public IList<int> PostorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			if (root == null)
				return res;

			Stack<(TreeNode, bool)> stack = new Stack<(TreeNode, bool)>();
			stack.Push((root, false));
			while (stack.Count > 0)
			{
				(TreeNode, bool) top = stack.Pop();
				if (!top.Item2)
				{
					stack.Push((top.Item1, true));
					if (top.Item1.right != null)
						stack.Push((top.Item1.right, false));
					if (top.Item1.left != null)
						stack.Push((top.Item1.left, false));
				}
				else
					res.Add(top.Item1.val);
			}
			return res;
		}
	}

	public class Solution3
	{
		public IList<int> PostorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			if (root == null)
				return res;

			Stack<int> res_stack = new Stack<int>();
			Stack<TreeNode> stack = new Stack<TreeNode>();
			stack.Push(root);
			while (stack.Count > 0)
			{
				TreeNode top = stack.Pop();
				res_stack.Push(top.val);

				if (top.left != null)
					stack.Push(top.left);

				if (top.right != null)
					stack.Push(top.right);
			}

			while (res_stack.Count > 0)
				res.Add(res_stack.Pop());
			return res;
		}
	}
}
