using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SplitArrayWithSameAverage
    {
        // 805. Split Array With Same Average
        // Pure DFS and cut branch solution, no memoization involved
        // TODO: Can write a leetcode post about it, pretty unique method I come up with
        public bool SplitArraySameAverage(int[] A)
        {
            if (A.Length <= 1)
                return false;

            var arrSize = A.Length;
            var sum = 0;
            foreach (var num in A)
                sum += num;

            Array.Sort(A);
            for (int i = arrSize / 2; i >= 1; i--)
            {
                if (i * sum % arrSize == 0 && DFS(A, i, i * sum / arrSize, 0))
                    return true;
            }

            return false;
        }

        private bool DFS(int[] arr, int size, int sum, int start)
        {
            if (size == 0)
                return sum == 0;

            var fullDFSFlag = false;

            for (int i = start; i < arr.Length - size + 1 && sum >= arr[i] * size; i++)
            {
                if (fullDFSFlag && arr[i] == arr[i - 1])
                    continue;
                if (DFS(arr, size - 1, sum - arr[i], i + 1))
                    return true;

                fullDFSFlag = true;
            }

            return false;
        }
    }
}
