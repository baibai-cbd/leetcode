using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class FindAllDuplicatesInAnArray
    {
        // 442. Find All Duplicates in an Array
        public IList<int> FindDuplicates(int[] nums)
        {
            var result =  new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var index = Math.Abs(nums[i]);
                if (nums[index-1] < 0)
                    result.Add(index);
                nums[index-1] = nums[index-1] * -1;
            }
            return result;
        }
    }
}
