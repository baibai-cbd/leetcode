using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class CoinChange2
    {
        // 518. Coin Change 2
        // Unbounded Knapsack problem
        // Top-down dp, next time try bottom up dp
        private int[,] dp;

        public int Change(int amount, int[] coins)
        {
            if (amount == 0)
                return 1;

            dp = new int[coins.Length, amount+1];
            return ChangeRecursive(amount, coins, 0);
        }

        private int ChangeRecursive(int amount, int[] coins, int index)
        {
            if (amount == 0)
                return 1;

            if (amount < 0 || index == coins.Length)
                return 0;

            if (dp[index, amount] != 0)
                return dp[index, amount];

            var sum1 = ChangeRecursive(amount - coins[index], coins, index);
            var sum2 = ChangeRecursive(amount, coins, index + 1);

            dp[index, amount] = sum1 + sum2;
            return dp[index, amount];
        }
    }
}
