using System;
using System.Collections.Generic;

/// <summary>
/// 设计RandomPool结构
///【题目】
///  设计一种结构，在该结构中有如下三个功能：
///    insert(key):将某个key加入到该结构，做到不重复加入
///    delete(key):将原本在结构中的某个key移除
///    getRandom():等概率随机返回结构中的任何一个key。
///【要求】
///  Insert、delete和getRandom方法的时间复杂度都是0(1)
/// </summary>
namespace CodingInterview.Random_Pool
{
	class RandomPool<T>
	{
		private IDictionary<T, int> keyIndexDict;
		private IDictionary<int, T> indexKeyDict;
		private int size;

		public RandomPool()
		{
			keyIndexDict = new Dictionary<T, int>();
			indexKeyDict = new Dictionary<int, T>();
		}

		public void Insert(T key)
		{
			if (keyIndexDict.ContainsKey(key))
				return;

			keyIndexDict.Add(key, size);
			indexKeyDict.Add(size, key);
			size++;
		}

		/// <summary>
		/// 1. 从keyIndexDict获取key对应的index, 然后在indexKeyDict将该index对应的值设成该dict中size-1的位置上的值
		/// 2. 将keyIndexDict中 以 indexKeyDict在size-1位置上对应的值 对应的index设成将要删除key对应的index.
		/// 3. 删除keyIndexDict需要删除的key 和 indexKeyDict最后位置的值
		/// </summary>
		public void Delete(T key)
		{
			if (!keyIndexDict.ContainsKey(key))
				return;

			int deleteIndex = keyIndexDict[key];
			int lastIndex = size - 1;
			T lastKey = indexKeyDict[lastIndex];

			indexKeyDict[deleteIndex] = lastKey;
			keyIndexDict[lastKey] = deleteIndex;
			keyIndexDict.Remove(key);
			indexKeyDict.Remove(lastIndex);
			size--;
		}

		public T GetRandom()
		{
			if (size == 0)
				return default(T);

			int randomIndex = new Random().Next(0, size);
			return indexKeyDict[randomIndex];

		}
	}
}
