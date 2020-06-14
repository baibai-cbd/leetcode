using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class CheapestFlightsWithinKStops
    {
        // 787. Cheapest Flights Within K Stops
        // the dp[i][j] array here defines as:
        // The min cost from src to j node with at most i edges
        //
        // This problem can be solved with Dijkstra algorithm & Bellman Ford algorithm, try those next time
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            var dp = new int[K + 2][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n];
                Array.Fill(dp[i], int.MaxValue);
            }

            dp[0][src] = 0;
            for (int i = 1; i < K + 2; i++)
            {
                dp[i][src] = 0;
                foreach (var f in flights)
                {
                    if (dp[i-1][f[0]] != int.MaxValue)
                        dp[i][f[1]] = Math.Min(dp[i][f[1]], dp[i - 1][f[0]] + f[2]);
                }
            }

            return dp[K + 1][dst] == int.MaxValue ? -1 : dp[K + 1][dst];
        }
    }
}
