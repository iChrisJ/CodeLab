using System;
using System.Collections.Generic;

/// <summary>
/// [题目]:
/// 请编写一个程序，对一个栈里的整型数据，按升序进行排序（即排序前，栈里
/// 的数据是无序的，排序后最大元素位于栈顶），要求最多只能使用一个额外的
/// 栈存放临时数据，但不得将元素复制到别的数据结构中。
/// </summary>
namespace CodingInterview.Stack_Sort_Stack
{
	class StackSortStack
	{
		public static void SortStackByStack(Stack<int> stack)
		{
			if (stack == null || stack.Count <= 1)
				return;

			Stack<int> aux = new Stack<int>();
			while (stack.Count > 0)
			{
				int top = stack.Pop();

				while (aux.Count > 0 && aux.Peek() < top)
					stack.Push(aux.Pop());

				aux.Push(top);
			}

			while (aux.Count > 0)
				stack.Push(aux.Pop());
		}
	}
}
