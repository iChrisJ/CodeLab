using System;

/// <summary>
/// LeetCode: Longest Valid Parentheses
/// </summary>
namespace CodingInterview.Longest_Valid_Parentheses
{
	class LongestValidParentheses
	{
		public static int LongestValid(string s)
		{
			int[] dp = new int[s.Length];
			int max = 0;
			int pre = 0;

			for (int i = 1; i < s.Length; i++)
			{
				if (s[i] == ')')
				{
					pre = i - dp[i - 1] - 1;
					if (pre >= 0 && s[pre] == '(')
						dp[i] = dp[i - 1] + 2 + (pre - 1 >= 0 ? dp[pre - 1] : 0); //pre-1>0 is OK as well.
				}
				max = Math.Max(max, dp[i]);
			}
			return max;
		}
	}
}
