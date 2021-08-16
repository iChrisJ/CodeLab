using System;

/// <summary>
/// [题目]:
/// 用zigzag的方式打印矩阵，比如如下的矩阵
/// 0	1	2	3
/// 4	5	6	7
/// 8	9	10	11
/// 打印顺序为：0 1 4 8 5 2 3 6 9 10 7 11
/// </summary>
namespace CodingInterview.Zig_Zag_Print_Matrix
{
	class ZigZagPrintMatrix
	{
		// 假设有两个点A,B都是从(0,0)出发，A点向右出发，每次移动一步，到达最右边后向下移动；
		// B点向下出发，每次移动一步，到达最底端后向右移动。每次移动交替从A->B或者B->A方向
		// 打印矩阵中的点。
		public static void PrintMatrixZigZag(int[,] matrix)
		{
			int N = matrix.GetLength(0);
			int M = matrix.GetLength(1);
			int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
			bool isSlash = false;
			while (x1 < N && y2 < M)
			{
				PrintDiagonal(matrix, x1, y1, x2, y2, isSlash);
				x1 = y1 == M - 1 ? x1 + 1 : x1;
				y1 = y1 == M - 1 ? y1 : y1 + 1;
				y2 = x2 == N - 1 ? y2 + 1 : y2;
				x2 = x2 == N - 1 ? x2 : x2 + 1;
				isSlash = !isSlash;
			}
		}

		private static void PrintDiagonal(int[,] matrix, int x1, int y1, int x2, int y2, bool isSlash)
		{
			if (isSlash)
			{
				for (int i = x1, j = y1; i <= x2 && j >= y2; i++, j--)
					Console.Write($"{matrix[i, j]}\t");
			}
			else
			{
				for (int i = x2, j = y2; i >= x1 && j <= y1; i--, j++)
					Console.Write($"{matrix[i, j]}\t");
			}
		}

		//public static void Main()
		//{
		//	int[,] matrix =
		//	{
		//		{ 1, 2, 3, 4 },
		//		{ 5, 6, 7, 8 },
		//		{ 9, 10, 11, 12 }
		//	};
		//	PrintMatrixZigZag(matrix);
		//}
	}

}
