using System;

/// <summary>
/// [题目]：
/// 小虎去附近的商店买苹果，奸诈的商贩使用了捆绑交易，只提供6个每袋和8个
/// 每袋的包装包装不可拆分。可是小虎现在只想购买恰好n个苹果，小虎想购买尽量少的袋数方便携带。
/// 如果不能购买恰好n个苹果，小虎将不会购买。输入一个整数n, 表示小虎想购买的个苹果，返回最小使用多少袋子。
/// 如果无论如何都不能正好装下，返回-1。
/// </summary>
namespace CodingInterview.Apple_In_Bags
{
	class AppleInBags
	{
		public static int MinBags(int apple)
		{
			if (apple < 0)
				return -1;

			int bag6 = -1;
			int bag8 = apple / 8;
			int restApples = apple - bag8 * 8;

			while (bag8 >= 0 && restApples < 24)
			{
				int restUseBag6 = MinBagBase6(restApples);
				if (restUseBag6 != -1)
				{
					bag6 = restUseBag6;
					break;
				}
				restApples = apple - (--bag8) * 8;
			}
			return bag6 == -1 ? -1 : bag8 + bag6;
		}

		private static int MinBagBase6(int rest)
		{
			return rest % 6 == 0 ? (rest / 6) : -1;
		}

		public static int GCD(int a, int b)
		{
			return b == 0 ? a : GCD(b, a % b);
		}

		public static int 最小公倍数(int a, int b)
		{
			return a * b / GCD(a, b);
		}

		/// <param name="apples">总的苹果数量</param>
		/// <param name="a">第一个袋子可以装多少个苹果</param>
		/// <param name="b">第二个袋子可以装多少个苹果</param>
		/// <returns></returns>
		public static int MinBags(int apples, int a, int b)
		{
			if (apples < 0)
				return -1;

			int bigBag = a > b ? a : b;
			int smallBag = bigBag == a ? b : a;
			int bigBagQty = apples / bigBag;
			int smallBagQty = -1;
			int restApples = apples - bigBag * bigBagQty;
			while (bigBagQty >= 0 && restApples < 最小公倍数(bigBag, smallBag))
			{
				int qty = MinQtyOfSmallBag(restApples, smallBag);
				if (qty != -1)
				{
					smallBagQty = qty;
					break;
				}
				restApples = apples - bigBag * (--bigBagQty);
			}
			return smallBagQty == -1 ? -1 : bigBagQty + smallBagQty;
		}

		private static int MinQtyOfSmallBag(int rest, int smallBag)
		{
			return rest % smallBag == 0 ? rest / smallBag : -1;
		}
	}
}
