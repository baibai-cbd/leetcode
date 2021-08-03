using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class UniqueBinarySearchTrees
    {
        // 96. Unique Binary Search Trees
        // This botton-up solution is very nice
        public int NumTrees(int n)
        {
            var results = BottomUpGenerateArray(n);
            return results[n];
        }

        private int[] BottomUpGenerateArray(int n)
        {
            var array = new int[n + 1];
            array[0] = 1;
            array[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                var tempSum = 0;
                for (int j = 1; j <= i; j++)
                {
                    // each left tree result should be multiplied with right tree result
                    // each node as root result should be summed up
                    tempSum += array[j - 1] * array[i - j];
                }
                array[i] = tempSum;
            }

            return array;
        }
    }
}
