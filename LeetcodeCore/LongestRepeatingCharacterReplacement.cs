using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class LongestRepeatingCharacterReplacement
    {
        // 424. Longest Repeating Character Replacement
        public int CharacterReplacement(string s, int k)
        {
            if (s.Length <= k)
                return s.Length;

            var i = 0;
            var j = 0;
            var max = 0;
            var dict = new Dictionary<char, int>();
            dict.Add(s[i], 1);
            var maxCount = dict.First();

            for (i = 0; i < s.Length; i++)
            {
                while (j - i + 1 - maxCount.Value <= k && j < s.Length)
                {
                    max = Math.Max(max, j - i + 1);
                    j++;
                    if (j < s.Length)
                    {
                        if (dict.ContainsKey(s[j]))
                        {
                            dict[s[j]]++;
                            maxCount = dict[s[j]] > maxCount.Value ? new KeyValuePair<char, int>(s[j], dict[s[j]]) : maxCount;
                        }
                        else
                        {
                            dict.Add(s[j], 1);
                        }
                    }
                }
                dict[s[i]]--;
                // this update maxCount step is not necessary because if maxCount char is being taking out by i++,
                // it would not affect the amount of need-to-change characters, i.e. (j - i + 1 - maxCount.Value <= k) will still be valid
                // if (maxCount.Key == s[i]) maxCount = dict.OrderByDescending(kv => kv.Value).First();
                if (dict[s[i]] == 0) dict.Remove(s[i]);
            }

            return max;
        }
    }
}
