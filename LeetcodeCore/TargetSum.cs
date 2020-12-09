using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class TargetSum
    {
        // 494. Target Sum
        
        // DFS better solution
        public int FindTargetSumWays(int[] nums, int S)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            return DFSHelper(nums, 0, S);
        }

        private int DFSHelper(int[] nums, int index, int sum)
        {
            if (index == nums.Length)
                return sum == 0 ? 1 : 0;

            var currNum = nums[index];
            var add = DFSHelper(nums, index + 1, sum - currNum); // add means this num is positive in the sum, thus minus it to get remaining sum
            var minus = DFSHelper(nums, index + 1, sum + currNum);
            return add + minus;
        }


        // Pretty bad solution
        public int FindTargetSumWays2(int[] nums, int S)
        {
            if (nums.Length == 1)
                return nums[0] == Math.Abs(S) ? 1 : 0;

            var listOfLists = new List<IList<int>>(nums.Length);
            listOfLists.Add(new List<int>() { nums[0], nums[0] * -1 });

            for (int i = 1; i < nums.Length; i++)
            {
                var currList = new List<int>();
                var lastList = listOfLists[i - 1];
                foreach (var item in lastList)
                {
                    currList.Add(item + nums[i]);
                    currList.Add(item - nums[i]);
                }
                listOfLists.Add(currList);
            }

            var result = listOfLists[nums.Length - 1].Count(x => x == S);
            return result;
        }
    }
}
