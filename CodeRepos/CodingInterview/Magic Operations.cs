using System;
using System.Collections.Generic;

/// <summary>
/// [题目]:
/// 给一个包含n个整数元素的集合a，一个包含m个整数元素的集合b。
/// 定义magic操作为，从一个集合中取出一个元素，放到另一个集合里，且操作过后每个集合的平均值都大于操作前。
/// 注意以下两点：
/// 1) 不可以把一个集合的元素取空，这样就没有平均值了
/// 2) 值为x的元素从集合b取出放入集合a，但集合a中已经有值为x的元素，则a的平均值不变（因为集合元素不会重复），b的平均值可能会改变（因为x被取出了）
/// 问最多可以进行多少次magic操作？
/// </summary>
namespace CodingInterview.Magic_Operations
{
	class MagicOperation
	{
		public static int MaxOps(int[] arr1, int[] arr2)
		{
			double sum1 = 0;
			Array.ForEach(arr1, e => sum1 += e);

			double sum2 = 0;
			Array.ForEach(arr2, e => sum2 += e);

			// 当两个数组的平均值是一样的时候,是不能有这样当移动,让两个数组的平均值都增加
			if (Average(sum1, arr1.Length) == Average(sum2, arr2.Length))
				return 0;

			// 当两个数组的平均值不一样,此时可以移动大数组中的大于小数组的平均值且小于大数组中平均值的数,这样两个数组的平均值都会增加
			// 当前给的数组是集合,说明数组中的数不能重复. 所以在移动的时候,确保移动的数在小数组中不存在.
			int[] bigArr = null, smallArr = null;
			double bigSum = sum1, smallSum = sum2;
			if (Average(sum1, arr1.Length) > Average(sum2, arr2.Length))
			{
				bigArr = arr1;
				smallArr = arr2;
			}
			else
			{
				bigArr = arr2;
				smallArr = arr1;
				bigSum = sum2;
				smallSum = sum1;
			}

			Array.Sort(bigArr);
			HashSet<int> set = new HashSet<int>(smallArr);

			int bigSize = bigArr.Length, smallSize = smallArr.Length;
			int ops = 0;

			foreach (int cur in bigArr)
			{
				if (cur > Average(smallSum, smallSize) && cur < Average(bigSum, bigSize) && !set.Contains(cur))
				{
					bigSum -= cur;
					bigSize--;
					smallSum += cur;
					smallSize++;
					set.Add(cur);
					ops++;
				}
			}

			return ops;
		}

		private static double Average(double sum, int length)
		{
			return sum / length;
		}

		public static void Main()
		{
			int[] arr1 = { 1, 2, 5 };
			int[] arr2 = { 2, 3, 4, 5, 6 };
			Console.WriteLine(MaxOps(arr1, arr2));
			Console.ReadKey();
		}
	}
}
