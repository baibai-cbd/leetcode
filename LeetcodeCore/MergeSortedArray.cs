using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MergeSortedArray
    {
        // 88. Merge Sorted Array
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var index1 = m - 1;
            var index2 = n - 1;
            var newIndex = m + n;
            while (index1 >= 0 || index2 >= 0)
            {
                newIndex--;

                if (index1 < 0)
                {
                    nums1[newIndex] = nums2[index2];
                    index2--;
                    continue;
                }
                if (index2 < 0)
                {
                    nums1[newIndex] = nums1[index1];
                    index1--;
                    continue;
                }

                if (nums1[index1] >= nums2[index2])
                {
                    nums1[newIndex] = nums1[index1];
                    index1--;
                }
                else
                {
                    nums1[newIndex] = nums2[index2];
                    index2--;
                }
            }
        }
    }
}
