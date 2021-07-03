using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0098 Validate Binary Search Tree
/// </summary>
namespace CodeInCS._0098_Validate_Binary_Search_Tree
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
		private long preVal = long.MinValue;
		public bool IsValidBST(TreeNode root)
		{
			if (root == null)
				return true;
			if (!IsValidBST(root.left))
				return false;

			if (root.val <= preVal)
				return false;

			preVal = root.val;
			return IsValidBST(root.right);
		}
	}

	public class Solution2
	{
		private long preVal = long.MinValue;
		public bool IsValidBST(TreeNode root)
		{
			if (root == null)
				return true;

			Stack<TreeNode> stack = new Stack<TreeNode>();
			TreeNode cur = root;

			while (stack.Count > 0 || cur != null)
			{
				if (cur != null)
				{
					stack.Push(cur);
					cur = cur.left;
				}
				else
				{
					cur = stack.Pop();
					if (cur.val <= preVal)
						return false;
					preVal = cur.val;
					cur = cur.right;
				}
			}
			return true;
		}
	}

	public class Solution3
	{
		public bool IsValidBST(TreeNode root)
		{
			return IsBST(root).Value.Item1;
		}

		private (bool, long, long)? IsBST(TreeNode node)
		{
			if (node == null)
				return null;

			(bool, long, long)? left_res = IsBST(node.left);
			(bool, long, long)? right_res = IsBST(node.right);

			long min = node.val;
			long max = node.val;
			if (left_res != null)
			{
				min = Math.Min(min, left_res.Value.Item2);
				max = Math.Max(max, left_res.Value.Item3);
			}

			if (right_res != null)
			{
				min = Math.Min(min, right_res.Value.Item2);
				max = Math.Max(max, right_res.Value.Item3);
			}

			// 在左子树不为null的情况下，如果左子树不是BST或者当前节点不大于左子树的最大值，此树不为BST；右子树情况亦类似。
			return (left_res != null && (!left_res.Value.Item1 || node.val <= left_res.Value.Item3))
				|| (right_res != null && (!right_res.Value.Item1 || node.val >= right_res.Value.Item2))
				? (false, min, max) : (true, min, max);
		}
	}
}
