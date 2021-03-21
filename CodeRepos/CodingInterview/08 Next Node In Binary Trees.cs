using System;

/// <summary>
/// 剑指Offer: 08 Next Node In Binary Trees
/// </summary>
namespace CodingInterview._08_Next_Node_In_Binary_Trees
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode parent;

		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null, TreeNode parent = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
			this.parent = parent;
		}
	}

	// 面试题8：二叉树的下一个结点
	// 题目：给定一棵二叉树和其中的一个结点，如何找出中序遍历顺序的下一个结点？
	// 树中的结点除了有两个分别指向左右子结点的指针以外，还有一个指向父结点的指针。

	class Solution
	{
		public TreeNode GetNext(TreeNode node)
		{
			if (node == null)
				return null;

			// When the right child is not empty, then find the leftest node of the right child tree.
			if (node.right != null)
			{
				TreeNode next = node.right;
				while (next.left != null)
					next = next.left;
				return next;
			}
			// When the right child is empty, but the parent is not, 
			// follow the parent line to find the ancestor that the node is in the ancestor's left child tree
			else if (node.parent != null)
			{
				TreeNode cur = node;
				TreeNode parent = node.parent;
				while (parent != null && cur == parent.right)
				{
					cur = parent;
					parent = parent.parent;
				}
				return parent;
			}
			return null;
		}
	}
}
