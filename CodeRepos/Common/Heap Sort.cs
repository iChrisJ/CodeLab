using System;

/// <summary>
/// Heap Sort
/// </summary>
namespace Common.Heap_Sort
{
	public class Heap_Sort
	{
		public static void HeapSort(int[] arr)
		{
			if (arr == null || arr.Length < 2)
				return;

			for (int i = (arr.Length - 1 - 1) / 2; i >= 0; i--)
				ShiftDown(arr, arr.Length, i);

			for (int i = arr.Length - 1; i >= 0; i--)
			{
				int tmp = arr[0];
				arr[0] = arr[i];
				arr[i] = tmp;
				ShiftDown(arr, i, 0);
			}
		}

		private static void ShiftDown(int[] arr, int shiftLength, int index)
		{
			int e = arr[index];

			while (index * 2 + 1 < shiftLength)
			{
				int childIndex = index * 2 + 1;
				if (childIndex + 1 < shiftLength && arr[childIndex + 1] > arr[childIndex])
					childIndex += 1;

				if (arr[childIndex] <= e)
					break;

				arr[index] = arr[childIndex];
				index = childIndex;
			}
			arr[index] = e;
		}

		//public static void Main() 
		//{
		//	Random random = new Random();
		//	int[] arr = new int[5000];
		//	for (int i = 0; i < arr.Length; i++)
		//	{
		//		arr[i] = random.Next(0, 10000);
		//		Console.Write($"{arr[i]}\t");
		//	}
		//	Console.WriteLine("\r\n");
		//	int[] arr_copied = new int[arr.Length];
		//	Array.Copy(arr, arr_copied, arr.Length);


		//	HeapSort(arr);
		//	Array.Sort(arr_copied);
		//	for (int i = 0; i < arr.Length; i++)
		//	{
		//		if (arr[i] != arr_copied[i])
		//		{
		//			Console.WriteLine($"Two arrays are not same. i = {i}, arr[i] = {arr[i]}, arr_copied = {arr_copied[i]};");
		//			return;
		//		}
		//	}
		//	Console.WriteLine("Two arrays are same.");
		//}
	}
}
