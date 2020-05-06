using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class MaximumSubarray
    {
        // 53. Maximum Subarray
        public int MaxSubArray(int[] nums)
        {
            int[] dpArray = new int[nums.Length];
            dpArray[0] = nums[0];
            int maxSum = dpArray[0];
            for (int i = 1; i < nums.Length; i++)
            {
                dpArray[i] = Math.Max(dpArray[i - 1] + nums[i], nums[i]);
                maxSum = Math.Max(dpArray[i], maxSum);
            }

            return maxSum;
        }
    }
}
