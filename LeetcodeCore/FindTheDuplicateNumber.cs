using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class FindTheDuplicateNumber
    {
        // 287. Find the Duplicate Number
        // TODO: There is multiple ways to do it, including an index to value interchanging solution
        public int FindDuplicate(int[] nums)
        {
            var low = 1;
            var high = nums.Length - 1;

            while (low < high)
            {
                // Because the mid value would equal to low if (high - low) == 1,
                // the comparison (n <= mid) need equal sign,
                // and updating (low = mid + 1) need the plus one as well, (low = mid) will result in infinite loop
                var mid = (low + high) / 2;
                var count = 0;
                foreach (var n in nums)
                {
                    if (n <= mid)
                        count++;
                }
                if (count <= mid)
                    low = mid + 1;
                else
                    high = mid;
            }

            return low;
        }
    }
}
