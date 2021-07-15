using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LongestIncreasingSubsequence
    {
        // 300. Longest Increasing Subsequence
        // O(n) space dp array, O(n^2) time complexity
        // For each number, compare and get the longest LIS starting at this number
        // By starting from the end, build upon the smaller result from the ending elements
        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 1)
                return 1;

            var dpArray = new int[nums.Length];
            Array.Fill(dpArray, 1);

            var maxLength = 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        dpArray[i] = Math.Max(dpArray[i], dpArray[j] + 1);
                        maxLength = Math.Max(maxLength, dpArray[i]);
                    }
                }
            }

            return maxLength;
        }
    }
}
