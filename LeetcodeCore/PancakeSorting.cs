using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class PancakeSorting
    {
        // 969. Pancake Sorting
        // 1 <= arr[i] <= arr.length
        // All integers in arr are unique(i.e.arr is a permutation of the integers from 1 to arr.length).
        public IList<int> PancakeSort(int[] arr)
        {
            var results = new List<int>();

            for (int i = arr.Length; i > 0; i--)
            {
                var startIndex = Array.IndexOf(arr, i);
                if (startIndex == i - 1)
                {
                    continue;
                }
                if (startIndex != 0)
                {
                    Array.Reverse(arr, 0, startIndex + 1);
                    results.Add(startIndex + 1);
                }
                Array.Reverse(arr, 0, i);
                results.Add(i);
            }

            return results;
        }
    }
}
