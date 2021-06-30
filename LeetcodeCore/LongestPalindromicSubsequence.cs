using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class LongestPalindromicSubsequence
    {
        // 516. Longest Palindromic Subsequence
        // Great problem that you can start from two different places (palindromic)/(subsequence)
        //
        // Solution 1 inherits the idea from (5. Longest Palindromic Substring)
        public int LongestPalindromeSubseq(string s)
        {
            var dpArray = new int[s.Length][];
            for (int i = 0; i < dpArray.Length; i++)
            {
                dpArray[i] = new int[s.Length];
            }

            for (int i = 0; i < dpArray.Length; i++)
            {
                dpArray[i][i] = 1;
            }

            for (int i = s.Length - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                        dpArray[i][j] = dpArray[i + 1][j - 1] + 2;
                    else
                        dpArray[i][j] = Math.Max(dpArray[i + 1][j], dpArray[i][j - 1]);
                }
            }

            return dpArray[0][^1];
        }


        // Solution 2 inherits the idea from (1143. Longest Common Subsequence)
        public int LongestPalindromeSubseq2(string s)
        {
            // brilliantly using reverse of s,
            // now s and s2 has a LongestCommonSubsequence which is equivalent to LongestPalindromicSubsequence of s.
            string s2 = new string(s.Reverse().ToArray());

            return LongestCommonSubsequence(s, s2);
        }

        private int LongestCommonSubsequence(string text1, string text2)
        {
            var dpArr = new int[text1.Length + 1, text2.Length + 1];

            for (int i = 1; i < text1.Length + 1; i++)
            {
                for (int j = 1; j < text2.Length + 1; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dpArr[i, j] = dpArr[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dpArr[i, j] = Math.Max(dpArr[i - 1, j], dpArr[i, j - 1]);
                    }
                }
            }

            return dpArr[text1.Length, text2.Length];
        }
    }
}
