using System;

/// <summary>
/// LeetCode: 0110 Balanced Binary Tree
/// </summary>
namespace CodeInCS._0110_Balanced_Binary_Tree
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
		public bool IsBalanced(TreeNode root)
		{
			return IsBalancedTree(root).Item1;
		}

		private (bool, int) IsBalancedTree(TreeNode node)
		{
			if (node == null)
				return (true, 0);

			(bool, int) left_res = IsBalancedTree(node.left);
			(bool, int) right_res = IsBalancedTree(node.right);

			int height = Math.Max(left_res.Item2, right_res.Item2) + 1;
			return (left_res.Item1 && right_res.Item1 && Math.Abs(left_res.Item2 - right_res.Item2) == 1) ? (true, height) : (false, height);
		}
	}
}
