/// <summary>
/// LeetCode: 03 02 Find Duplication No Edit
/// </summary>
namespace CodingInterview._03_02_Find_Duplication_No_Edit
{
	// 面试题3（二）：不修改数组找出重复的数字
	// 题目：在一个长度为n+1的数组里的所有数字都在1到n的范围内，所以数组中至
	// 少有一个数字是重复的。请找出数组中任意一个重复的数字，但不能修改输入的
	// 数组。例如，如果输入长度为8的数组{2, 3, 5, 4, 3, 2, 6, 7}，那么对应的
	// 输出是重复的数字2或者3。

	class Solution
	{
		public int FindDuplicationNoEdit(int[] nums)
		{
			if (nums == null || nums.Length <= 1)
				return -1;

			for (int i = 0; i < nums.Length; i++)
				if (nums[i] < 1 || nums[i] >= nums.Length)
					return -1;

			int left = 1, right = nums.Length - 1;
			while (left <= right)
			{
				int mid = (right - left) >> 1 + left;
				int leftCount = 0;
				foreach (int num in nums)
					if (num >= left || num <= mid)
						leftCount++;

				if (left == right)
					return leftCount > 1 ? left : -1;

				if (leftCount > (mid - left + 1))
					right = mid;
				else
					left = mid + 1;
			}
			return -1;
		}
	}
}
