using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class UncrossedLines
    {
        // 1035. Uncrossed Lines
        // Same as LongestCommonSubsequence
        public int MaxUncrossedLines(int[] A, int[] B)
        {
            int[][] dp = new int[A.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = Enumerable.Repeat(-1,B.Length).ToArray();
            }
            return LongestCommonSubsequence(A, B, 0, 0, dp);
        }

        // LongestCommonSubsequence is important algorithm
        private int LongestCommonSubsequence(int[] a, int[] b, int i, int j, int[][] dp)
        {
            if (i == a.Length || j == b.Length)
                return 0;

            if (dp[i][j] != -1)
                return dp[i][j];

            if (a[i] == b[j])
            {
                dp[i][j] = 1 + LongestCommonSubsequence(a, b, i + 1, j + 1, dp);
                return dp[i][j];
            }
            else
            {
                dp[i][j] = Math.Max(LongestCommonSubsequence(a, b, i + 1, j, dp), LongestCommonSubsequence(a, b, i, j + 1, dp));
                return dp[i][j];
            }
        }
    }
}
