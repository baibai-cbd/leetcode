using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class MaxChunksToMakeSortedII
    {
        // 768. Max Chunks To Make Sorted II
        // sliding window with a sorted copy, check match only if current key's value is zero
        public int MaxChunksToSorted(int[] arr)
        {
            var copyArr = new int[arr.Length];
            Array.Copy(arr, copyArr, arr.Length);
            Array.Sort(copyArr);

            var j = 0;
            var dict = new Dictionary<int, int>();
            var result = 0;

            for (j = 0; j < copyArr.Length; j++)
            {
                if (dict.ContainsKey(arr[j]))
                    dict[arr[j]]--;
                else
                    dict.Add(arr[j], -1);

                if (dict.ContainsKey(copyArr[j]))
                    dict[copyArr[j]]++;
                else
                    dict.Add(copyArr[j], 1);

                var matchFlag = false;

                if (dict[copyArr[j]] == 0)
                    matchFlag = CheckDictAllZeroes(dict);

                if (matchFlag)
                {
                    result++;
                    dict.Clear();
                }
            }

            return result;
        }

        private bool CheckDictAllZeroes(Dictionary<int, int> dict)
            => dict.All(kvp => kvp.Value == 0);
    }
}
