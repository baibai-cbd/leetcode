using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class DistributeCandiesToPeople
    {
        // 1103. Distribute Candies to People
        public int[] DistributeCandies(int candies, int num_people)
        {
            var index = 0;
            var currCandy = 1;
            var remaining = candies;
            int[] array = new int[num_people];

            while (remaining > 0)
            {
                if (remaining >= currCandy)
                {
                    array[index] += currCandy;
                    remaining -= currCandy;
                }
                else
                {
                    array[index] += remaining;
                    remaining -= remaining;
                }
                if (index == array.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
                currCandy++;
            }
            return array;
        }
    }
}
