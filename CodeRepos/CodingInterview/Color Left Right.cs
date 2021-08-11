using System;

/// <summary>
/// [题目]:
/// 小明有一些排成一行的正方形。每个正方形已经被染成红色或者绿色。小明现在可以选择任意一个正方形然后用这两种颜色的任意一种进行染色,
/// 这个正方形的颜色将会被覆盖。小明的目标是在完成染色之后, 每个红色R都比每个绿色G距离最左侧近。小明想知道他最少需要涂染几个正方形。
/// 如样例所示: s = RGRGR
/// 我们涂染之后变成RRRGG满足要求了,涂染的个数为2,没有比这个更好的涂染方案。
/// </summary>
namespace CodingInterview.Color_Left_Right
{
	class ColorLeftRight
	{
		public static int MinPaint(string s)
		{
			if (s == null || s.Length < 2)
				return 0;

			int[] right = new int[s.Length];
			right[s.Length - 1] = s[s.Length - 1] == 'R' ? 1 : 0;
			for (int i = s.Length - 2; i >= 0; i--)
				right[i] = right[i + 1] + (s[i] == 'R' ? 1 : 0);

			int res = right[0];
			int left = 0;
			for (int i = 0; i < s.Length - 1; i++)
			{
				left += s[i] == 'G' ? 1 : 0;
				res = Math.Min(res, left + right[i + 1]);
			}
			res = Math.Min(res, left + (s[s.Length - 1] == 'G' ? 1 : 0));
			return res;
		}
	}
}
