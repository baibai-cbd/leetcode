using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class TwoSumSolution
    {
        // 1. Two Sum
        public int[] TwoSum(int[] nums, int target)
        {
            var hs = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var j = target - nums[i];
                if (hs.Contains(j))
                    return new int[] { i, Array.IndexOf(nums, j) };
                hs.Add(nums[i]); // Add after lookup
            }
            return null;
        }
    }
}
