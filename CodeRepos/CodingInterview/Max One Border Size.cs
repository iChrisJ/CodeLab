using System;

/// <summary>
/// [题目]:
/// 给定一个N*N的矩阵matrix，只有0和1两种值，返回边框全是1的最大正方形的边长长度.
/// 例如:
///  0  1  1  1  1
///  0  1  0  0  1
///  0  1  0  0  1
///  0  1  1  1  1
///  0  1  0  1  1
///  其中边框全是1的最大正方形的大小为4 * 4，所以返回4
/// </summary>
namespace CodingInterview.Max_One_Border_Size
{
	class MaxOneBorderSize
	{
		public static int GetMaxSqureSize(int[,] matrix)
		{
			int N = matrix.GetLength(0);
			int M = matrix.GetLength(1);
			// 此数组的每个值记录当前点(包含当前点)的右边有多少个连续的1
			int[,] right = new int[N, M];
			// 此数组的每个值记录当前点(包含当前点)的下面有多少个连续的1
			int[,] down = new int[N, M];
			SetBorderMap(matrix, right, down);

			for (int size = Math.Min(N, M); size > 0; size--)
			{
				for (int i = 0; i < N - size + 1; i++)
				{
					for (int j = 0; j < M - size + 1; j++)
					{
						if (right[i, j] >= size && down[i, j] >= size && right[i + size - 1, j] >= size && down[i, j + size - 1] >= size)
							return size;
					}
				}
			}
			return 0;
		}

		private static void SetBorderMap(int[,] matrix, int[,] right, int[,] down)
		{
			int N = matrix.GetLength(0);
			int M = matrix.GetLength(1);

			for (int i = 0; i < N; i++)
				right[i, M - 1] = matrix[i, M - 1] == 1 ? 1 : 0;

			for (int j = 0; j < M; j++)
				down[N - 1, j] = matrix[N - 1, j] == 1 ? 1 : 0;

			for (int i = N - 2; i >= 0; i--)
				for (int j = M - 2; j >= 0; j--)
					if (matrix[i, j] == 1)
					{
						right[i, j] = right[i, j + 1] + 1;
						down[i, j] = down[i + 1, j] + 1;
					}
		}
	}
}
