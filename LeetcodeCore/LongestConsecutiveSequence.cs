using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LongestConsecutiveSequence
    {
        // 128. Longest Consecutive Sequence
        // A small tweak on UnionFind to add the FindSize method for this problem
        public int LongestConsecutive(int[] nums)
        {
            var uf = new UnionFind(nums.Length);
            var dict = new Dictionary<int, int>();
            var maxLength = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
                else
                    continue;

                if (dict.ContainsKey(nums[i] - 1))
                {
                    uf.Union(i, dict[nums[i] - 1]);
                }
                if (dict.ContainsKey(nums[i] + 1))
                {
                    uf.Union(i, dict[nums[i] + 1]);
                }

                maxLength = Math.Max(maxLength, uf.FindSize(i));
            }

            return maxLength;
        }
    }
}
