using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MinCostClimbingStairsSolution
    {
        // 746. Min Cost Climbing Stairs
        public int MinCostClimbingStairs(int[] cost)
        {
            var dpArr = new int[cost.Length];
            dpArr[0] = cost[0];
            dpArr[1] = cost[1];

            for (int i = 2; i < dpArr.Length; i++)
            {
                dpArr[i] = cost[i] + Math.Min(dpArr[i - 1], dpArr[i - 2]);
            }
            return Math.Min(dpArr[^1], dpArr[^2]);
        }
    }
}
