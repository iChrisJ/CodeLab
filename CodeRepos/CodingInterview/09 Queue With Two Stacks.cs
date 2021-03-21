using System;
using System.Collections.Generic;

/// <summary>
/// 剑指Offer: 09 Queue With Two Stacks
/// </summary>
namespace CodingInterview._09_Queue_With_Two_Stacks
{
	// 面试题9：用两个栈实现队列
	// 题目：用两个栈实现一个队列。队列的声明如下，请实现它的两个函数appendTail
	// 和deleteHead，分别完成在队列尾部插入结点和在队列头部删除结点的功能。

	public class CQueue
	{
		private Stack<int> in_stack;
		private Stack<int> out_stack;
		public CQueue()
		{
			in_stack = new Stack<int>();
			out_stack = new Stack<int>();
		}

		public void AppendTail(int value)
		{
			in_stack.Push(value);
		}

		public int DeleteHead()
		{
			if (out_stack.Count == 0)
				while (in_stack.Count > 0)
					out_stack.Push(in_stack.Pop());

			return out_stack.Count > 0 ? out_stack.Pop() : -1;
		}
	}
}
