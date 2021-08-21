using System;
using System.Collections.Generic;

/// <summary>
/// [题目]：
/// 给定一个数组arr，已知其中所有的值都是非负的，将这个数组看作一个容器，请返回容器能装多少水
/// 比如，arr = {3, 1, 2, 5, 2, 4}，根据值画出的直方图就是容器形状，该容器可以装下5格水
/// 再比如，arr = {4. 5, 1, 3, 2}，该容器可以装下2格水
/// </summary>
namespace CodingInterview.Water_Problem
{
	class WaterProblem
	{
		// 双层遍历，遍历arr中1 -- n-1之间的没有数
		// 在i位置时，通过遍历获取i左右两边各自最大的数，则两边最大数中较小的一个则是当前
		// 位置能装水的上限
		public static int GetWater1(int[] arr)
		{
			if (arr == null || arr.Length < 3)
				return 0;

			int res = 0;
			for (int i = 1; i < arr.Length - 1; i++)
			{
				int leftMax = arr[0];
				for (int j = 1; j < i; j++)
					if (arr[j] > leftMax)
						leftMax = arr[j];

				int rightMax = arr[arr.Length - 1];
				for (int j = arr.Length - 2; j > i; j--)
					if (arr[j] > rightMax)
						rightMax = arr[j];

				int gap = Math.Min(leftMax, rightMax) - arr[i];
				res += gap > 0 ? gap : 0;
			}
			return res;
		}

		// 原理与上方法一样，只是通过数组预处理了每个位置上左右两边最大值
		public static int GetWater2(int[] arr)
		{
			if (arr == null || arr.Length < 3)
				return 0;

			int[] leftMax = new int[arr.Length];
			for (int i = 1; i < arr.Length; i++)
				leftMax[i] = Math.Max(leftMax[i - 1], arr[i - 1]);

			int[] rightMax = new int[arr.Length];
			for (int i = arr.Length - 2; i >= 0; i--)
				rightMax[i] = Math.Max(rightMax[i + 1], arr[i + 1]);

			int res = 0;
			for (int i = 1; i < arr.Length - 1; i++)
			{
				int gap = Math.Min(leftMax[i], rightMax[i]) - arr[i];
				res += gap > 0 ? gap : 0;
			}
			return res;
		}

		// 原理同上方法一样，只是将左侧预处理的最大值从数组改成变量保存
		public static int GetWater3(int[] arr)
		{
			if (arr == null || arr.Length < 3)
				return 0;

			int[] rightMax = new int[arr.Length];
			for (int i = arr.Length - 2; i >= 0; i--)
				rightMax[i] = Math.Max(rightMax[i + 1], arr[i + 1]);

			int res = 0;
			int leftMax = arr[0];
			for (int i = 1; i < arr.Length - 1; i++)
			{
				leftMax = Math.Max(arr[i - 1], leftMax);
				int gap = Math.Min(leftMax, rightMax[i]) - arr[i];
				res += gap > 0 ? gap : 0;
			}
			return res;
		}

		// 双指针
		public static int GetWater4(int[] arr)
		{
			if (arr == null || arr.Length < 3)
				return 0;

			int leftMax = arr[0], rightMax = arr[arr.Length - 1];
			int le = 1, ri = arr.Length - 2;

			int res = 0;
			while (le <= ri)
			{
				int gap = 0;
				if (leftMax <= rightMax)
				{
					gap = leftMax - arr[le];
					leftMax = Math.Max(leftMax, arr[le]);
					le++;
				}
				else
				{
					gap = rightMax - arr[ri];
					rightMax = Math.Max(rightMax, arr[ri]);
					ri--;
				}
				res += gap > 0 ? gap : 0;
			}
			return res;
		}

		//public static int[] GenerateRandomArray()
		//{
		//	int[] arr = new int[(new Random().Next(1, 99)) + 2];
		//	for (int i = 0; i < arr.Length; i++)
		//	{
		//		arr[i] = (int)(new Random().Next(1, 201)) + 2;
		//	}
		//	return arr;
		//}

		//public static void Main(String[] args)
		//{
		//	for (int i = 0; i < 10000; i++)
		//	{
		//		int[] arr = GenerateRandomArray();
		//		int r1 = GetWater1(arr);
		//		int r2 = GetWater2(arr);
		//		int r3 = GetWater3(arr);
		//		int r4 = GetWater4(arr);
		//		if (r1 != r2 || r3 != r4 || r1 != r3)
		//		{
		//			Console.WriteLine("What a fucking day! fuck that! man!");
		//		}
		//	}
		//}
	}
}
