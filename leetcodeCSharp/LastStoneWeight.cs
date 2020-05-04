using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class LastStoneWeightSolution
    {
        // 1046. Last Stone Weight
        // using bucket sort
        public int LastStoneWeight(int[] stones)
        {
            int[] buckets = new int[1001];
            foreach (var item in stones)
            {
                buckets[item]++;
            }

            int i = 1000;
            int j;
            while (i>0)
            {
                if (buckets[i]==0)
                {
                    i--;
                }
                else
                {
                    buckets[i] = buckets[i] % 2;
                    if (buckets[i]!=0)
                    {
                        j = i - 1;
                        while (j>0 && buckets[j]==0)
                        {
                            j--;
                        }
                        if (j==0)
                        {
                            return i;
                        }
                        buckets[i - j]++;
                        buckets[j]--;
                        buckets[i]--;
                        i--;
                    }
                }
            }
            return 0;
        }
    }
}
