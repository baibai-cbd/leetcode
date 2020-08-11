using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class HIndexSolution
    {
        // 274. H-Index
        public int HIndex(int[] citations)
        {
            Array.Sort(citations);
            var list = citations.Reverse().ToArray();
            int potentialH = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] > i + 1)
                {
                    potentialH = i + 1;
                    continue;
                }
                if (list[i] == i + 1)
                {
                    return i + 1;
                }
                if (list[i] < i + 1)
                {
                    return Math.Max(list[i], potentialH);
                }
            }
            return potentialH;
        }
    }
}
