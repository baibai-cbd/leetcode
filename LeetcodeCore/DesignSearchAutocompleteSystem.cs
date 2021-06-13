using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class AutocompleteSystem
    {
        // 642. Design Search Autocomplete System
        // Modified TrieNode with a dictionary of (sentence, count) mapping
        // Lots of details to mind about, pretty complicated problem
        private readonly TrieNode _root;
        private readonly StringBuilder _sb;
        private TrieNode _currNode;

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            _root = new TrieNode('*');
            _sb = new StringBuilder();
            _currNode = _root;

            for (int i = 0; i < sentences.Length; i++)
            {
                AddSentence(sentences[i], times[i]);
            }
        }

        public IList<string> Input(char c)
        {
            if (c == '#')
            {
                var sentence = _sb.ToString();
                AddSentence(sentence, 1);
                _sb.Clear();
                _currNode = _root;
                return new List<string>();
            }
            else
            {
                // append the curr input char to _sb
                _sb.Append(c); 
                
                int charIndex;
                if (c == ' ') // map space character to last index
                    charIndex = 26;
                else
                    charIndex = c - 'a';

                if (_currNode._childNodes[charIndex] == null)
                {
                    _currNode._childNodes[charIndex] = new TrieNode(c);
                    _currNode = _currNode._childNodes[charIndex];
                    return new List<string>();
                }
                else
                {
                    _currNode = _currNode._childNodes[charIndex];
                    var pq = new PriorityQueue<(int, string)>(Comparer<(int, string)>.Create((a, b) => 
                    {
                        if (b.Item1.CompareTo(a.Item1) != 0) // descending order
                            return b.Item1.CompareTo(a.Item1);
                        else
                            return a.Item2.CompareTo(b.Item2);
                    }));

                    foreach (var kvp in _currNode._dict)
                    {
                        pq.Push((kvp.Value, kvp.Key));
                    }

                    var results = new List<string>();
                    while (pq.Count > 0 && results.Count < 3)
                    {
                        results.Add(pq.Pop().Item2);
                    }
                    return results;
                }
            }
        }

        private void AddSentence(string s, int count)
        {
            var node = _root;
            foreach (var c in s)
            {
                int charIndex;
                if (c == ' ') // map space character to last index
                    charIndex = 26;
                else
                    charIndex = c - 'a';

                if (node._childNodes[charIndex] == null)
                {
                    node._childNodes[charIndex] = new TrieNode(c);
                }

                // move to next node then operate on dict
                node = node._childNodes[charIndex];

                if (node._dict.ContainsKey(s))
                {
                    node._dict[s] += count;
                }
                else
                {
                    node._dict.Add(s, count);
                }
            }
        }


        #region TrieNode class
        public class TrieNode
        {
            public const int SIZE = 27; // one extra cell for space character
            public readonly char _c;
            public readonly TrieNode[] _childNodes;
            public readonly Dictionary<string, int> _dict;

            public TrieNode(char c)
            {
                _c = c;
                _childNodes = new TrieNode[SIZE];
                _dict = new Dictionary<string, int>();
            }
        }
        #endregion
    }
}
