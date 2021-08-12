using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LongestCommonSubstring
    {
        public int LCSubstring(string s, string t)
        {
            var m = s.Length;
            var n = t.Length;
            var dpArr = new int[m + 1, n + 1];
            var maxLength = 0;

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dpArr[i, j] = 0;
                    }
                    else if (s[i-1] == t[j-1])
                    {
                        dpArr[i, j] = dpArr[i - 1, j - 1] + 1;
                        maxLength = Math.Max(maxLength, dpArr[i, j]);
                    }
                    else
                    {
                        dpArr[i, j] = 0;
                    }
                }
            }

            return maxLength;
        }
    }
}
