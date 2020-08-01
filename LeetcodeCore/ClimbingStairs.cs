using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ClimbingStairs
    {
        // 70. Climbing Stairs
        public int ClimbStairs(int n)
        {
            var arr = new int[n + 1];
            arr[0] = 1;
            arr[1] = 1;
            if (n <= 1) return arr[n];
            for (int i = 2; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            return arr[n];
        }
    }
}
