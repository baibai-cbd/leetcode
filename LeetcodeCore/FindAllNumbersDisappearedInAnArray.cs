using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class FindAllNumbersDisappearedInAnArray
    {
        // 448. Find All Numbers Disappeared in an Array
        // Use number content as indexes
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var result = new List<int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var index = Math.Abs(nums[i]) - 1;
                nums[index] = Math.Abs(nums[index]) * -1;
            }

            for (var j = 0; j < nums.Length; j++)
            {
                if (nums[j] > 0)
                    result.Add(j + 1);
            }

            return result;
        }
    }
}
