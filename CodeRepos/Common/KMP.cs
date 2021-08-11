using System;

/// <summary>
/// LeetCode: KMP
/// </summary>
namespace Common.KMP
{
	class KMP
	{
		public static int IndexOf(string source, string value)
		{
			if (source == null || source.Length == 0 || value == null || value.Length == 0 || source.Length < value.Length)
				return -1;

			int[] next = NextArray(value); // O(M) m <= n;
			int i = 0, j = 0;

			while (i < source.Length && j < value.Length)
			{
				if (source[i] == value[j])
				{
					i++;
					j++;
				}
				else if (next[j] == -1) // j == 0
					i++;
				else
					j = next[j];
			}

			return j == value.Length ? i - j : -1;

		}

		private static int[] NextArray(string value)
		{
			if (value.Length == 1)
				return new int[] { -1 };

			int[] next = new int[value.Length];
			next[0] = -1;
			next[1] = 0;

			int i = 2;
			int cn = 0; //当前与i-1位置字符比较的位置
			while (i < next.Length)
			{
				if (value[i - 1] == value[cn])
				{
					next[i] = cn + 1;
					i++;
					cn++;
				}
				else if (cn > 0)
					cn = next[cn];
				else
				{
					next[i] = 0;
					i++;
				}
			}
			return next;
		}

		//public static string GetRandomString(int possibilities, int size)
		//{
		//	char[] ans = new char[new Random().Next(200) * size + 1];

		//	for (int i = 0; i < ans.Length; i++)
		//		ans[i] = (char)(new Random().Next(200) * possibilities + 'a');

		//	return ans.ToString();
		//}

		//public static void Main()
		//{
		//	int possibilities = 5;
		//	int strSize = 20;
		//	int matchSize = 5;
		//	int testTime = 5000;
		//	Console.WriteLine("Test Begins:");
		//	for (int i = 0; i < testTime; i++)
		//	{
		//		string str = GetRandomString(possibilities, strSize);
		//		string match = GetRandomString(possibilities, matchSize);
		//		if (IndexOf(str, match) != str.IndexOf(match))
		//			Console.WriteLine("Oops!");
		//	}
		//	Console.WriteLine("Test Finished.");
		//}
	}
}
