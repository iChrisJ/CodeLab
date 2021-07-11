using System;

/// <summary>
/// LeetCode: 0208 Implement Trie (Prefix Tree)
/// </summary>
namespace CodeInCS._0208_Implement_Trie__Prefix_Tree_
{
	public class Trie
	{
		private class TrieNode
		{
			/// <summary>
			/// 表示有多少单词有字符通过该节点
			/// </summary>
			public int Pass { get; set; }

			/// <summary>
			/// 表示有多少单词已该节点结尾
			/// </summary>
			public int End { get; set; }

			public TrieNode[] Next { get; set; }

			public TrieNode()
			{
				this.Next = new TrieNode[26];
			}
		}

		private TrieNode root;

		/** Initialize your data structure here. */
		public Trie()
		{
			root = new TrieNode();
		}

		/** Inserts a word into the trie. */
		public void Insert(string word)
		{
			TrieNode cur = root;
			cur.Pass++;
			foreach (char c in word)
			{
				int index = c - 'a';
				if (cur.Next[index] == null)
					cur.Next[index] = new TrieNode();
				cur = cur.Next[index];
				cur.Pass++;
			}
			cur.End++;
		}

		/** Returns if the word is in the trie. */
		public bool Search(string word)
		{
			if (string.IsNullOrEmpty(word))
				return false;

			TrieNode cur = root;
			foreach (char c in word)
			{
				int index = c - 'a';
				if (cur.Next[index] == null)
					return false;
				cur = cur.Next[index];
			}
			return cur.End > 0;
		}

		/** Returns if there is any word in the trie that starts with the given prefix. */
		public bool StartsWith(string prefix)
		{
			if (string.IsNullOrEmpty(prefix))
				return false;

			TrieNode cur = root;
			foreach (char c in prefix)
			{
				int index = c - 'a';
				if (cur.Next[index] == null)
					return false;
				cur = cur.Next[index];
			}
			return true;
		}

		public bool Delete(string word)
		{
			if (!Search(word))
				return false;

			TrieNode cur = root;
			cur.Pass--;
			foreach (char c in word)
			{
				int index = c - 'a';
				TrieNode next = cur.Next[index];
				next.Pass--;
				if (next.Pass == 0)
				{
					cur.Next[index] = null;
					return true;
				}

				cur = next;
			}
			cur.End--;
			return true;
		}
	}

	/**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}
