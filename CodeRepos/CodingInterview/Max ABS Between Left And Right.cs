using System;

/// <summary>
/// [题目]：
/// 给定一个数组arr长度为N，你可以把任意长度大于0且小于N的前缀作为左部分，剩下的作为右部分。
/// 但是每种划分下都有左部分的最大值和右部分的最大值，请返回最大的，
/// 左部分最大值减去右部分最大值的绝对值。
/// </summary>
namespace CodingInterview.Max_ABS_Between_Left_And_Right
{

	class MaxABSBetweenLeftRight
	{
		public static int MaxABS(int[] arr)
		{
			if (arr == null || arr.Length < 2)
				return 0;

			int max = arr[0];
			for (int i = 1; i < arr.Length; i++)
				max = Math.Max(max, arr[i]);

			return Math.Abs(max - Math.Min(arr[0], arr[arr.Length - 1]));
		}
	}
}
