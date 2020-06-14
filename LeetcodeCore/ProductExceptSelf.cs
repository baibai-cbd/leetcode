using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class ProductExceptSelfSolution
    {
        // 238. Product of Array Except Self
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            result[0] = 1;

            for (int i = 1; i < n; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            int right = 1;
            for (int i = n-1; i >= 0; i--)
            {
                result[i] *= right;
                right *= nums[i];
            }
            return result;
        }
    }
}
