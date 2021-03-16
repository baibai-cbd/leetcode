using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class BestTimeToBuyAndSellStock
    {
        // 121. Best Time to Buy and Sell Stock
        public int MaxProfit(int[] prices)
        {
            var profitArr = new int[prices.Length];
            profitArr[0] = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                profitArr[i] = prices[i] - prices[i - 1];
            }

            var max = 0;
            var currProfit = 0;
            for (int j = 0; j < prices.Length; j++)
            {
                currProfit = Math.Max(currProfit + profitArr[j], 0);
                max = Math.Max(currProfit, max);
            }

            return max;
        }
    }
}
