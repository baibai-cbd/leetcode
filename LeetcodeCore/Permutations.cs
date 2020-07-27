using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class Permutations
    {
        // 46. Permutations
        public IList<IList<int>> Permute(int[] nums)
        {
            Array.Sort(nums);
            var results = new List<IList<int>>();
            if (nums.Length == 0)
                return results;

            RecursiveHelper(nums, new List<int>(), results);
            return results; 
        }

        private void RecursiveHelper(int[] nums, IList<int> array, IList<IList<int>> results)
        {
            if (array.Count == nums.Length)
            {
                results.Add(new List<int>(array));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (array.Contains(nums[i]))
                    continue;
                array.Add(nums[i]);
                RecursiveHelper(nums, array, results);
                array.RemoveAt(array.Count - 1);
            }
        }
    }
}
