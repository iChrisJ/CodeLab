using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Quick_Sort
{
	public class Quick_Sort
	{
		public static void QuickSort(int[] arr)
		{
			if (arr == null || arr.Length < 2)
				return;

			//QuickSort(arr, 0, arr.Length - 1);
			QuickSort3Ways(arr, 0, arr.Length - 1);
		}

		private static void QuickSort(int[] arr, int left, int right)
		{
			if (left > right)
				return;

			//int pivotIndex = Partition(arr, left, right);
			int pivotIndex = Partition2Ways(arr, left, right);
			QuickSort(arr, left, pivotIndex - 1);
			QuickSort(arr, pivotIndex + 1, right);
		}

		/// <summary>
		/// Partition the array in one way
		/// </summary>
		private static int Partition(int[] arr, int left, int right)
		{
			int pivot = arr[left]; // 假设第一个值就是pivot
			int pos = left; // [left+1, pos] <= pivot, [pos+1, right]未操作区

			for (int i = left + 1; i <= right; i++) // 从第二个值开始向右遍历
			{ // 如果当前值大于pivot, 不做操作继续向前
				if (arr[i] <= pivot) // 如果当前值小于或等于pivot,则将当前值与pos下一位置上的值交换，pos++, 保持[left+1, pos] <= pivot.
				{
					int tmp = arr[i];
					arr[i] = arr[pos + 1];
					arr[pos + 1] = tmp;
					pos++;
				}
			}

			// 上面循环结束，将left位置上的pivot的值移到pos位置上
			// 则[left, pos-1] <= pivot, [pos+1, right] > pivot
			arr[left] = arr[pos];
			arr[pos] = pivot;
			return pos;
		}

		/// <summary>
		/// Partition the array in two ways
		/// </summary>
		private static int Partition2Ways(int[] arr, int left, int right)
		{
			int pivot = arr[left];
			int le = left + 1, gt = right; // [left+1, le) <= pivot,(gt, right] > pivot.

			while (le <= gt) // while true is OK as well.
			{
				// le坐标向右移动，当遇到右边界或者当前位置的值大于pivot停下，等待交换
				while (le <= right && arr[le] <= pivot)
					le++;
				// gt坐标向左移动，当遇到左边界或者当前位置的值小于等于pivot停下，等待交换
				while (gt >= left + 1 && arr[gt] > pivot)
					gt--;

				// 如果le>gt，说明le, gt已交错，无需操作；否则交换，le和gt各自向前方前进一步
				if (le > gt)
					break;

				int tmp = arr[le];
				arr[le] = arr[gt];
				arr[gt] = tmp;
				le++;
				gt--;
			}

			// 上面循环结束，将left位置上的pivot的值移到gt位置上(或者le-1)
			// 则[left, le-1) <= pivot, (gt, right] > pivot
			arr[left] = arr[gt];
			arr[gt] = pivot;

			return gt;
		}

		/// <summary>
		/// Partition the array in three ways
		/// </summary>
		private static void QuickSort3Ways(int[] arr, int left, int right)
		{
			if (left > right)
				return;

			int pivot = arr[left];
			int lt = left, gt = right, i = left + 1; // [left+1, lt] < pivot, [lt+1, i) == pivot, (gt, right] > pivot;
			while (i <= gt) // 当i没有超过gt, i向右移动
			{
				if (arr[i] < pivot) // 如果当前值小于pivot, 当前值与lt位置的下一位进行交换，i和lt都向右移动一位
				{
					int tmp = arr[i];
					arr[i] = arr[lt + 1];
					arr[lt + 1] = tmp;
					i++;
					lt++;
				}
				else if (arr[i] == pivot) // 如果当前值等于pivot, 不做操作，继续向右移动
					i++;
				else // 如果当前值大于pivot, 当前值与gt位置左侧下一位进行交换，之后gt向左移动一位，但是i位置不动，继续循环
				{
					int tmp = arr[i];
					arr[i] = arr[gt];
					arr[gt] = tmp;
					gt--;
				}
			}

			// 上面循环结束，将left位置上的pivot的值移到lt位置上(或者gt)
			// 则[left, lt) < pivot, [lt, gt] == pivot, (gt, right] > pivot;
			arr[left] = arr[lt];
			arr[lt] = pivot;

			QuickSort3Ways(arr, left, lt - 1);
			QuickSort3Ways(arr, i, right);
		}

		//public static void Main()
		//{
		//	Random random = new Random();
		//	int[] arr = new int[5000];
		//	for (int i = 0; i < arr.Length; i++)
		//	{
		//		arr[i] = random.Next(0, 1000);
		//		Console.Write($"{arr[i]}\t");
		//	}
		//	Console.WriteLine("\r\n");
		//	int[] arr_copied = new int[arr.Length];
		//	Array.Copy(arr, arr_copied, arr.Length);

		//	QuickSort(arr);
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
