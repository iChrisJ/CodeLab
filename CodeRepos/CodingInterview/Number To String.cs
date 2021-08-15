using System;

/// <summary>
/// [题目]:
/// 将给定的数转换为字符串，原则如下：1对应 a，2对应b，…..26对应z，例如12258
/// 可以转换为 "abbeh", "aveh", "abyh", "lbeh" and "lyh"，个数为5，编写一个函
/// 数，给出可以转换的不同字符串的个数。
/// </summary>
namespace CodingInterview.Number_To_String
{
	class NumberToString
	{
		public static int ConvertWays(int num)
		{
			if (num <= 0)
				return 0;
			return Process(num.ToString(), 0);
		}

		private static int Process(string numStr, int index)
		{
			if (index == numStr.Length)
				return 1;

			if (numStr[index] == '0')
				return 0;

			int res = Process(numStr, index + 1);

			if (index + 1 < numStr.Length && ((numStr[index] - '0') * 10 + (numStr[index + 1] - '0') < 27))
				res += Process(numStr, index + 2);
			return res;
		}

		public static int DPWays(int num)
		{
			if (num <= 0)
				return 0;

			string numStr = num.ToString();
			int[] dp = new int[numStr.Length + 1];
			dp[numStr.Length] = 1;
			dp[numStr.Length - 1] = numStr[numStr.Length - 1] == '0' ? 0 : 1;
			for (int i = numStr.Length - 2; i >= 0; i--)
			{
				if (numStr[i] == '0')
					dp[i] = 0;
				else
					dp[i] = dp[i + 1] + (((numStr[i] - '0') * 10 + (numStr[i + 1] - '0') < 27) ? dp[i + 2] : 0);
			}
			return dp[0];
		}

		//public static void Main()
		//{
		//	int num = 111143311;
		//	Console.WriteLine($"递归: {ConvertWays(num)} - DP: {DPWays(num)}");
		//	Console.ReadLine();
		//}
	}
}
