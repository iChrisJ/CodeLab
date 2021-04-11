using System;

/// <summary>
/// 一个数组中有两种数出现了奇数次，其他数都出现了偶数次，怎么找到并打印这两种数
/// </summary>
namespace Common.Two_Odd_Times_Values_In_Array
{
	class Solution
	{
		public (int, int) OddTimesNums(int[] arr)
		{
			int eor = 0;
			foreach (int item in arr)
				eor ^= item;

			// arr中,有两种数出现奇数次
			// eor = a^b 且 eor != 0
			// 则eor必然有一个位置上是1.
			int rightOne = eor & ((~eor) + 1); //获取eor上最右侧的1.
			int oneOdd = 0;
			foreach (int a in arr)
				if ((a & rightOne) != 0) //过滤出与rightOne相同位置上为1的数.
					oneOdd ^= a;

			return (oneOdd, eor ^ oneOdd);
		}
	}
}
