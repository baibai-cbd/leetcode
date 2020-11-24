using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SortColorsSolution
    {
        // 75. Sort Colors
        // Two pass method
        public void SortColors(int[] nums)
        {
            var count0 = 0;
            var count1 = 0;
            var count2 = 0;

            foreach (var item in nums)
            {
                if (item == 0)
                    count0++;
                else if (item == 1)
                    count1++;
                else
                    count2++;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (i < count0)
                    nums[i] = 0;
                else if (i >= count0 && i < count0 + count1)
                    nums[i] = 1;
                else
                    nums[i] = 2;
            }
        }

        // TODO: One pass method
    }
}
