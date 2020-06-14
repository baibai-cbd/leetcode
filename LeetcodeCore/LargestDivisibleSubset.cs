using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class LargestDivisibleSubsetSolution
    {
        // 368. Largest Divisible Subset
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new List<int>();

            Array.Sort(nums);
            var result = new List<int>();
            var dp = new int[nums.Length];
            Array.Fill(dp, 1);


            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i-1; j >= 0 ; j--)
                {
                    if (nums[i] % nums[j] == 0)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            int maxIndex = 0;
            for (int i = 1; i < nums.Length; i++)
                maxIndex = dp[i] > dp[maxIndex] ? i : maxIndex;

            var biggest = nums[maxIndex];
            var currCount = dp[maxIndex];
            for (int i = maxIndex; i >= 0; i--)
            {
                if (biggest % nums[i] == 0 && dp[i] == currCount)
                {
                    result.Add(nums[i]);
                    currCount--;
                }
            }

            return result;
        }
    }
}
