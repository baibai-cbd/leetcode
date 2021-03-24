using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LongestSubstringWithAtMostKDistinctCharacters
    {
        // 340. Longest Substring with At Most K Distinct Characters
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            if (k == 0) return 0;

            var i = 0;
            var j = 0;
            var dict = new Dictionary<char, int>();
            var max = 0;
            dict.Add(s[0], 1);

            for (i = 0; i < s.Length; i++)
            {
                while (dict.Count <= k && j < s.Length)
                {
                    max = Math.Max(max, j - i + 1);
                    j++;
                    if (j < s.Length)
                    {
                        if (dict.ContainsKey(s[j]))
                            dict[s[j]]++;
                        else
                            dict.Add(s[j], 1);
                    }
                }

                dict[s[i]]--;
                if (dict[s[i]] == 0) dict.Remove(s[i]);
            }

            return max;
        }
    }
}
