using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class WordBreakSolution
    {
        // 139. Word Break
        public bool WordBreak(string s, IList<string> wordDict)
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
                    if (flags[j] && hs.Contains(s.Substring(j, i - j)))  // s[j..i] is equivalent of s.Substring(j, i - j)
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
