using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class PartitionEqualSubsetSum
    {
        // 416. Partition Equal Subset Sum
        // Bounded Knapsack, each element can only be used once
        public bool CanPartition(int[] nums)
        {
            var sum = 0;
            foreach (var num in nums)
                sum += num;

            if (sum % 2 == 1) return false;

            var dpArr = new bool[nums.Length + 1, (sum / 2) + 1];
            // [0,0] is true because zero element can build a zero sum, which is the base inital case
            dpArr[0, 0] = true;

            for (int i = 0; i < nums.Length; i++)   
            {
                for (int j = sum / 2; j >= 0; j--)
                {
                    if (j >= nums[i])
                    {
                        // dpArr index are +1 to spare space for the zero element, so [i+1] is current element and [i] is previous element
                        dpArr[i + 1, j] = dpArr[i, j] || dpArr[i, j - nums[i]];
                    }
                    else
                    {
                        // pass the result from previous element
                        dpArr[i + 1, j] = dpArr[i, j];
                    }
                }
            }

            return dpArr[nums.Length, sum / 2];
        }
    }
}
