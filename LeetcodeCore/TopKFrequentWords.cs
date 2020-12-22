using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class TopKFrequentWords
    {
        // 692. Top K Frequent Words
        public IList<string> TopKFrequent(string[] words, int k)
        {
            var dict = new Dictionary<string, int>();
            var pq = new SortedSet<Tuple<int, string>>(Comparer<Tuple<int, string>>.Create(
                (a, b) => {
                    if (a.Item1 != b.Item1)
                        return a.Item1.CompareTo(b.Item1);
                    else
                        return b.Item2.CompareTo(a.Item2);
                }));

            foreach (var w in words)
            {
                if (dict.ContainsKey(w))
                    dict[w]++;
                else
                    dict.Add(w, 1);
            }

            foreach (var entry in dict)
            {
                pq.Add(new Tuple<int, string>(entry.Value, entry.Key));
                if (pq.Count > k)
                    pq.Remove(pq.Min);
            }

            var results = new List<string>();
            while (pq.Count > 0)
            {
                results.Add(pq.Max.Item2);
                pq.Remove(pq.Max);
            }

            return results;
        }
    }
}
