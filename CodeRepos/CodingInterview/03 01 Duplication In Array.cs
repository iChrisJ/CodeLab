using System;
using System.Collections.Generic;

/// <summary>
/// 剑指Offer: 03 01 Duplication In Array
/// </summary>
namespace CodingInterview._03_01_Duplication_In_Array
{
	// 面试题3（一）：找出数组中重复的数字
	// 题目：在一个长度为n的数组里的所有数字都在0到n-1的范围内。数组中某些数字是重复的，但不知道有几个数字重复了，
	// 也不知道每个数字重复了几次。请找出数组中任意一个重复的数字。例如，如果输入长度为7的数组{2, 3, 1, 0, 2, 5, 3}，
	// 那么对应的输出是重复的数字2或者3。

	class Solution
	{
		public int FindRepeatNumber(int[] nums)
		{
			if (nums == null || nums.Length <= 1)
				return -1;

			for (int i = 0; i < nums.Length; i++)
				if (nums[i] < 0 || nums[i] >= nums.Length)
					return -1;

			int j = 0;
			while (j < nums.Length)
			{
				if (nums[j] == j)
					j++;
				else if (nums[nums[j]] == nums[j])
					return nums[j];
				else if (nums[nums[j]] != nums[j])
				{
					int tmp = nums[j];
					nums[j] = nums[tmp];
					nums[tmp] = tmp;
				}
			}
			return -1;
		}
	}
}
