using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class KthLargestElementInAnArray
    {
        // 215. Kth Largest Element in an Array
        // QuickSelect
        public int FindKthLargest(int[] nums, int k)
        {
            return QuickSelect(nums, 0, nums.Length - 1, k);
        }

        private int QuickSelect(int[] nums, int low, int high, int k)
        {
            var partition = Partition(nums, low, high);
            var count = high - partition + 1;

            if (count == k)
                return nums[partition];
            else if (count > k)
                return QuickSelect(nums, partition + 1, high, k);
            else
                return QuickSelect(nums, low, partition - 1, k - count); // (k-count) means deduct the already counted ones
        }

        private int Partition(int[] nums, int low, int high)
        {
            var pivotNum = nums[high];
            var pivotIndex = low;

            for (int i = low; i < high; i++)
            {
                if (nums[i] < pivotNum)
                {
                    var temp = nums[i];
                    nums[i] = nums[pivotIndex];
                    nums[pivotIndex] = temp;
                    pivotIndex++;
                }
            }
            var temp2 = nums[pivotIndex];
            nums[pivotIndex] = nums[high];
            nums[high] = temp2;
            return pivotIndex;
        }
    }
}
