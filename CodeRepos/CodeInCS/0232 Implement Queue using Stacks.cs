using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0232 Implement Queue using Stacks
/// </summary>
namespace CodeInCS._0232_Implement_Queue_using_Stacks
{
	public class MyQueue
	{
		private Stack<int> in_stack;
		private Stack<int> out_stack;

		public MyQueue()
		{
			in_stack = new Stack<int>();
			out_stack = new Stack<int>();
		}

		public void Push(int x)
		{
			in_stack.Push(x);
		}

		public int Pop()
		{
			if (out_stack.Count == 0)
				while (in_stack.Count > 0)
					out_stack.Push(in_stack.Pop());

			if (out_stack.Count > 0)
				return out_stack.Pop();
			else
				throw new InvalidOperationException("The queue is empty.");
		}

		public int Peek()
		{
			if (out_stack.Count == 0)
				while (in_stack.Count > 0)
					out_stack.Push(in_stack.Pop());

			if (out_stack.Count > 0)
				return out_stack.Peek();
			else
				throw new InvalidOperationException("The queue is empty.");
		}

		public bool Empty()
		{
			return in_stack.Count == 0 && out_stack.Count == 0;
		}
	}
}
