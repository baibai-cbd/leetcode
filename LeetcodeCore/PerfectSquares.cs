using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class PerfectSquares
    {
        // 279. Perfect Squares
        public int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                var min = int.MaxValue;
                int j = 1;
                while (i - j*j >= 0)
                {
                    min = Math.Min(min, dp[i - j * j] + 1);
                    j++;
                }
                dp[i] = min;
            }
            return dp[n];
        }
    }
}
