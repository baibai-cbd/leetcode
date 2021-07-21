using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MaximumNumberOfPointsWithCost
    {
        // 1937. Maximum Number of Points with Cost
        // Amazing DP solution https://leetcode.com/problems/maximum-number-of-points-with-cost/discuss/1344908/Python-3-DP-Explanation-with-pictures
        // Because coming from one direction, the diff would apply to all elements,
        // thus we can use a left and a right array to account for all possible combinations
        public long MaxPoints(int[][] points)
        {
            var m = points.Length;
            var n = points[0].Length;

            var prevArr = new long[n];
            for (int i = 0; i < n; i++)
                prevArr[i] = (long)points[0][i];

            for (int i = 1; i < m; i++)
            {
                // generate left array
                var left = new long[n];
                left[0] = prevArr[0];
                for (int j = 1; j < n; j++)
                {
                    left[j] = Math.Max(left[j - 1] - 1, prevArr[j]);
                }
                // generate right array
                var right = new long[n];
                right[^1] = prevArr[^1];
                for (int j = n - 2; j >= 0; j--)
                {
                    right[j] = Math.Max(right[j + 1] - 1, prevArr[j]);
                }
                // generate curr array
                var curr = new long[n];
                for (int j = 0; j < n; j++)
                {
                    curr[j] = points[i][j] + Math.Max(left[j], right[j]);
                }

                prevArr = curr;
            }

            long max = 0;
            foreach (var num in prevArr)
            {
                max = Math.Max(max, num);
            }

            return max;
        }
    }
}
