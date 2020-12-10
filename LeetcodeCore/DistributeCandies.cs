using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class DistributeCandiesSolution
    {
        // 575. Distribute Candies
        public int DistributeCandies(int[] candyType)
        {
            var hs = new HashSet<int>();
            var half = candyType.Length / 2;

            for (int i = 0; i < candyType.Length; i++)
            {
                hs.Add(candyType[i]);
                if (hs.Count == half)
                    break;
            }
            return hs.Count;
        }
    }
}
