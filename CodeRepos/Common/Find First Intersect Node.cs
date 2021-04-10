using System;

namespace Common.Find_First_Intersect_Node
{
	/// <summary>
	/// Problem:
	/// - 给定两个可能有环可能无环的单链表，头节点head1和head2.
	/// - 请实现一个函数，如果两个链表相交，请返回相交的第一个节点。如果不相交，返回null。
	/// 【要求】
	/// - 如果两个链表长度之和位N，时间复杂度请达到O(N)，额外空间复杂度请达到O(1)。
	/// </summary>
	class Solution
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

		public ListNode GetIntersectNode(ListNode head1, ListNode head2)
		{
			if (head1 == null || head2 == null)
				return null;

			ListNode loop1 = GetLoopNode(head1);
			ListNode loop2 = GetLoopNode(head2);

			if (loop1 == null && loop2 == null)
				return FindFirstIntersectNodeIfNoLoop(head1, head2);
			else if (loop1 != null && loop2 != null)
				return FindFirstIntersectNodeIfBothLoop(head1, loop1, head2, loop2);
			return null;
		}

		/// <summary>
		/// Find the first node of the cycle. If no cycle, return null.
		/// </summary>
		private ListNode GetLoopNode(ListNode head)
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
			while (fast != slow)
			{
				fast = fast.next;
				slow = slow.next;
			}
			return fast;
		}

		/// <summary>
		/// Find the first intersect node if two linked lists don't have cycles. If no intersection, return null.
		/// </summary>
		private ListNode FindFirstIntersectNodeIfNoLoop(ListNode head1, ListNode head2)
		{
			if (head1 == null || head2 == null)
				return null;

			ListNode cur1 = head1;
			ListNode cur2 = head2;

			int gap = 0;
			while (cur1.next != null)
			{
				gap++;
				cur1 = cur1.next;
			}

			while (cur2.next != null)
			{
				gap--;
				cur2 = cur2.next;
			}

			if (cur1 != cur2)
				return null;

			// gap: it means the length difference between two linked lists.
			cur1 = gap > 0 ? head1 : head2; // cur1 points to the longer linked list.
			cur2 = cur1 == head1 ? head2 : head1; // cur2 points to the shorter linked list.

			gap = Math.Abs(gap);
			while (gap != 0)
			{
				gap--;
				cur1 = cur1.next;
			}

			while (cur1 != cur2)
			{
				cur1 = cur1.next;
				cur2 = cur2.next;
			}
			return cur1;
		}


		/// <summary>
		/// If both linked lists have cycles, find the first intersect node. If no intersection, return null.
		/// </summary>
		private ListNode FindFirstIntersectNodeIfBothLoop(ListNode head1, ListNode loop1, ListNode head2, ListNode loop2)
		{
			if (loop1 == loop2)
			{
				ListNode cur1 = head1;
				ListNode cur2 = head2;

				int gap = 0;
				while (cur1.next != loop1)
				{
					gap++;
					cur1 = cur1.next;
				}

				while (cur2.next != loop2)
				{
					gap--;
					cur2 = cur2.next;
				}

				cur1 = gap > 0 ? head1 : head2; // cur1 points to the longer linked list.
				cur2 = cur1 == head1 ? head2 : head1; // cur2 points to the shorter linked list.

				gap = Math.Abs(gap);
				while (gap != 0)
				{
					gap--;
					cur1 = cur1.next;
				}

				while (cur1 != cur2)
				{
					cur1 = cur1.next;
					cur2 = cur2.next;
				}
				return cur1;
			}
			else
			{
				ListNode cur = loop1.next;
				while (cur != loop1)
				{
					if (cur == loop2)
						return loop1;
					cur = cur.next;
				}
				return null;
			}
		}
	}
}
