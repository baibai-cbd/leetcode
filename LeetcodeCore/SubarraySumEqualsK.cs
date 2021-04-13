using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SubarraySumEqualsK
    {
        // 560. Subarray Sum Equals K
        // This problem uses PreSum and cannot be worked with SlidingWindow
        // It is roughly because we cannot control the direction towards goal(k) by expanding or shrinking window in the problem, because of existence of negative numbers
        public int SubarraySum(int[] nums, int k)
        {
            var preSumDict = new Dictionary<int, int>();
            var currSum = 0;
            var count = 0;
            preSumDict.Add(0, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                currSum += nums[i];

                if (preSumDict.ContainsKey(currSum - k))
                {
                    count += preSumDict[currSum - k];
                }

                if (preSumDict.ContainsKey(currSum))
                    preSumDict[currSum]++;
                else
                    preSumDict.Add(currSum, 1);
            }

            return count;
        }
    }
}
