using System;

/// <summary>
/// LeetCode: 0285 Inorder Successor in BST
/// </summary>
namespace CodeInCS._0285_Inorder_Successor_in_BST
{
	// Problem: Given a binary search tree and a node in it, find the in-order successor of that node in the BST.
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

	class Solution
	{
		// 1) 如果p节点有右子树, p的后继节点就是p右子树最左节点
		// 2) 如果p节点没有右子树, 沿p节点的父节点向上查找, 如果当前节点不是其父节点的左子节点,继续向上查找
		//	直到当前节点是其父节点的左节点, 则其父节点就是p节点的后继节点.
		public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
		{
			if (root == null || p == null)
				return null;

			TreeNode next = null;
			TreeNode cur = root;
			while (cur != null && cur.val != p.val)
			{
				if (cur.val > p.val)
				{
					next = cur;
					cur = cur.left;
				}
				else
					cur = cur.right;
			}

			if (cur == null)
				return null;

			if (cur.right == null)
				return next;

			cur = cur.right;
			while (cur.left != null)
				cur = cur.left;
			return cur;
		}

	}
}
