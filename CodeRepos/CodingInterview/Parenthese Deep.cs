using System;

/// <summary>
/// 一个合法的括号匹配序列有以下定义:
/// ①空串 ""是一个合法的括号匹配序列
/// ②如果 "X"和 "Y"都是合法的括号匹配序列,"XY"也是一个合法的括号匹配序列
/// ③如果 "X"是一个合法的括号匹配序列,那么 "(X)"也是一个合法的括号匹配序列
/// ④每个合法的括号序列都可以由以上规则生成.
/// 例如: "","()","()()","((()))"都是合法的括号序列
/// 对于一个合法的括号序列我们又有以下定义它的深度:
/// ①空串 ""的深度是0
/// ②如果字符串 "X"的深度是x,字符串 "Y"的深度是y,那么字符串 "XY"的深度为
///   max(x, y) 3、如果 "X"的深度是x,那么字符串 "(X)"的深度是x + 1
/// 例如: "()()()"的深度是1,"((()))"的深度是3。牛牛现在给你一个合法的括号序列, 需要你计算出其深度。
/// </summary>
namespace CodingInterview.Parenthese_Deep
{
	class ParentheseDeep
	{
		public static int Deep(string s)
		{
			int curDeep = 0;
			int maxDeep = 0;

			foreach (char c in s)
			{
				if (c == '(')
				{
					curDeep++;
					maxDeep = Math.Max(maxDeep, curDeep);
				}
				else
					curDeep--;
			}

			return maxDeep;
		}
	}
}
