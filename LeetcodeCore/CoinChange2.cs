using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
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

            var usefulCoins = coins.Where(c => c <= amount).ToArray();

            // this dpArr meaning is very tricky,
            // it's the number of combination of coins to build up current amount by using the current and/or later index coins(but not previous)
            dp = new int[usefulCoins.Length, amount+1];
            return ChangeRecursive(amount, usefulCoins, 0);
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

    public class CoinChange2BottomUp
    {
        // 518. Coin Change 2
        // Unbounded Knapsack problem
        // Bottom-up dp

        public int Change(int amount, int[] coins)
        {
            if (amount == 0)
                return 1;

            var usefulCoins = coins.Where(c => c <= amount).ToArray();

            // This dpArray meaning is tricky as well
            // it's the number of combination of coins to build up current amount by using the current and/or previous index coins(but not latter)
            var dpArr = new int[usefulCoins.Length + 1, amount + 1];
            dpArr[0, 0] = 1;
            for (int i = 0; i < usefulCoins.Length; i++)
            {
                for (int j = 0; j <= amount; j++)
                {
                    if (j >= usefulCoins[i])
                    {
                        // (previous coin at this amount) + (this coin at amount-currCoinAmount)
                        dpArr[i + 1, j] = dpArr[i, j] + dpArr[i + 1, j - usefulCoins[i]];
                    }
                    else
                    {
                        dpArr[i + 1, j] = dpArr[i, j];
                    }
                }
            }

            return dpArr[usefulCoins.Length, amount];
        }
    }
}
