using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class AddAndSearchWord
    {
        // 211. Add and Search Word - Data structure design

        private readonly TrieNode[] nodes;
        /** Initialize your data structure here. */
        public AddAndSearchWord()
        {
            nodes = new TrieNode[26];
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            var currNodes = nodes;
            var currNode = new TrieNode('*', false);
            foreach (var c in word)
            {
                if (currNodes[c - 'a'] == null)
                    currNodes[c - 'a'] = new TrieNode(c, false);
                currNode = currNodes[c - 'a'];
                currNodes = currNode.childNodes;
            }
            currNode.isEndOfWord = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return SearchRecursive(word.ToCharArray(), 0, nodes, false);
        }

        private bool SearchRecursive(char[] chars, int index, TrieNode[] currNodes, bool lastEOW)
        {
            if (index == chars.Length)
                return lastEOW;

            var c = chars[index];
            if (c == '.')
            {
                for (int i = 0; i < currNodes.Length; i++)
                {
                    var node1 = currNodes[i];
                    if (node1 != null)
                    {
                        var b = SearchRecursive(chars, index + 1, node1.childNodes, node1.isEndOfWord);
                        if (b)
                            return true;
                    }
                }
                return false;
            }
            var node2 = currNodes[c - 'a'];
            if (node2 == null)
                return false;
            return SearchRecursive(chars, index + 1, node2.childNodes, node2.isEndOfWord);
        }
    }
}
