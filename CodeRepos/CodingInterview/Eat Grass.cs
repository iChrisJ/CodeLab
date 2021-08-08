using System;

/// <summary>
/// [题目]：
/// 牛羊吃草,每次只可以吃4的指数次数量的草(eg:1, 4, 16, ...),谁先吧草吃完算谁赢
/// 现在有n份草,牛先吃,请问谁会先赢
/// </summary>
namespace CodingInterview.Eat_Grass
{
	class EatGrass
	{
		public static string Winner(int n)
		{
			//n:		0		1		2		3		4		5
			//winner:	Goat	Cow		Goat	Cow		Cow		Goat
			if (n < 5)
				return n == 0 || n == 2 ? "Goat" : "Cow";

			int _base = 1;
			while (_base <= n)
			{
				if (Winner(n - _base) == "Goat")
					return "Cow";
				if (_base > n / 4)
					break;
				_base *= 4;
			}
			return "Goat";
		}

		public static string Winner2(int n)
		{
			return n % 5 == 0 || n % 5 == 2 ? "Goat" : "Cow";
		}
	}
}
