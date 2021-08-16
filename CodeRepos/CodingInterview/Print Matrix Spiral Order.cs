using System;

/// <summary>
/// [题目]：
/// 用螺旋的方式打印矩阵，比如如下的矩阵
/// 0	1	2	3
/// 4	5	6	7
/// 8	9	10	11
/// 打印顺序为：0 1 2 3 7 11 10 9 8 4 5 6
/// </summary>
namespace CodingInterview.Print_Matrix_Spiral_Order
{
	class PrintMatrixSpiralOrder
	{
		public static void SpiralOrderPrint(int[,] matrix)
		{
			int N = matrix.GetLength(0);
			int M = matrix.GetLength(1);

			for (int x1 = 0, y1 = 0, x2 = N - 1, y2 = M - 1; x1 <= x2 && y1 <= y2; x1++, y1++, x2--, y2--)
				PrintEdge(matrix, x1, y1, x2, y2);
		}

		private static void PrintEdge(int[,] matrix, int x1, int y1, int x2, int y2)
		{
			if (x1 > x2 || y1 > y2)
				return;

			for (int i = y1; i < y2; i++)
				Console.Write($"{matrix[x1, i]} ");
			for (int i = x1; i < x2; i++)
				Console.Write($"{matrix[i, y2]} ");
			for (int i = y2; i > y1; i--)
				Console.Write($"{matrix[x2, i]} ");
			for (int i = x2; i > x1; i--)
				Console.Write($"{matrix[i, y1]} ");
		}

		//public static void Main()
		//{
		//	int[,] matrix = new int[,]
		//	{
		//		{ 1, 2, 3, 4 },
		//		{ 5, 6, 7, 8 },
		//		{ 9, 10, 11, 12 },
		//		{ 13, 14, 15, 16 },
		//		{ 17, 18, 19, 20 }
		//	};

		//	SpiralOrderPrint(matrix);
		//}
	}
}
