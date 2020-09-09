using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class PartitionLabelsSolution
    {
        // 763. Partition Labels
        public IList<int> PartitionLabels(string S)
        {
            var list = new List<int>();
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < S.Length; i++)
            {
                if (dict.ContainsKey(S[i]))
                {
                    dict[S[i]] = i;
                }
                else
                {
                    dict.Add(S[i], i);
                }
            }

            var lastStart = 0;
            var j = 0;
            var k = 0;
            while (j < S.Length && k < S.Length)
            {
                k = dict[S[j]];
                while (j < k)
                {
                    var lastIndex = dict[S[j]];
                    if (lastIndex > k)
                    {
                        k = lastIndex;
                    }
                    j++;
                }
                if (j == k)
                {
                    list.Add(j - lastStart + 1);
                    j++;
                    lastStart = j;
                    k++;
                }
            }
            return list;
        }
    }
}
