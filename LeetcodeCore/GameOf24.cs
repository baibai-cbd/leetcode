using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class GameOf24
    {
        // 679. 24 Game
        // This problem is pretty hard, need to understand because we are considering all combinations,
        // the order of computation doesn't matter because the reverse combination would get selected as well
        private const double _errorMargin = 0.01;
        public bool JudgePoint24(int[] nums)
        {
            var numsList = nums.Select(x => (double)x).ToList();

            return Backtrack(numsList);
        }

        private bool Backtrack(IList<double> nums)
        {
            if (nums.Count == 1)
                return Math.Abs(nums[0] - 24) <= _errorMargin;

            for (int i = 0; i <= nums.Count; i++)
            {
                for (int j = i+1; j < nums.Count; j++)
                {
                    var a = nums[i];
                    var b = nums[j];

                    var computedValues = new List<double>() { a+b, a-b, b-a, a*b, a/b, b/a };

                    var copyNums = new List<double>(nums);
                    copyNums.RemoveAt(j);
                    copyNums.RemoveAt(i);

                    foreach (var value in computedValues)
                    {
                        copyNums.Add(value);
                        if (Backtrack(copyNums))
                            return true;
                        copyNums.RemoveAt(copyNums.Count - 1);
                    }
                }
            }
            return false;
        }
    }
}
