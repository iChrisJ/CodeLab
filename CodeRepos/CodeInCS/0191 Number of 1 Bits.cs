using System;

/// <summary>
/// LeetCode: 0191 Number of 1 Bits
/// </summary>
namespace CodeInCS._0191_Number_of_1_Bits
{
	public class Solution
	{
		public int HammingWeight(uint n)
		{
			int count = 0;
			while (n != 0)
			{
				uint rightOne = n & ((~n) + 1);
				n ^= rightOne;
				count++;
			}
			return count;
		}

		//public static void Main()
		//{
		//	uint a = 11;
		//	int res = new Solution().HammingWeight(a);
		//}
	}
}
