using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MinimumNumberOfArrowsToBurstBalloons
    {
        // 452. Minimum Number of Arrows to Burst Balloons
        public int FindMinArrowShots(int[][] points)
        {
            // a[0] - b[0] might not work when -2147483646 edge case can overload int
            Array.Sort(points, Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));
            var flag = false;
            var count = 0;
            var currEnd = int.MaxValue;

            foreach (var p in points)
            {
                flag = true;
                if (p[0] > currEnd)
                {
                    currEnd = p[1];
                    count++;
                }
                else
                {
                    if (p[1] < currEnd)
                        currEnd = p[1];
                }
            }

            count += flag ? 1 : 0;
            return count;
        }
    }
}
