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


        // Good solution by converting it to a Knapsack problem(DP)
        public int FindTargetSumWays3(int[] nums, int S)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int n = nums.Length;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
            }
            if (sum < S || (sum + S) % 2 == 1)
            {
                return 0;
            }
            // How does this problem converts to Knapsack problem?
            // if we split the nums into 2 sets A and B, then we have sum(A) + S = sum(B)
            // since sum(A) is int, S is int, sum(A) + S + sum(B) must be even
            // Thus we can use sum(A union B) / 2 as target number
            int W = (sum + S) / 2;
            var dpArr = new int[nums.Length + 1, W + 1];
            dpArr[0, 0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = W; j >= 0; j--)
                {
                    if (j >= nums[i])
                    {
                        dpArr[i + 1, j] = dpArr[i, j] + dpArr[i, j - nums[i]];
                    }
                    else
                    {
                        dpArr[i + 1, j] = dpArr[i, j];
                    }
                }
            }

            return dpArr[n, W];
        }
    }
}
