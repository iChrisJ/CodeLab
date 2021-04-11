using System;

/// <summary>
/// Find Left Nearest Index in a Sorted Arrary of a specific value.
/// </summary>
namespace Common.Find_Left_Nearest_Index_In_Sorted_Array
{
	class Solution
	{
		public int LeftNearestIndex(int[] sortedArr, int num)
		{
			if (sortedArr == null || sortedArr.Length == 0)
				return -1;

			int left = 0, right = sortedArr.Length - 1;
			int res = -1;
			while (left <= right)
			{
				int mid = left + ((right - left) >> 1);
				if (sortedArr[mid] >= num)
				{
					res = mid;
					right = mid - 1;
				}
				else
					left = mid + 1;
			}
			return res;
		}
	}
}
