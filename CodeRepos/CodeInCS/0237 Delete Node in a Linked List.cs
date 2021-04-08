using System;

/// <summary>
/// LeetCode: 0237 Delete Node in a Linked List
/// </summary>
namespace CodeInCS._0237_Delete_Node_in_a_Linked_List
{

	// Definition for singly-linked list.
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	/// <summary>
	/// Actually it's not delete the original node, but the next one.
	/// In reality, if a node represents a server, deleting a non-specified node will cause a big problem.
	/// If there is no way to copy value from next node, this way is also not workable.
	/// Addtionally, there is no way to delete if the node is the tail node.
	/// Hence, there is no way to delete a node if the previous node is not given.
	/// </summary>
	public class Solution
	{
		public void DeleteNode(ListNode node)
		{
			if (node == null)
				return;

			if (node.next == null)
				throw new InvalidOperationException("The given node should not be in the tail.");

			ListNode next = node.next;
			node.val = next.val;
			node.next = next.next;
			next.next = null;
		}
	}
}
