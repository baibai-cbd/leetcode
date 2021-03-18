using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LongestSubstringWithoutRepeatingCharacters
    {
        // 3. Longest Substring Without Repeating Characters
        public int LengthOfLongestSubstring(string s)
        {
            var freqArr = new int[256];
            var i = 0;
            var j = 0;
            var maxLength = 0;

            for (i = 0; i < s.Length; i++)
            {
                while (freqArr[s[j]] == 0)
                {
                    freqArr[s[j]]++;
                    maxLength = Math.Max(maxLength, j - i + 1);
                    if (j < s.Length - 1) j++;
                }

                freqArr[s[i]]--; // when substring not valid, move front index until it's valid again
            }

            return maxLength;
        }
    }
}
