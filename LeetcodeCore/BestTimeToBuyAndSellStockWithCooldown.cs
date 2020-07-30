using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class BestTimeToBuyAndSellStockWithCooldown
    {
        // 309. Best Time to Buy and Sell Stock with Cooldown
        public int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1)
                return 0;
            var s0 = new int[prices.Length]; // without stock after cooldown or hold cash (think cooldown as a transition)
            var s1 = new int[prices.Length]; // with stock after hold stock or buy
            var s2 = new int[prices.Length]; // without stock after sell
            s0[0] = 0;
            s1[0] = -prices[0];
            s2[0] = int.MinValue;
            for (int i = 1; i < prices.Length; i++)
            {
                s0[i] = Math.Max(s0[i - 1], s2[i - 1]);
                s1[i] = Math.Max(s1[i - 1], s0[i - 1] - prices[i]);
                s2[i] = s1[i - 1] + prices[i];
            }
            return Math.Max(s0[prices.Length - 1], s2[prices.Length - 1]);
        }
    }
}
