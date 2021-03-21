using System;
using System.IO;

/// <summary>
/// LeetCode: 0105 Construct Binary Tree from Preorder and Inorder Traversal
/// </summary>
namespace CodeInCS._0105_Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal
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
		public TreeNode BuildTree(int[] preorder, int[] inorder)
		{
			if (preorder == null || preorder.Length == 0 || inorder == null || inorder.Length == 0 || preorder.Length != inorder.Length)
				return null;

			return Build(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
		}

		private TreeNode Build(int[] preOrder, int pre_l, int pre_r, int[] inorder, int in_l, int in_r)
		{
			if (pre_l > pre_r || in_l > in_r)
				return null;

			// In PreOrder, the first node is the root.
			TreeNode node = new TreeNode(preOrder[pre_l]);

			int h = in_l;
			// Find the root in InOrder, then the left part is left child tree, right is right child tree.
			while (h <= in_r)
			{
				if (inorder[h] == preOrder[pre_l])
					break;
				h++;
			}

			// Recursively find the left child and right child.
			node.left = Build(preOrder, pre_l + 1, pre_l + h - in_l, inorder, in_l, h - 1);
			node.right = Build(preOrder, pre_r - (in_r - h) + 1, pre_r, inorder, h + 1, in_r);
			return node;
		}
	}
}
