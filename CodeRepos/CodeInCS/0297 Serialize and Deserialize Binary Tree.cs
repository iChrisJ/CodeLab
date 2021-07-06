using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// LeetCode: 0297 Serialize and Deserialize Binary Tree
/// </summary>
namespace CodeInCS._0297_Serialize_and_Deserialize_Binary_Tree
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

	public class Codec_PreOrder
	{
		// Encodes a tree to a single string.
		public string serialize(TreeNode root)
		{
			StringBuilder tree = new StringBuilder();
			Serialize(root, tree);
			return tree.ToString(0, tree.Length - 1);
		}

		private void Serialize(TreeNode node, StringBuilder tree)
		{
			if (node == null)
			{
				tree.Append("#,");
				return;
			}

			tree.Append(node.val);
			tree.Append(',');
			Serialize(node.left, tree);
			Serialize(node.right, tree);
		}

		// Decodes your encoded data to tree.
		public TreeNode deserialize(string data)
		{
			string[] vals = data.Split(',');
			Queue<string> queue = new Queue<string>(vals);
			return Deserialize(queue);
		}

		private TreeNode Deserialize(Queue<string> queue)
		{
			string val = queue.Dequeue();
			if (val == "#")
				return null;

			TreeNode node = new TreeNode(int.Parse(val));
			node.left = Deserialize(queue);
			node.right = Deserialize(queue);
			return node;
		}
	}
}
