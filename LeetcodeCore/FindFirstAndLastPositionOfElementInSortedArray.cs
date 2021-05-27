using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class FindFirstAndLastPositionOfElementInSortedArray
    {
        // 34. Find First and Last Position of Element in Sorted Array
        // Binary search is about details on boundary conditions, need to be very careful
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
                return new int[] { -1, -1 };

            var l = 0;
            var r = nums.Length - 1;
            var m = 0;

            while (l <= r)
            {
                m = l + (r - l) / 2;
                if (nums[m] < target)
                {
                    l = m + 1;
                }
                else if (nums[m] == target)
                {
                    r = m - 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            // By the end our search loop, it is guaranteed  (r + 1 = l)
            // for leftBound here, we want to take the bigger index of the index pair here
            // thus check (l) for boundary, if out of bound take the smaller index(r), otherwise take (l)
            var leftBound = 0;
            if (l >= nums.Length)
                leftBound = nums[r] == target ? r : -1;
            else
                leftBound = nums[l] == target ? l : -1;

            l = 0;
            r = nums.Length - 1;
            m = 0;

            while (l <= r)
            {
                m = l + (r - l) / 2;
                if (nums[m] < target)
                {
                    l = m + 1;
                }
                else if (nums[m] == target)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            // similar as above, we want to take the smaller index of the index pair here
            // thus check (r) for boundary, if out of bound take the bigger index(l), otherwise take (r)
            var rightBound = 0;
            if (r < 0)
                rightBound = nums[l] == target ? l : -1;
            else
                rightBound = nums[r] == target ? r : -1;

            return new int[] { leftBound, rightBound };
        }
    }
}
