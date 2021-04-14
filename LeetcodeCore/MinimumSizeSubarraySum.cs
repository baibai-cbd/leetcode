using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MinimumSizeSubarraySum
    {
        // 209. Minimum Size Subarray Sum
        public int MinSubArrayLen(int target, int[] nums)
        {
            var i = 0;
            var j = 0;
            var currSum = nums[0];
            var minLength = nums.Length + 1;

            for (i = 0; i < nums.Length; i++)
            {
                while (currSum < target && j < nums.Length - 1)
                {
                    j++;
                    currSum += nums[j];
                }

                if (currSum >= target)
                    minLength = Math.Min(minLength, j - i + 1);

                currSum -= nums[i];
            }

            return minLength == nums.Length + 1 ? 0 : minLength;
        }
    }
}
