using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ItemsInContainers
    {
        public int[] NumberOfItems(string s, int[] startIndices, int[] endIndices)
        {
            int[] results = new int[startIndices.Length];
            var dict = new Dictionary<Tuple<int,int>, int>();
            var splittedArr = s.Split('|');
            var currIndex = splittedArr[0].Length + 1;  // add 1 to make indexes starting at 1, consistent with inputs

            for (int i = 1; i < splittedArr.Length - 1; i++) // don't count in the first/last unclosed intervals, hence starting at 1 and ending with -1
            {
                var currClosingIndex = currIndex + splittedArr[i].Length + 1;
                dict.Add(new Tuple<int, int>(currIndex, currClosingIndex), splittedArr[i].Length);
                currIndex = currClosingIndex;
            }

            for (int i = 0; i < startIndices.Length; i++)
            {
                var sum = 0;
                foreach (var kvp in dict)
                {
                    if (kvp.Key.Item1 >= startIndices[i] && kvp.Key.Item2 <= endIndices[i]) // only fully enclosed intervals are counted
                    {
                        sum += kvp.Value;
                    }
                }
                results[i] = sum;
            }

            return results;
        }
    }
}
