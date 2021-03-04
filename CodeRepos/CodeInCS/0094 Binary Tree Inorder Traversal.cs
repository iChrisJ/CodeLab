using System.Collections.Generic;

/// <summary>
/// LeetCode: 0094 Binary Tree Inorder Traversal
/// </summary>
namespace CodeInCS._0094_Binary_Tree_Inorder_Traversal
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
		public IList<int> InorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			InOrder(root, res);
			return res;
		}

		private void InOrder(TreeNode node, IList<int> list)
		{
			if (node == null)
				return;

			InOrder(node.left, list);
			list.Add(node.val);
			InOrder(node.right, list);
		}
	}

	public class Solution2
	{
		public IList<int> InorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			if (root == null)
				return res;

			Stack<(TreeNode, bool)> stack = new Stack<(TreeNode, bool)>();
			stack.Push((root, false));
			while (stack.Count != 0)
			{
				(TreeNode, bool) cur = stack.Pop();
				if (!cur.Item2)
				{
					if (cur.Item1.right != null)
						stack.Push((cur.Item1.right, false));
					stack.Push((cur.Item1, true));
					if (cur.Item1.left != null)
						stack.Push((cur.Item1.left, false));
				}
				else
					res.Add(cur.Item1.val);
			}
			return res;
		}
	}

	public class Solution3
	{
		public IList<int> InorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			if (root == null)
				return res;

			Stack<TreeNode> stack = new Stack<TreeNode>();
			TreeNode cur = root;
			while (cur != null || stack.Count > 0)
			{
				if (cur != null)
				{
					stack.Push(cur);
					cur = cur.left;
				}
				else
				{
					cur = stack.Pop();
					res.Add(cur.val);
					cur = cur.right;
				}
			}
			return res;
		}
	}
}
