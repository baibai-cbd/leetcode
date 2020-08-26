using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MinimumCostForTickets
    {
        // 983. Minimum Cost For Tickets
        public int MincostTickets(int[] days, int[] costs)
        {
            var daysArray = new int[366];
            foreach (var d in days)
                daysArray[d] = 1;

            int max = days[^1];

            for (int i = 1; i <= max; i++)
            {
                if (daysArray[i] == 0)
                {
                    daysArray[i] = daysArray[i - 1];
                }
                else
                {
                    var cost1 = daysArray[i - 1] + costs[0];
                    var cost2 = i - 7 >= 0 ? daysArray[i - 7] + costs[1] : daysArray[0] + costs[1];
                    var cost3 = i - 30 >= 0 ? daysArray[i - 30] + costs[2] : daysArray[0] + costs[2];
                    daysArray[i] = Math.Min(cost1, Math.Min(cost2, cost3));
                }
            }
            return daysArray[max];
        }
    }
}
