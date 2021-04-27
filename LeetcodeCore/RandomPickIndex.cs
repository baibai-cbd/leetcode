using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class RandomPickIndex
    {
        // 398. Random Pick Index
        // O(n) space, O(1) retrieval time
        private Dictionary<int, IList<int>> _dict;
        private Random _rand;

        public RandomPickIndex(int[] nums)
        {
            _dict = new Dictionary<int, IList<int>>();
            _rand = new Random();

            for (int i = 0; i < nums.Length; i++)
            {
                if (_dict.ContainsKey(nums[i]))
                {
                    _dict[nums[i]].Add(i);
                }
                else
                {
                    _dict.Add(nums[i], new List<int>());
                    _dict[nums[i]].Add(i);
                }
            }
        }

        public int Pick(int target)
        {
            var list = _dict[target];
            return list[_rand.Next(list.Count)];
        }
    }


    // Reservior sampling algorithm
    // O(n) retrieve time, O(1) space
    public class RandomPickIndex2
    {
        private int[] _nums;
        private Random _rand;

        public RandomPickIndex2(int[] nums)
        {
            _nums = nums;
            _rand = new Random();
        }

        public int Pick(int target)
        {
            var result = 0;
            int count = 0;
            for (int i = 0; i < _nums.Length; i++)
            {
                if (_nums[i] == target)
                {
                    count++;
                    if (_rand.Next(count) == 0)
                        result = i;
                }
            }
            return result;
        }
    }
}
