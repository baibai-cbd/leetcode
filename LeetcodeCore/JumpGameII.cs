using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class JumpGameII
    {
        // 45. Jump Game II
        // Implicit BFS solution
        // traverse thru currRange is BFS on the current "level", increment count and update range goes to the next level
        public int Jump(int[] nums)
        {
            if (nums.Length == 1)
                return 0;

            var currIndex = 0;
            var currRange = 0;
            var nextRange = 0;
            var count = 0;

            while (true)
            {
                for (int i = currIndex; i <= currRange; i++)
                {
                    nextRange = Math.Max(nextRange, i + nums[i]);
                }

                count++;

                if (nextRange >= nums.Length - 1)
                    return count;

                currIndex = currRange + 1;
                currRange = nextRange;
                nextRange = 0;
            }
        }
    }
}
