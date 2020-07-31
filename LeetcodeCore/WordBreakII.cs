using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class WordBreakII
    {
        // 140. Word Break II
        // Perform a WordBreak(P.139) check first, then using DFS search
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var results = new List<string>();
            if (!WordBreakOld(s, wordDict))
                return results;

            var sbRaw = new StringBuilder(s);
            var sbGen = new StringBuilder();

            RecursiveHelper(results, wordDict, sbRaw, sbGen);
            return results;
        }

        public void RecursiveHelper(IList<string> results, IList<string> dict, StringBuilder sbRaw, StringBuilder sbGen)
        {
            if (sbRaw.Length == 0)
            {
                results.Add(sbGen.ToString().Trim());
                return;
            }
            foreach (var word in dict)
            {
                if (sbRaw.Length < word.Length)
                {
                    continue;
                }
                if (sbRaw.ToString(0,word.Length) == word)
                {
                    var index = sbGen.Length;
                    sbGen.Append($"{word} ");
                    sbRaw.Remove(0, word.Length);
                    RecursiveHelper(results, dict, sbRaw, sbGen);
                    sbRaw.Insert(0, word.ToCharArray());
                    sbGen.Remove(index, word.Length + 1);
                }
            }
        }

        public bool WordBreakOld(string s, IList<string> wordDict)
        {
            var hs = new HashSet<string>();
            foreach (string w in wordDict)
            {
                hs.Add(w);
            }

            var flags = new bool[s.Length + 1];
            flags[0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (flags[j] && hs.Contains(s.Substring(j, i - j)))
                    {
                        flags[i] = true;
                        break;
                    }
                }
            }

            return flags[s.Length];
        }
    }
}
