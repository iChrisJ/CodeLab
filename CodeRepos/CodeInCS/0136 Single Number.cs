using System;

/// <summary>
/// LeetCode: 0136 Single Number
/// </summary>
namespace CodeInCS._0136_Single_Number
{
	public class Solution
	{
		public int SingleNumber(int[] nums)
		{
			int res = 0;
			foreach (int num in nums)
				res ^= num;
			return res;
		}
	}
}
