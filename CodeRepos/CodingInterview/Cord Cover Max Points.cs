using System;

/// <summary>
/// [题目]：
///  给定一个有序数组arr,代表数轴上从左到右有n个点arr[0], arr[1]...arr[n-1]
///  给定一个正数L，代表一根长度为L的绳子，求绳子最多能覆盖其中的几个点。
/// </summary>
namespace CodingInterview.Cord_Cover_Max_Points
{
	class CordCoverMaxPoints
	{
		/// <summary>
		/// 将绳子的右端点依次与数组中的点对其，然后计算出绳子左右端点之前包含了多少数组中的点。
		/// 可以用二分查找找出数组中最左边大于绳子左端点的索引，然后计算出点数
		/// </summary>
		public static int MaxPoints(int[] arr, int L)
		{
			if (L <= 0)
				return 0;

			int res = 1;

			for (int i = 0; i < arr.Length; i++)
			{
				int index = NearestLeftIndex(arr, arr[i] - L, i);
				res = Math.Max(res, i - index + 1);
			}
			return res;
		}

		/// <summary>
		/// 二分查找找出数组中第一个大于绳子左端点的索引
		/// </summary>
		/// <param name="arr">The given array</param>
		/// <param name="value">The left value of the cord</param>
		/// <param name="r">The index of the arr which the right endpoint of the cord aligns to</param>
		private static int NearestLeftIndex(int[] arr, int value, int r)
		{
			int l = 0;
			int index = r;

			while (l < r)
			{
				int mid = l + ((r - l) >> 1);
				if (arr[mid] >= value)
				{
					index = mid;
					r = mid - 1;
				}
				else
					l = mid + 1;
			}
			return index;
		}

		//public static void Main()
		//{
		//	int[] arr = { 0, 13, 24, 35, 46, 57, 60, 72, 87 };
		//	int L = 15;
		//	Console.WriteLine(MaxPoints(arr, L));
		//}
	}
}
