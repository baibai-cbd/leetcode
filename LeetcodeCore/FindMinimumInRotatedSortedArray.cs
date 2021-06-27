using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class FindMinimumInRotatedSortedArray
    {
        // 153. Find Minimum in Rotated Sorted Array
        // great binary search solution
        public int FindMin(int[] nums)
        {
            var l = 0;
            var r = nums.Length - 1;

            if (nums[l] < nums[r])
                return nums[l];

            while (1 < r - l)
            {
                var mid = l + (r - l) / 2;

                if (nums[mid] > nums[l])
                {
                    l = mid;
                    continue;
                }
                if (nums[mid] < nums[r])
                {
                    r = mid;
                    continue;
                }
            }

            return nums[r];
        }
    }
}
