using System;

/// <summary>
/// Merge Sort
/// </summary>
namespace Common.Merge_Sort
{
	public class Merge_Sort
	{
		public static void MergeSort(int[] arr)
		{
			if (arr == null || arr.Length < 2)
				return;

			MergeSort(arr, 0, arr.Length - 1);
		}

		private static void MergeSort(int[] arr, int left, int right)
		{
			if (left >= right)
				return;

			int mid = left + ((right - left) >> 1);
			MergeSort(arr, left, mid);
			MergeSort(arr, mid + 1, right);

			if (arr[mid] > arr[mid + 1]) // 因为左右俩部分的数组都排完序，如果arr[mid] <= arr[mid + 1],则说明整段数组都是排好序的。
				Merge(arr, left, mid, right);
		}

		/// <summary>
		/// Merge two sorted parts.
		/// </summary>
		private static void Merge(int[] arr, int left, int mid, int right)
		{
			int[] aux = new int[right - left + 1]; // 辅助数组

			int l = left, r = mid + 1, i = 0;
			while (i < aux.Length)
			{
				if (l > mid) // 当左半边元素已经全部处理完毕，则将右半边剩余元素逐个放入辅助数组中
				{
					aux[i] = arr[r];
					r++;
				}
				else if (r > right) // 当右半边元素已经全部处理完毕，则将左半边剩余元素逐个放入辅助数组中
				{
					aux[i] = arr[l];
					l++;
				}
				else if (arr[l] <= arr[r]) // 如果左边元素小于等于右边元素，则将左侧元素放入辅助数组中
				{
					aux[i] = arr[l];
					l++;
				}
				else // 如果左边元素大于等于右边元素，则将右侧元素放入辅助数组中
				{
					aux[i] = arr[r];
					r++;
				}
				i++;
			}

			// 将辅助数组中已排序的元素放回原数组
			for (int j = 0; j < aux.Length; j++)
				arr[j + left] = aux[j];
		}

		/// <summary>
		/// Bottom up merge sort.
		/// </summary>
		public static void MergeSortBottomUp(int[] arr)
		{
			if (arr == null || arr.Length < 2)
				return;

			for (int sz = 1; sz < arr.Length; sz *= 2)
				for (int i = 0; i < arr.Length - sz; i += sz + sz)
					if (arr[i + sz - 1] > arr[i + sz])
						Merge(arr, i, i + sz - 1, Math.Min(i + 2 * sz - 1, arr.Length - 1));
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

		//	//MergeSort(arr);
		//	MergeSortBottomUp(arr);
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
