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
}
