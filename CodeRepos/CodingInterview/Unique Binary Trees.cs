using System;

/// <summary>
/// [题目]:
/// 给定一个非负整数n，代表二叉树的节点个数。返回能形成多少种不同的二叉树结构
/// </summary>
namespace CodingInterview.Unique_Binary_Trees
{
	class UniqueBinaryTrees
	{
		public static int NumTrees(int n)
		{
			if (n < 2)
				return 1;

			int res = 0;
			for (int i = 0; i <= n - 1; i++)
			{
				res += NumTrees(i) * NumTrees(n - 1 - i);
			}
			return res;
		}

		private static int NumTreesDP(int n)
		{
			int[] dp = new int[n + 1];
			dp[0] = 1;
			for (int i = 1; i < n + 1; i++)
				for (int j = 0; j < i; j++)
					dp[i] += dp[j] * dp[i - j - 1];

			return dp[n];
		}

		//public static void Main()
		//{
		//	int n = 10;
		//	for (int i = 1; i <= n; i++)
		//	{
		//		Console.WriteLine($"递归: {NumTrees(i)} - 动态规划: {NumTreesDP(i)}");
		//	}
		//	Console.ReadLine();
		//}
	}
}
