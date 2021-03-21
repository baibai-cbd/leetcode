using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LongestSubstringWithAtMostTwoDistinctCharacters
    {
        // 159. Longest Substring with At Most Two Distinct Characters
        // HashSet won't work, need Dictionary to count occurence
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            var i = 0;
            var j = 0;
            var max = 0;
            var dict = new Dictionary<char, int>();
            dict.Add(s[0], 1);

            for (i = 0; i < s.Length; i++)
            {
                while (dict.Count <= 2 && j < s.Length)
                {
                    max = Math.Max(max, j - i + 1);
                    j++;
                    if (j < s.Length)
                    {
                        if (dict.ContainsKey(s[j]))
                            dict[s[j]]++;
                        else
                            dict.Add(s[j],1);
                    }
                }

                dict[s[i]]--;
                if (dict[s[i]] == 0) dict.Remove(s[i]);
            }

            return max;
        }
    }
}
