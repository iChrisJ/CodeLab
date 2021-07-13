using System;
using System.Collections.Generic;

/// <summary>
/// LeetCode: 0211 Design Add and Search Words Data Structure
/// </summary>
namespace CodeInCS._0211_Design_Add_and_Search_Words_Data_Structure
{
	public class WordDictionary
	{
		private class TrieNode
		{
			public int End { get; set; }
			public TrieNode[] Next { get; set; }

			public TrieNode()
			{
				Next = new TrieNode[26];
			}
		}

		private TrieNode root;
		public WordDictionary()
		{
			root = new TrieNode();
		}

		public void AddWord(string word)
		{
			TrieNode cur = root;

			foreach (char c in word)
			{
				int index = c - 'a';
				if (cur.Next[index] == null)
					cur.Next[index] = new TrieNode();
				cur = cur.Next[index];
			}
			cur.End++;
		}

		public bool Search(string word)
		{
			return SearchDFS(0, word, root);
		}

		private bool SearchDFS(int start, string word, TrieNode node)
		{
			if (start == word.Length)
				return node.End > 0;

			if (word[start] != '.')
			{
				int i = word[start] - 'a';
				if (node.Next[i] == null)
					return false;
				return SearchDFS(start + 1, word, node.Next[i]);
			}
			else
			{
				foreach (TrieNode trieNode in node.Next)
					if (trieNode != null && SearchDFS(start + 1, word, trieNode))
						return true;
			}
			return false;
		}
	}
}
