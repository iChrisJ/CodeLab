using System;

/// <summary>
/// Get local minimum of an array
/// </summary>
namespace Common.Local_Minimum
{
	class Solution
	{
		public int GetLocalMinimum(int[] arr)
		{
			if (arr == null || arr.Length == 0)
				return -1; // not exists.

			if (arr.Length == 1 || arr[0] < arr[1])
				return 0;
			if (arr[arr.Length - 1] < arr[arr.Length - 2])
				return arr.Length - 1;

			int left = 1, right = arr.Length - 2;
			while (left < right)
			{
				int mid = left + (right - left) >> 2;
				if (arr[mid] > arr[mid - 1])
					right = mid - 1;
				else if (arr[mid] > arr[mid + 1])
					left = mid + 1;
				else
					return mid;
			}
			return left;
		}
	}
}
