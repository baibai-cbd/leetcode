using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SubsetsSolution
    {
        // 78. Subsets
        // Backtracking pretty easy
        public IList<IList<int>> Subsets(int[] nums)
        {
            var results = new List<IList<int>>();
            Backtrack(results, new List<int>(), nums, 0);
            return results;
        }

        private void Backtrack(IList<IList<int>> results, IList<int> currList, int[] nums, int startIndex)
        {
            results.Add(new List<int>(currList));

            for (int i = startIndex; i < nums.Length; i++)
            {
                currList.Add(nums[i]);
                Backtrack(results, currList, nums, i + 1);
                currList.RemoveAt(currList.Count - 1);
            }
        }
    }
}
