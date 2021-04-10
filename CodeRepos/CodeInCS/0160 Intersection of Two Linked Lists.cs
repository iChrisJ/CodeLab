using System;

/// <summary>
/// LeetCode: 0160 Intersection of Two Linked Lists
/// </summary>
namespace CodeInCS._0160_Intersection_of_Two_Linked_Lists
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

	public class Solution
	{
		public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
		{
			if (headA == null || headB == null)
				return null;

			ListNode cur1 = headA;
			ListNode cur2 = headB;

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
			cur1 = gap > 0 ? headA : headB; // cur1 points to the longer linked list.
			cur2 = cur1 == headA ? headB : headA; // cur2 points to the shorter linked list.

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
	}
}
