using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MaxHeap
{
	public class MaxHeap
	{
		private int[] data;
		private int capacity;
		private int size;

		public bool IsEmpty
		{
			get
			{
				return size == 0;
			}
		}

		public bool IsFull
		{
			get
			{
				return capacity == size;
			}
		}


		public MaxHeap(int capacity)
		{
			data = new int[capacity];
			this.capacity = capacity;
			size = 0;
		}

		public void Push(int value)
		{
			if (IsFull)
				throw new InvalidOperationException("The heap is full!");

			data[size] = value;
			size++;

			ShiftUp(size - 1);
		}

		private void ShiftUp(int index)
		{
			while (index > 0 && data[index] > data[(index - 1) / 2]) // 当index未到达根坐标，且当前元素大于其父元素，元素交换
			{
				int tmp = data[index];
				data[index] = data[(index - 1) / 2];
				data[(index - 1) / 2] = tmp;
				index = (index - 1) / 2;
			}
		}

		public int Peek()
		{
			if (IsEmpty)
				throw new InvalidOperationException("The heap is empty!");
			return data[0];
		}


		public int Pop()
		{
			if (IsEmpty)
				throw new InvalidOperationException("The heap is empty!");

			int res = data[0];
			data[0] = data[size - 1];
			size--;
			ShiftDown(0);
			return res;
		}

		private void ShiftDown(int index)
		{
			while (index * 2 + 1 <= size) // 当前元素有子节点
			{
				int childIndex = index * 2 + 1;
				if (childIndex + 1 <= size && data[childIndex] < data[childIndex + 1]) // 如果当前元素有右子节点，且右子节点大于左子节点
					childIndex += 1; // 将右子节点元素与父节点比较

				if (data[index] > data[childIndex]) // 如果父节点大于子节点，跳出循环
					return;

				int tmp = data[index];
				data[index] = data[childIndex];
				data[childIndex] = tmp;
				index = childIndex;
			}
		}
	}

	//public class Solution
	//{
	//	public static void Main()
	//	{
	//		int[] arr = new int[5000];
	//		int[] arr_copied = new int[arr.Length];
	//		Random random = new Random();

	//		for (int i = 0; i < arr.Length; i++)
	//		{
	//			arr[i] = random.Next(0, 10000);
	//			arr_copied[i] = arr[i];
	//		}

	//		MaxHeap heap = new MaxHeap(arr.Length);
	//		foreach (int item in arr)
	//			heap.Push(item);

	//		for (int i = arr.Length - 1; i >= 0; i--)
	//			arr[i] = heap.Pop();

	//		Array.Sort(arr_copied);

	//		for (int i = 0; i < arr.Length; i++)
	//		{
	//			if (arr[i] != arr_copied[i])
	//			{
	//				Console.WriteLine($"Two arrays are not same. i = {i}, arr[i] = {arr[i]}, arr_copied = {arr_copied[i]};");
	//				return;
	//			}
	//		}
	//		Console.WriteLine("Two arrays are same.");
	//	}
	//}
}
