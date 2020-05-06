using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class BestTimeToBuyAndSellStockII
    {
        // 122. Best Time to Buy and Sell Stock II
        public int MaxProfit(int[] prices)
        {
            int[] profitArray = new int[prices.Length];
            profitArray[0] = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                profitArray[i] = (prices[i] - prices[i-1] > 0) ? (prices[i] - prices[i-1]) : 0; 
            }
            int totalProfit = 0;
            foreach (var p in profitArray)
            {
                totalProfit += p;
            }
            return totalProfit;
        }
    }
}
