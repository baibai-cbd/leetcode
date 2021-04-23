using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LongestCommonSubsequenceSolution
    {
        // 1143. Longest Common Subsequence
        // Good DP solution
        public int LongestCommonSubsequence(string text1, string text2)
        {
            var dpArr = new int[text1.Length, text2.Length];

            var matchFlag = false;
            for (int i = 0; i < text1.Length; i++)
            {
                if (text1[i] == text2[0] || matchFlag) // if one char is matched, need to propagate thru rest of row/column
                {
                    dpArr[i, 0] = 1;
                    matchFlag = true;
                }
            }
            matchFlag = false;
            for (int i = 0; i < text2.Length; i++)
            {
                if (text2[i] == text1[0] || matchFlag)
                {
                    dpArr[0, i] = 1;
                    matchFlag = true;
                }
            }

            for (int i = 1; i < text1.Length; i++)
            {
                for (int j = 1; j < text2.Length; j++)
                {
                    if (text1[i] == text2[j])
                    {
                        dpArr[i, j] = dpArr[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dpArr[i, j] = Math.Max(dpArr[i - 1, j], dpArr[i, j - 1]);
                    }
                }
            }

            return dpArr[text1.Length - 1, text2.Length - 1];
        }
    }
}
