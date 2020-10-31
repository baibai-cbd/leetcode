using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SearchInRotatedSortedArray
    {
        // 33. Search in Rotated Sorted Array
        public int Search(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;
            var mid = right / 2;

            while (mid - left > 5)
            {
                if (nums[mid] > nums[left])
                {
                    if (nums[mid] >= target && nums[left] <= target)
                    {
                        var r = Array.BinarySearch(nums, left, mid - left + 1, target);
                        if (r >= 0)
                            return r;
                    }
                    left = mid + 1;
                    mid = (right + left) / 2;
                }
                else if (nums[right] > nums[mid])
                {
                    if (nums[mid] <= target && nums[right] >= target)
                    {
                        var r = Array.BinarySearch(nums, mid, right - mid + 1, target);
                        if (r >= 0)
                            return r;
                    }
                    right = mid - 1;
                    mid = (right + left) / 2;
                }
            }

            for (int i = left; i <= right; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        private int RecursiveHalfBinarySearch(int[] nums, int left, int right, int target)
        {
            // TODO:
            return -1;
        }
    }
}
