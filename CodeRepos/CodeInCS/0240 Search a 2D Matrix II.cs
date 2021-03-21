using System;

/// <summary>
/// LeetCode: 0240 Search a 2D Matrix II
/// </summary>
namespace CodeInCS._0240_Search_a_2D_Matrix_II
{
	public class Solution
	{
		public bool SearchMatrix(int[][] matrix, int target)
		{
			if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
				return false;

			int n = matrix.Length, m = matrix[0].Length;
			int row = 0, col = m - 1;
			while (row < n && col >= 0)
			{
				if (target < matrix[row][col])
					col--;
				else if (target > matrix[row][col])
					row++;
				else //target == matrix[row][col]
					return true;
			}
			return false;
		}
	}
}
