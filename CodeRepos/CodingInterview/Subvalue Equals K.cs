using System;
using System.Collections.Generic;

/// <summary>
/// [题目]:
/// 给定一个数组arr，求差值为k的去重数字对
/// </summary>
namespace CodingInterview.Subvalue_Equals_K
{
	class SubvalueEqualK
	{
		public static IList<(int, int)> SubvalueEqualsK(int[] arr, int k)
		{
			HashSet<int> set = new HashSet<int>(arr);
			IList<(int, int)> res = new List<(int, int)>();

			foreach (int cur in set)
				if (set.Contains(cur + k))
					res.Add((cur, cur + k));
			return res;
		}
	}
}
