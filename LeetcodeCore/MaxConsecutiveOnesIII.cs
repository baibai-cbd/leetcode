using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MaxConsecutiveOnesIII
    {
        // 1004. Max Consecutive Ones III
        // Two Pointers/Sliding windows seem much better by looping with ForLoop with clear boundary 
        // rather than with WhileLoop which you may need to check for boundary a lot of times in the process
        public int LongestOnes(int[] A, int K)
        {
            var indexI = 0;
            var indexJ = 0;
            var currZeros = 0;
            var max = 0;

            for (indexJ = 0; indexJ < A.Length; indexJ++)
            {
                currZeros += 1 - A[indexJ];

                while (currZeros > K && indexI < indexJ)
                {
                    currZeros -= 1 - A[indexI];
                    indexI++;
                }

                if (currZeros <= K)
                {
                    max = Math.Max(max, indexJ - indexI + 1);
                }
            }

            return max;
        }
    }
}
