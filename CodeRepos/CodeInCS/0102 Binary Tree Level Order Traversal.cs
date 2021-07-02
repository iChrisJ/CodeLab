using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0102 Binary Tree Level Order Traversal
/// </summary>
namespace CodeInCS._0102_Binary_Tree_Level_Order_Traversal
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
		public IList<IList<int>> LevelOrder(TreeNode root)
		{
			IList<IList<int>> res = new List<IList<int>>();
			if (root == null)
				return res;
			LevelOrder(root, 1, res);
			return res;
		}

		private void LevelOrder(TreeNode node, int level, IList<IList<int>> res)
		{
			if (res.Count < level)
				res.Add(new List<int>());

			res[level - 1].Add(node.val);
			if (node.left != null)
				LevelOrder(node.left, level + 1, res);
			if (node.right != null)
				LevelOrder(node.right, level + 1, res);
		}
	}

	public class Solution2
	{
		public IList<IList<int>> LevelOrder(TreeNode root)
		{
			IList<IList<int>> res = new List<IList<int>>();
			if (root == null)
				return res;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			while (queue.Count > 0)
			{
				int levelCount = queue.Count;
				IList<int> levelList = new List<int>();
				while (levelCount > 0)
				{
					TreeNode front = queue.Dequeue();
					if (front.left != null)
						queue.Enqueue(front.left);
					if (front.right != null)
						queue.Enqueue(front.right);
					levelList.Add(front.val);
					levelCount--;
				}
				res.Add(levelList);
			}
			return res;
		}
	}
}
