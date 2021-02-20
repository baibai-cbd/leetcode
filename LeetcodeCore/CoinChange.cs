using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class CoinChangeSolution
    {
        // 322. Coin Change
        // one of Knapsack problems, very tricky
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0)
                return 0;

            var usefulCoins = coins.Where(c => c <= amount).ToArray();
            // the meaning of the dpArr is the Minimum number of coins to build up the current amount
            var dpArr = new int[amount + 1];
            for (int j = 0; j < amount + 1; j++)
            {
                dpArr[j] = amount + 10;
            }
            dpArr[0] = 0;

            // starts with 1 coin, build result
            // adds another coin, try to improve the result by taking Math.Min of with/without the current coin
            foreach (var coin in usefulCoins)
            {
                for (int i = 0; i < amount + 1; i++)
                {
                    if (i - coin >= 0)
                        dpArr[i] = Math.Min(dpArr[i - coin] + 1, dpArr[i]);
                }
            }

            return dpArr[amount] > amount ? -1 : dpArr[amount];
        }
    }
}
