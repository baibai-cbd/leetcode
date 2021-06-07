using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class JumpGame
    {
        // 55. Jump Game
        public bool CanJump(int[] nums)
        {
            var currIndex = 0;
            var currRange = Math.Min(nums.Length - 1, nums[0]);
            var nextRange = 0;

            while (true)
            {
                for (int i = currIndex; i <= currRange; i++)
                {
                    nextRange = Math.Max(nextRange, i + nums[i]);
                }

                if (nextRange >= nums.Length - 1)
                    return true;
                if (nextRange == currRange)
                    return false;

                currIndex = currRange;
                currRange = nextRange;
                nextRange = 0;
            }
        }
    }
}
