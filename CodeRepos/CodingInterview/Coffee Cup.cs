using System;

/// <summary>
/// [题目]：京东面试题
/// 数组arr：表示几个咖啡机，这几个咖啡机生产一杯咖啡所需要的时间就是数组中的值，例如arr=[2,3,7]就表示第一台咖啡机生产一杯咖啡需要2单位时间，第二台需要3单位时间，第三台需要7单位时间。
/// int N：表示有N个人需要用咖啡机制作咖啡，每人一杯，同时，假设制作完咖啡后，喝咖啡时间为0，一口闷。
/// int a：表示用洗碗机洗一个咖啡杯需要的时间，串行运行。
/// int b：表示咖啡杯也可以不洗，自然晾干的时间，咖啡杯要么洗，要么晾干。
/// 现在，请你求出这N个人从开始用咖啡杯制作咖啡到杯子洗好或者晾干的最少时间？
/// </summary>
namespace CodingInterview.Coffee_Cup
{
	class CoffeeCup
	{
		public static int MinTime(int[] arr, int a, int b)
		{
			if (arr == null || arr.Length == 0)
				return 0;

			MinHeap minHeap = new MinHeap(arr.Length);
			foreach (int t in arr)
				minHeap.Push((0, t));

			int[] drinkTimes = new int[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				(int, int) top = minHeap.Pop();
				drinkTimes[i] = top.Item1 + top.Item2;
				minHeap.Push((drinkTimes[i], top.Item2));
			}

			return Process(drinkTimes, a, b, 0, 0);
		}

		// drinkTimes 所有杯子可以开始洗的时间
		// wash 单杯洗干净的时间（串行）
		// air 挥发干净的时间(并行)
		// free 洗的机器什么时候可用
		// drinkTimes[index.....]都变干净，最早的结束时间（返回）
		private static int Process(int[] drinkTimes, int wash, int air, int index, int free)
		{
			if (index == drinkTimes.Length)
				return 0;

			int machineWashTime = Math.Max(drinkTimes[index], free) + wash;
			int restCleanTime = Process(drinkTimes, wash, air, index + 1, machineWashTime);
			int option1 = Math.Max(machineWashTime, restCleanTime);

			int selfCleanTime = drinkTimes[index] + air;
			int restCleanTime2 = Process(drinkTimes, wash, air, index + 1, selfCleanTime);
			int option2 = Math.Max(selfCleanTime, restCleanTime2);

			return Math.Min(option1, option2);
		}

		private static int BestTimeDP(int[] drinks, int wash, int air)
		{
			int maxFree = 0;
			for (int i = 0; i < drinks.Length; i++)
				maxFree = Math.Max(maxFree, drinks[i]) + wash;

			int[,] dp = new int[drinks.Length + 1, maxFree + 1];
			for (int index = drinks.Length - 1; index >= 0; index--)
			{
				for (int free = 0; free <= maxFree; free++)
				{
					int machineClean = Math.Max(drinks[index], free) + wash;
					if (machineClean > maxFree)
						break;
					int restClean1 = dp[index + 1, machineClean];
					int option1 = Math.Max(machineClean, restClean1);

					int selfClean = drinks[index] + air;
					int restClean2 = dp[index + 1, free];
					int option2 = Math.Max(selfClean, restClean2);
					dp[index, free] = Math.Min(option1, option2);
				}
			}
			return dp[0, 0];
		}

		class MinHeap
		{
			private (int, int)[] data;
			private int size;

			public bool IsFull
			{
				get
				{
					return size == data.Length;
				}
			}

			public bool IsEmpty
			{
				get
				{
					return size == 0;
				}
			}

			public MinHeap(int capacity)
			{
				data = new (int, int)[capacity];
			}

			public void Push((int, int) val)
			{
				if (IsFull)
					throw new InvalidOperationException("The heap is full");

				data[size] = val;
				ShiftUp(size);
				size++;
			}

			private int Compare((int, int) val1, (int, int) val2)
			{
				return (val1.Item1 + val1.Item2) - (val2.Item1 + val2.Item2);
			}

			private void Swap(int x, int y)
			{
				(int, int) tmp = data[x];
				data[x] = data[y];
				data[y] = tmp;
			}

			private void ShiftUp(int index)
			{
				while (index - 1 >= 0 && Compare(data[index], data[(index - 1) / 2]) < 0)
				{
					Swap(index, (index - 1) / 2);
					index = (index - 1) / 2;
				}
			}

			public (int, int) Pop()
			{
				(int, int) res = data[0];
				data[0] = data[size - 1];
				size--;
				ShiftDown(0);
				return res;
			}

			private void ShiftDown(int index)
			{
				while (index * 2 + 1 < size)
				{
					int childIndex = index * 2 + 1;
					if (childIndex + 1 < size && Compare(data[childIndex + 1], data[childIndex]) < 0)
						childIndex += 1;

					if (Compare(data[index], data[childIndex]) <= 0)
						return;

					Swap(index, childIndex);
					index = childIndex;
				}
			}
		}
	}
}
