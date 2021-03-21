using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 剑指Offer: 06 Print List In Reversed Order
/// </summary>
namespace CodingInterview._06_Print_List_In_Reversed_Order
{
	// Definition for singly-linked list.
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	// 面试题6：从尾到头打印链表
	// 题目：输入一个链表的头结点，从尾到头反过来打印出每个结点的值。

	/// <summary>
	/// Recursively 
	/// </summary>
	public class Solution
	{
		public int[] ReversePrint(ListNode head)
		{
			List<int> res = new List<int>();
			if (head == null)
				return res.ToArray();

			ListNode node = head;
			Reverse(node, res);

			return res.ToArray();
		}

		private void Reverse(ListNode node, List<int> list)
		{
			if (node == null)
				return;
			Reverse(node.next, list);
			list.Add(node.val);
		}
	}

	/// <summary>
	/// With Stack
	/// </summary>
	public class Solution2
	{
		public int[] ReversePrint(ListNode head)
		{
			Stack<int> stack = new Stack<int>();
			if (head == null)
				return stack.ToArray();

			ListNode node = head;
			while (node != null)
			{
				stack.Push(node.val);
				node = node.next;
			}

			return stack.ToArray();
		}
	}
}
