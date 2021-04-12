using System.Collections.Generic;
using System.Linq;

namespace LeetcodeCore
{
    public class TopKFrequentElements
    {
        // 347. Top K Frequent Elements
        // bucket sort methodology, pretty good performance
        public int[] TopKFrequent2(int[] nums, int k)
        {
            var buckets = new List<int>[nums.Length + 1];
            var dict = new Dictionary<int, int>();
            var results = new List<int>();

            foreach (var n in nums)
            {
                if (dict.ContainsKey(n))
                    dict[n]++;
                else
                    dict.Add(n, 1);
            }

            foreach (var kv in dict)
            {
                if (buckets[kv.Value] == null)
                    buckets[kv.Value] = new List<int>();
                buckets[kv.Value].Add(kv.Key);
            }

            for (int i = buckets.Length - 1; i > 0 && k > 0; i--)
            {
                if (buckets[i] != null)
                {
                    while (k > 0 && buckets[i].Count > 0)
                    {
                        results.Add(buckets[i][^1]);
                        buckets[i].RemoveAt(buckets[i].Count - 1);
                        k--;
                    }
                }
            }

            return results.ToArray();
        }

        // this solution with SortedSet is not good in performance
        public int[] TopKFrequent(int[] nums, int k)
        {
            var sortedSet = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) =>
            {
                if (a.Item2.CompareTo(b.Item2) != 0)
                    return a.Item2.CompareTo(b.Item2);
                else
                    return a.Item1.CompareTo(b.Item1);
            }));
            var countDict = new Dictionary<int, int>();

            foreach (var n in nums)
            {
                if (countDict.ContainsKey(n))
                    countDict[n]++;
                else
                    countDict.Add(n, 1);

                if (sortedSet.Contains((n, countDict[n] - 1)))
                {
                    sortedSet.Remove((n, countDict[n] - 1));
                    sortedSet.Add((n, countDict[n]));
                }
                else
                {
                    if (sortedSet.Count < k)
                    {
                        sortedSet.Add((n, countDict[n]));
                    }
                    else if (countDict[n] > sortedSet.Min.Item2)
                    {
                        sortedSet.Remove(sortedSet.Min);
                        sortedSet.Add((n, countDict[n]));
                    }
                }
            }

            return sortedSet.Select(x => x.Item1).ToArray();
        }
    }
}
