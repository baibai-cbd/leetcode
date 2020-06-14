using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    // 208. Implement Trie (Prefix Tree)

    public class TrieNode
    {
        public const int SIZE = 26;
        public readonly char _c;
        public readonly TrieNode[] childNodes;
        public bool isEndOfWord;

        public TrieNode(char c, bool endOfWord)
        {
            _c = c;
            isEndOfWord = endOfWord;
            childNodes = new TrieNode[SIZE];
        }
    }

    public class Trie
    {
        public TrieNode[] nodes;
        /** Initialize your data structure here. */
        public Trie()
        {
            nodes = new TrieNode[26];
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var currNodes = nodes;
            var currNode = new TrieNode('*',false);
            foreach (var c in word)
            {
                if (currNodes[c - 'a'] == null)
                    currNodes[c - 'a'] = new TrieNode(c, false);
                currNode = currNodes[c - 'a'];
                currNodes = currNode.childNodes;
            }
            currNode.isEndOfWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var currNodes = nodes;
            var currNode = new TrieNode('*', false);
            foreach (var c in word)
            {
                if (currNodes[c-'a'] != null)
                {
                    currNode = currNodes[c - 'a'];
                    currNodes = currNode.childNodes;
                }
                else
                {
                    return false;
                }
            }
            return currNode.isEndOfWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var currNodes = nodes;
            foreach (var c in prefix)
            {
                if (currNodes[c - 'a'] != null)
                    currNodes = currNodes[c - 'a'].childNodes;
                else
                    return false;
            }
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
