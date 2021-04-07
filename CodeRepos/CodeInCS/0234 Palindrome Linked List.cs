using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0234 Palindrome Linked List
/// </summary>
namespace CodeInCS._0234_Palindrome_Linked_List
{
	// Definition for singly-linked list.
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int val = 0, ListNode next = null)
		{
			this.val = val;
			this.next = next;
		}
	}

	public class Solution
	{
		public bool IsPalindrome(ListNode head)
		{
			if (head == null)
				return true;

			Stack<ListNode> stack = new Stack<ListNode>();
			ListNode cur = head;
			while (cur != null)
			{
				stack.Push(cur);
				cur = cur.next;
			}

			cur = head;
			while (stack.Count > 0)
			{
				ListNode top = stack.Pop();
				if (top.val != cur.val)
					return false;

				cur = cur.next;
			}
			return true;
		}
	}

	public class Solution2
	{
		public bool IsPalindrome(ListNode head)
		{
			if (head == null)
				return true;

			ListNode slow = head, fast = head;
			while (fast.next != null && fast.next.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;
			}

			Stack<ListNode> stack = new Stack<ListNode>();
			while (slow.next != null)
			{
				stack.Push(slow.next);
				slow = slow.next;
			}

			fast = head;
			while (stack.Count > 0)
			{
				ListNode top = stack.Pop();
				if (top.val != fast.val)
					return false;
				fast = fast.next;
			}
			return true;
		}
	}

	public class Solution3
	{
		public bool IsPalindrome(ListNode head)
		{
			if (head == null)
				return true;

			ListNode slow = head, fast = head;
			while (fast.next != null && fast.next.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;
			}

			ListNode tail = ReverseList(slow.next, null);
			ListNode tailCur = tail;
			fast = head;
			while (tailCur != null)
			{
				if (fast.val != tailCur.val)
					return false;
				fast = fast.next;
				tailCur = tailCur.next;
			}

			// Revert the linked list to original
			tail = ReverseList(tail, null);
			slow.next = tail;
			return true;
		}

		// Reverse a Linked List.
		private ListNode ReverseList(ListNode node, ListNode prev)
		{
			if (node == null)
				return prev;
			ListNode next = node.next;
			node.next = prev;
			prev = node;
			return ReverseList(next, prev);
		}
	}
}
