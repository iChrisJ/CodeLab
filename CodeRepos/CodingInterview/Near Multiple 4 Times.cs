using System;

/// <summary>
/// [题目]：
/// 给定一个数组arr，如果通过调整可以做到arr中任意两个相邻的数字相乘是4的倍数，返回true；如果不能返回false
/// </summary>
namespace CodingInterview.Near_Multiple_4_Times
{
	class NearMultiple4Times
	{
		public static bool hasNearMulitple4Times(int[] arr)
		{
			int fourTime = 0;
			int evenExcept4Time = 0;
			int odd = 0;
			foreach (int item in arr)
			{
				if (item % 4 == 0)
					fourTime++;
				else if (item % 2 == 0)
					evenExcept4Time++;
				else
					odd++;
			}

			if (evenExcept4Time == 0)
				return fourTime >= odd - 1;
			else if (evenExcept4Time == 1)
				return fourTime > 0 && fourTime >= odd;
			else
				return fourTime >= odd;
		}
	}
}
