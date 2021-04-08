using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0141 Linked List Cycle
/// </summary>
namespace CodeInCS._0141_Linked_List_Cycle
{
	// Definition for singly-linked list.
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x)
		{
			val = x;
			next = null;
		}
	}

	/// <summary>
	/// Impl w/ HashSet
	/// Space Complexity O(n)
	/// </summary>
	public class Solution
	{
		public bool HasCycle(ListNode head)
		{
			if (head == null)
				return false;

			HashSet<ListNode> set = new HashSet<ListNode>();
			while (head != null)
			{
				if (!set.Add(head))
					return true;
				head = head.next;
			}
			return false;
		}
	}

	/// <summary>
	/// Fast-Slow pointer
	/// Space Complexity O(1)
	/// </summary>
	public class Solution2
	{
		public bool HasCycle(ListNode head)
		{
			if (head == null)
				return false;

			ListNode slow = head, fast = head;
			while (fast.next != null && fast.next.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;
				if (slow == fast)
					return true;
			}
			return false;
		}
	}
}
