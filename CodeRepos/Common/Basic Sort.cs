using System;

/// <summary>
/// Basic Sort
/// </summary>
namespace Common.Basic_Sort
{
	class Solution
	{
		public static void SelectionSort(int[] arr)
		{
			if (arr == null || arr.Length < 2)
				return;

			for (int i = 0; i < arr.Length - 1; i++)
			{
				int min = i;
				for (int j = i + 1; j < arr.Length; j++)
					if (arr[j] < arr[min])
						min = j;

				int tmp = arr[i];
				arr[i] = arr[min];
				arr[min] = tmp;
			}
		}

		public static void BubbleSort(int[] arr)
		{
			if (arr == null || arr.Length < 2)
				return;

			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = 0; j < arr.Length - i - 1; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						int tmp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = tmp;
					}
				}
			}
		}

		public static void InsertionSort(int[] arr)
		{
			if (arr == null || arr.Length < 2)
				return;

			for (int i = 1; i < arr.Length; i++)
			{
				for (int j = i - 1; j >= 0; j--)
				{
					if (arr[j] > arr[j + 1])
					{
						int tmp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = tmp;
					}
				}

				/*------------- Improvement -------------*/
				//int cur = arr[i];
				//int j = i - 1;
				//for (; j >= 0; j--)
				//{
				//	if (arr[j] > cur)
				//		arr[j + 1] = arr[j];
				//	else
				//		break;
				//}
				//arr[j + 1] = cur;
			}
		}

		private static int[] GenerateRandomArray(int max, int min, int length)
		{
			if (max < min || length < 1)
				throw new ArgumentOutOfRangeException("minValue is greater than maxValue or length is less than 1.");

			int[] res = new int[length];
			Random random = new Random();

			for (int i = 0; i < length; i++)
				res[i] = random.Next(min, max);

			return res;
		}

		//public static void Main()
		//{
		//	int[] arr = GenerateRandomArray(100000, 0, 50000);
		//	int[] arr1 = new int[arr.Length];
		//	int[] arr2 = new int[arr.Length];
		//	Array.Copy(arr, arr1, arr.Length);
		//	Array.Copy(arr, arr2, arr.Length);

		//	SelectionSort(arr);
		//	BubbleSort(arr1);
		//	InsertionSort(arr2);

		//	for (int i = 0; i < arr.Length; i++)
		//		if (arr[i] != arr1[i] || arr[i] != arr2[i])
		//			throw new Exception($"arr: {arr[i]}, arr1: {arr1[i]}, arr2: {arr2[i]}");
		//	Console.WriteLine("Well Done.");
		//}
	}
}
