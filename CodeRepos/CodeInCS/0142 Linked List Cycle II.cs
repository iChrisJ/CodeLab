using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0142 Linked List Cycle II
/// </summary>
namespace CodeInCS._0142_Linked_List_Cycle_II
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
	/// Impl with HashSet
	/// </summary>
	public class Solution
	{
		public ListNode DetectCycle(ListNode head)
		{
			if (head == null)
				return null;

			HashSet<ListNode> set = new HashSet<ListNode>();
			while (head != null)
			{
				if (!set.Add(head))
					return head;
				head = head.next;
			}
			return null;
		}
	}

	/// <summary>
	/// Fast-Slow Pointers
	/// </summary>
	public class Solution2
	{
		public ListNode DetectCycle(ListNode head)
		{
			if (head == null)
				return null;

			ListNode slow = head, fast = head;
			while (fast.next != null && fast.next.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;
				if (slow == fast)
					break;
			}

			if (fast.next == null || fast.next.next == null)
				return null;

			fast = head;
			while (slow != fast)
			{
				slow = slow.next;
				fast = fast.next;
			}
			return slow;
		}
	}
}