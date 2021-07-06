using System;

/// <summary>
/// LeetCode: 0510 Inorder Successor in BST II
/// </summary>
namespace CodeInCS._0510_Inorder_Successor_in_BST_II
{
	/// <summary>
	/// Problem: Given a binary search tree and a node in it, find the in-order successor of that node in the BST.
	///		The successor of a node p is the node with the smallest key greater than p.val.
	///		You will have direct access to the node but not to the root of the tree.
	///		Each node will have a reference to its parent node.
	///		A node is defined as the following:
	/// </summary>

	// Definition for a binary tree node.
	public class Node
	{
		public int val;
		public Node left;
		public Node right;
		public Node parent;
		public Node(int val = 0, Node left = null, Node right = null, Node parent = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
			this.parent = parent;
		}
	}

	class Solution
	{
		public Node InorderSuccessor(Node p)
		{
			if (p == null)
				return null;

			Node cur = p;
			if (cur.right != null)
			{
				cur = cur.right;
				while (cur.left != null)
					cur = cur.left;
				return cur;
			}
			else
			{
				Node parent = cur.parent;
				while (parent != null && parent.left != cur)
				{
					cur = parent;
					parent = parent.parent;
				}
				return parent;
			}
		}
	}
}
