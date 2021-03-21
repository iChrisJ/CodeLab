using System;

/// <summary>
/// LeetCode: 0074 Search a 2D Matrix
/// </summary>
namespace CodeInCS._0074_Search_a_2D_Matrix
{
	public class Solution
	{
		public bool SearchMatrix(int[][] matrix, int target)
		{
			if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
				return false;

			int left = 0, right = matrix.Length * matrix[0].Length - 1;
			while (left <= right)
			{
				int mid = ((right - left) >> 1) + left;
				int tmp = matrix[mid / matrix[0].Length][mid % matrix[0].Length];
				if (target < tmp)
					right = mid - 1;
				else if (target > tmp)
					left = mid + 1;
				else // target == tmp
					return true;
			}
			return false;
		}
	}
}
