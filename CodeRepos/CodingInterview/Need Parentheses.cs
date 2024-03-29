﻿using System;

/// <summary>
/// [题目]:
/// 一个完整的括号字符串定义规则如下:
/// ①空字符串是完整的。
/// ②如果s是完整的字符串，那么(s)也是完整的。
/// ③如果s和t是完整的字符串，将它们连接起来形成的st也是完整的。
/// 例如，"(()())", ""和 "(())()"是完整的括号字符串，"())(", "()(" 和 ")" 是不完整的括号字符串。
/// 小明有一个括号字符串s,现在需要在其中任意位置尽量少地添加括号,将其转化
/// 为一个完整的括号字符串。请问牛牛至少需要添加多少个括号。
/// </summary>
namespace CodingInterview.Need_Parentheses
{
	class NeedParentheses
	{
		public static int ParentheseNeed(string str)
		{
			if (str == null || str.Length == 0)
				return 0;

			int leftParentheseLeft = 0;
			int parentheseNeed = 0;
			foreach (char c in str)
			{
				if (c == '(')
					leftParentheseLeft++;
				else
					leftParentheseLeft--;

				if (leftParentheseLeft < 0)
				{
					parentheseNeed++;
					leftParentheseLeft = 0;
				}
			}
			return leftParentheseLeft + parentheseNeed;
		}
	}
}
