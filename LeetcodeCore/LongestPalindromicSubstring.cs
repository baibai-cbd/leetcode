using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LongestPalindromicSubstring
    {
        // 5. Longest Palindromic Substring
        public string LongestPalindrome(string s)
        {
            var dpArray = new int[s.Length][];
            var currMaxLength = 1;
            var currStartIndex = 0;
            for (int i = 0; i < dpArray.Length; i++)
            {
                dpArray[i] = new int[s.Length];
            }

            for (int i = 0; i < dpArray.Length; i++)
            {
                dpArray[i][i] = 1;
            }

            // starting index from bottom-right so that DP is building from smallest index span, thus bottom-up DP approach
            for (int i = s.Length - 1; i >= 0; i--)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (dpArray[i][j] != 0)
                        continue;

                    if (s[i] != s[j])
                        dpArray[i][j] = -1;
                    else
                        dpArray[i][j] = dpArray[i + 1][j - 1] == -1 ? -1 : dpArray[i + 1][j - 1] + 2;

                    if (dpArray[i][j] > currMaxLength)
                    {
                        currMaxLength = dpArray[i][j];
                        currStartIndex = i;
                    }
                }
            }

            return s.Substring(currStartIndex, currMaxLength);
        }
    }
}
