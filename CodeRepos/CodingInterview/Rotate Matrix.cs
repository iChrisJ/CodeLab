using System;

/// <summary>
/// [题目]：
/// 给定一个正方形矩阵，只用有限几个变量，实现矩阵中每个位置的数顺时针转动90度，比如如下的矩阵
/// 0	1	2	3
/// 4	5	6	7
/// 8	9	10	11
/// 12	13	14	15
/// 矩阵应该被调整为：
/// 12	8	4	0
/// 13	9	5	1
/// 14	10	6	2
/// 15	11	7	3
/// </summary>
namespace CodingInterview.Rotate_Matrix
{
	class RotateMatrix
	{
		public static void Rotate(int[,] matrix)
		{
			int N = matrix.GetLength(0);
			int M = matrix.GetLength(1);

			for (int x1 = 0, y1 = 0, x2 = N - 1, y2 = M - 1; x1 <= x2 && y1 <= y2; x1++, y1++, x2--, y2--)
				RotateEdge(matrix, x1, y1, x2, y2);
		}

		private static void RotateEdge(int[,] matrix, int x1, int y1, int x2, int y2)
		{
			if (x1 > x2 || y1 > y2)
				return;

			for (int i = 0; i < x2 - x1; i++)
			{
				int tmp = matrix[x1, y1 + i];
				matrix[x1, y1 + i] = matrix[x2 - i, y1];
				matrix[x2 - i, y1] = matrix[x2, y2 - i];
				matrix[x2, y2 - i] = matrix[x1 + i, y2];
				matrix[x1 + i, y2] = tmp;
			}
		}

		//private static void PrintMatrix(int[,] matrix)
		//{
		//	int N = matrix.GetLength(0);
		//	int M = matrix.GetLength(1);

		//	for (int i = 0; i < N; i++)
		//	{
		//		for (int j = 0; j < M; j++)
		//			Console.Write($"{matrix[i, j]}\t");
		//		Console.WriteLine();
		//	}
		//	Console.WriteLine();
		//}

		//public static void Main()
		//{
		//	int[,] matrix = new int[,]
		//	{
		//		{ 1, 2, 3, 4, 5},
		//		{ 6, 7, 8, 9, 10},
		//		{ 11, 12, 13, 14, 15},
		//		{ 16, 17, 18, 19, 20},
		//		{ 21, 22, 23, 24, 25}
		//	};
		//	PrintMatrix(matrix);
		//	Rotate(matrix);
		//	PrintMatrix(matrix);
		//}
	}
}
