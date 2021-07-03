using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0958 Check Completeness of a Binary Tree
/// </summary>
namespace CodeInCS._0958_Check_Completeness_of_a_Binary_Tree
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
		public bool IsCompleteTree(TreeNode root)
		{
			if (root == null)
				return true;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			bool findNoRightChild = false;
			// 1) 当一个节点只有右孩子没有左孩子，返回false
			// 2) 在条1)满足的情况下，在遇到节点只有左孩子没有右孩子或者左右孩子都为null, 那么这个节点之前的所有节点都有左右孩子，
			// 之后的节点都没有左右孩子
			while (queue.Count > 0)
			{
				TreeNode front = queue.Dequeue();
				if ((front.left == null && front.right != null) || (findNoRightChild && (front.left != null || front.right != null)))
					return false;

				if (!findNoRightChild && front.right == null)
					findNoRightChild = true;

				if (front.left != null)
					queue.Enqueue(front.left);
				if (front.right != null)
					queue.Enqueue(front.right);
			}
			return true;
		}
	}
}
