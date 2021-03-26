using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class LongestSubstringWithAtLeastKRepeatingCharacters
    {
        // 395. Longest Substring with At Least K Repeating Characters
        // TODO: Try divide&conquer recursive solution next time
        public int LongestSubstring(string s, int k)
        {
            if (k > s.Length)
                return 0;

            var max = 0;
            var countArr = new int[26];

            for (int u = 1; u <= 26; u++)
            {
                Array.Fill(countArr, 0);
                var left = 0;
                var right = 0;
                var uniqueCount = 0;
                var kOrMoreCount = 0;

                while (right < s.Length)
                {
                    if (uniqueCount <= u)
                    {
                        var index = s[right] - 'a';
                        if (countArr[index] == 0)
                        {
                            uniqueCount++;
                        }
                        if (countArr[index] == k - 1)
                        {
                            kOrMoreCount++;
                        }
                        countArr[index]++;
                        right++;
                    }
                    else
                    {
                        var index = s[left] - 'a';
                        if (countArr[index] == 1)
                        {
                            uniqueCount--;
                        }
                        if (countArr[index] == k)
                        {
                            kOrMoreCount--;
                        }
                        countArr[index]--;
                        left++;
                    }
                    if (uniqueCount == u && uniqueCount == kOrMoreCount)
                    {
                        max = Math.Max(max, right - left);
                    }
                }
            }
            return max;
        }
    }
}
