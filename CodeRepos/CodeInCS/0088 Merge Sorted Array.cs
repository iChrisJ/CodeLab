using System;

/// <summary>
/// LeetCode: 0088 Merge Sorted Array
/// </summary>
namespace CodeInCS._0088_Merge_Sorted_Array
{
	public class Solution
	{
		public void Merge(int[] nums1, int m, int[] nums2, int n)
		{
			if (nums1 == null || nums2 == null || nums1.Length != m + n || nums2.Length != n)
				return;

			int i = m - 1, j = n - 1, k = m + n - 1;
			while (j >= 0)
			{
				if (i < 0 || nums1[i] <= nums2[j])
				{
					nums1[k] = nums2[j];
					j--;
				}
				else // i >= 0 && nums1[i] > nums2[j]
				{
					nums1[k] = nums1[i];
					i--;
				}
				k--;
			}
		}
	}
}
