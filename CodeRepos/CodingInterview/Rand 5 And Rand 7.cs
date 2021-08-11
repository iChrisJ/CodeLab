using System;

/// <summary>
/// [题目]:
/// 给定一个函数f，可以1～5的数字等概率返回一个。请加工出1～7的数字等概率返回一个的函数g。
/// 
/// 给定一个函数f，可以a～b的数字等概率返回一个。请加工出c～d的数字等概率返回一个的函数g。
/// 
/// 给定一个函数f，以p概率返回0，以1-p概率返回1。请加工出等概率返回0和1的函数g
/// </summary>
namespace CodingInterview.Rand_5_And_Rand_7
{
	class Rand5AndRand7
	{
		private static Random random = new Random();

		public static int RandTo5()
		{
			return random.Next(1, 6);
		}

		public static int Rand01()
		{
			int num = 0;
			do
			{
				num = RandTo5();
			} while (num == 3);

			return num > 3 ? 1 : 0;
		}

		public static int Rand17()
		{
			int num;
			do
			{
				num = (Rand01() >> 2) + (Rand01() >> 1) + Rand01();
			} while (num > 6);
			return num + 1;
		}

		private static int Rand01P()
		{
			double p = 0.83;
			return random.NextDouble() < p ? 0 : 1;
		}

		public static int Rand0To1P()
		{
			int num;
			do
			{
				num = Rand01P();
			} while (num == Rand01P());
			return num;
		}
	}
}
