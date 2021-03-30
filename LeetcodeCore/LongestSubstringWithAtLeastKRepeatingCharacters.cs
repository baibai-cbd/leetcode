using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class LongestSubstringWithAtLeastKRepeatingCharacters
    {
        // 395. Longest Substring with At Least K Repeating Characters
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


        // Divide and Conquer solution(roughly)
        public int LongestSubstring2(string s, int k)
        {
            return DivideConquerHelper(s, 0, s.Length - 1, k);
        }

        private int DivideConquerHelper(string s, int start, int end, int k)
        {
            if (end - start + 1 < k)
                return 0;

            var count = new int[26];
            for (int i = start; i <= end; i++)
                count[s[i] - 'a']++;

            for (int j = start; j <= end; j++)
            {
                if (count[s[j] - 'a'] < k)
                {
                    var left = DivideConquerHelper(s, start, j - 1, k); // mind the boundary index
                    var right = DivideConquerHelper(s, j + 1, end, k);
                    return Math.Max(left, right);
                }
            }
            return end - start + 1;
        }
    }
}
