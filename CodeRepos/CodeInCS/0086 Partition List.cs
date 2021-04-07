using System;

/// <summary>
/// LeetCode: 0086 Partition List
/// </summary>
namespace CodeInCS._0086_Partition_List
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
		public ListNode Partition(ListNode head, int x)
		{
			ListNode lt_x = new ListNode();
			ListNode lt_cur = lt_x;
			ListNode ge_x = new ListNode();
			ListNode ge_cur = ge_x;
			while (head != null)
			{
				ListNode next = head.next;
				if (head.val < x)
				{
					lt_cur.next = head;
					lt_cur = lt_cur.next;
				}
				else // great than or equal to x.
				{
					ge_cur.next = head;
					ge_cur = ge_cur.next;
				}
				head.next = null;
				head = next;
			}

			if (ge_x == ge_cur)
				return lt_x.next;
			else if (lt_x == lt_cur)
				return ge_x.next;

			// less than x and great than or equal x linked lists are not empty.
			lt_cur.next = ge_x.next;
			return lt_x.next;
		}

		/// <summary>
		/// Generate a Linked List from an array.
		/// </summary>
		private static ListNode CreateLinkedListFromArray(int[] arr)
		{
			if (arr == null || arr.Length == 0)
				return null;

			ListNode preHead = new ListNode();
			ListNode cur = preHead;
			foreach (int item in arr)
			{
				cur.next = new ListNode(item);
				cur = cur.next;
			}

			return preHead.next;
		}

		//public static void Main()
		//{
		//	ListNode head = CreateLinkedListFromArray(new int[] { 1, 4, 3, 2, 5, 2 });
		//	ListNode res = new Solution().Partition(head, 3);
		//}
	}
}
