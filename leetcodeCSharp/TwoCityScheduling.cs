using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class TwoCityScheduling
    {
        // 1029. Two City Scheduling
        public int TwoCitySchedCost(int[][] costs)
        {
            var absDiffs = new Tuple<int, int>[costs.Length];
            for (int i = 0; i < costs.Length; i++)
            {
                absDiffs[i] = new Tuple<int, int>(i, Math.Abs(costs[i][0] - costs[i][1]));
            }
            Array.Sort(absDiffs, (d1, d2) => d2.Item2 - d1.Item2);

            var n = costs.Length / 2;
            var city1Index = 0;
            var city2Index = 0;
            var sum = 0;
            for (int j = 0; j < absDiffs.Length; j++)
            {
                if (costs[absDiffs[j].Item1][0] < costs[absDiffs[j].Item1][1])
                {
                    if (city1Index < n)
                    {
                        city1Index++;
                        sum += costs[absDiffs[j].Item1][0];
                    }
                    else
                    {
                        city2Index++;
                        sum += costs[absDiffs[j].Item1][1];
                    }
                }
                else
                {
                    if (city2Index < n)
                    {
                        city2Index++;
                        sum += costs[absDiffs[j].Item1][1];
                    }
                    else
                    {
                        city1Index++;
                        sum += costs[absDiffs[j].Item1][0];
                    }
                }
            }
            return sum;
        }
    }
}
