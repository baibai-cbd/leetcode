using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class PairsOfSongsWithTotalDurationsDivisibleBy60
    {
        // 1010. Pairs of Songs With Total Durations Divisible by 60
        public int NumPairsDivisibleBy60(int[] time)
        {
            var dict = new Dictionary<int, int>();
            var count = 0;

            foreach (var t in time)
            {
                count += dict.GetValueOrDefault((60 - t % 60) % 60, 0); // the last (%60) serves for when (t%60)==0
                if (dict.ContainsKey(t % 60))
                {
                    dict[t % 60]++;
                }
                else
                {
                    dict.Add(t % 60, 1);
                }
            }

            return count;
        }
    }
}
