using System;

/// <summary>
/// [题目]:
/// 假设s和m初始化，s = "a"; m = s;
/// 再定义两种操作，第一种操作：
/// m = s;
/// s = s + s;
/// 第二种操作：
/// s = s + m;
/// 求最小的操作步骤数，可以将s拼接到长度等于n
/// </summary>
namespace CodingInterview.Split_N_By_SM
{
	class SplitNBySM
	{
		// 如何判断一个数是不是质数
		public static bool IsPrim(int n)
		{
			if (n < 2)
				return false;

			int max = (int)Math.Sqrt((double)n);
			for (int i = 2; i <= max; i++)
				if (n % i == 0)
					return false;
			return true;
		}

		/// <summary>
		/// 将n拆解成质数的乘积
		/// </summary>
		/// <param name="n">请保证n不是质数</param>
		/// <returns>1. 所有质数因子的和, 但是因子不包含1; 2. 所有因子的个数, 但因子不包含1</returns>
		public static (int, int) DivsSumAndCount(int n)
		{
			int sum = 0;
			int count = 0;
			for (int i = 2; i <= n; i++)
			{
				while (n % i == 0)
				{
					sum += i;
					count++;
					n /= i;
				}
			}
			return (sum, count);
		}

		public static int MinOps(int n)
		{
			if (n < 2)
				return 0;

			if (IsPrim(n))
				return n - 1;

			(int, int) sum_count = DivsSumAndCount(n);
			return sum_count.Item1 - sum_count.Item2;
		}
	}
}
