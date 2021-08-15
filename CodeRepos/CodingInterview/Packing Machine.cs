using System;

/// <summary>
/// [题目]：
/// 有n个打包机器从左到右一字排开，上方有一个自动装置会抓取一批放物品到每个打包机上，放到每个机器上的这些物品数量有多有少，
/// 由于物品数量不相同，需要工人将每个机器上的物品进行移动从而到达物品数量相等才能打包。每个物品重量太大、每次只能搬一个物品进行移动，
/// 为了省力，只在相邻的机器上移动。请计算在搬动最小轮数的前提下，使每个机器上的物品数量相等。如果不能使每个机器上的物品相同，返回-1。
/// 
/// 例如[1,0,5] 表示有3个机器，每个机器上分别有1、0、5个物品，经过这些轮后：
/// 第一轮：1 0 < -5 => 1 1 4 
/// 第二轮：1 < -1 < -4 => 2 1 3 
/// 第三轮：2 1 < -3 => 2 2 2
/// 移动了3轮，每个机器上的物品相等，所以返回3
/// 例如[2, 2, 3]表示有3个机器，每个机器上分别有2、2、3个物品，
/// 这些物品不管怎么移动，都不能使三个机器上物品数量相等，返回-1
/// LeetCode: https://leetcode-cn.com/problems/super-washing-machines
/// </summary>
namespace CodingInterview.Packing_Machine
{
	class PackingMachine
	{
		public static int MinOps(int[] arr)
		{
			if (arr == null || arr.Length == 0)
				return -1;

			int sum = 0;
			foreach (int item in arr)
				sum += item;

			if (sum % arr.Length != 0)
				return -1;

			int avg = sum / arr.Length;
			int leftSum = 0;
			int res = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				int leftRest = avg * i - leftSum;
				int rightRest = (arr.Length - i - 1) * avg - (sum - arr[i] - leftSum);

				if (leftRest > 0 && rightRest > 0)
					res = Math.Max(res, leftRest + rightRest);
				else
					res = Math.Max(res, Math.Max(Math.Abs(leftRest), Math.Abs(rightRest)));

				leftSum += arr[i];
			}
			return res;
		}
	}
}
