using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MaximumProductSubarray
    {
        // 152. Maximum Product Subarray
        public int MaxProduct(int[] nums)
        {
            var result = nums[0];
            var l = 0;
            var r = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                l = (l == 0 ? 1 : l) * nums[i];
                result = Math.Max(result, l);
            }
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                r = (r == 0 ? 1 : r) * nums[i];
                result = Math.Max(result, r);
            }

            return result;
        }
    }
}
