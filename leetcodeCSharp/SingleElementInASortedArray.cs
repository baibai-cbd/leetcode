using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class SingleElementInASortedArray
    {
        // 540. Single Element in a Sorted Array
        public int SingleNonDuplicate(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            int l = 0;
            int r = nums.Length - 1;

            while (l < r)
            {
                int m = (l + r) / 2;
                if (nums[m] != nums[m + 1])
                {
                    if (m % 2 == 0)
                    {
                        r = m;
                    }
                    else
                    {
                        l = m+1;
                    }
                }
                if (nums[m] != nums[m - 1])
                {
                    if (m % 2 == 0)
                    {
                        l = m;
                    }
                    else
                    {
                        r = m-1;
                    }
                }
            }
            return nums[l];
        }
    }
}
