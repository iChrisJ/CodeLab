using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0138 Copy List with Random Pointer
/// </summary>
namespace CodeInCS._0138_Copy_List_with_Random_Pointer
{
	// Definition for a Node.
	public class Node
	{
		public int val;
		public Node next;
		public Node random;

		public Node(int _val)
		{
			val = _val;
			next = null;
			random = null;
		}
	}

	/// <summary>
	/// Implment with HashTable.
	/// </summary>
	public class Solution
	{
		public Node CopyRandomList(Node head)
		{
			if (head == null)
				return null;

			Dictionary<Node, Node> dict = new Dictionary<Node, Node>();
			Node cur = head;
			while (cur != null)
			{
				dict.Add(cur, new Node(cur.val));
				cur = cur.next;
			}

			cur = head;
			while (cur != null)
			{
				dict[cur].next = cur.next == null ? null : dict[cur.next];
				dict[cur].random = cur.random == null ? null : dict[cur.random];
				cur = cur.next;
			}
			return dict[head];
		}
	}
	/// <summary>
	/// Duplicate nodes.
	/// </summary>
	public class Solution2
	{
		public Node CopyRandomList(Node head)
		{
			if (head == null)
				return null;

			Node cur = head;
			while (cur != null)
			{
				Node next = cur.next;
				cur.next = new Node(cur.val);
				cur.next.next = next;
				cur = cur.next.next;
			}

			cur = head;
			while (cur != null)
			{
				cur.next.random = cur.random != null ? cur.random.next : null;
				cur = cur.next.next;
			}

			cur = head;
			Node copied_head = new Node(-1);
			Node copied_prev = copied_head;
			while (cur != null)
			{
				Node copied = cur.next;
				copied_prev.next = copied;
				cur.next = copied.next;
				copied.next = null;
				cur = cur.next;
				copied_prev = copied_prev.next;
			}
			return copied_head.next;
		}
	}
}
