using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class NextPermutationSolution
    {
        // 31. Next Permutation
        public void NextPermutation(int[] nums)
        {
            if (nums.Length == 1)
                return;

            var index1 = nums.Length - 1;
            var currMax = nums[index1];
            while (index1 >= 0 && nums[index1] >= currMax)
            {
                currMax = nums[index1];
                index1--;
            }

            if (index1 < 0)
            {
                Array.Sort(nums);
                return;
            }
            else
            {
                // sort the remaining part, so that it's easy to find the number we want to swap
                Array.Sort(nums, index1 + 1, nums.Length - (index1 + 1));
                var index2 = index1 + 1;
                while (nums[index2] <= nums[index1])
                {
                    index2++;
                }
                Swap(nums, index2, index1);
                return;
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
