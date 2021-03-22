using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SlidingWindowMaximum
    {
        // 239. Sliding Window Maximum
        // TODO: Use Monotonic Queue for thie problem next time
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var i = 0;
            var j = k-1;
            var resultList = new List<int>();
            var pq = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) =>
            {
                if (a.Item2.CompareTo(b.Item2) != 0)
                    return a.Item2.CompareTo(b.Item2);
                else
                    return a.Item1.CompareTo(b.Item1);
            }));

            for (int x = i; x <= j; x++)
            {
                pq.Add((x, nums[x]));
            }

            resultList.Add(pq.Max.Item2);

            for (int y = j + 1; y < nums.Length; y++)
            {
                pq.Remove((i, nums[i]));
                i++;
                pq.Add((y, nums[y]));
                resultList.Add(pq.Max.Item2);
            }

            return resultList.ToArray();
        }
    }
}
