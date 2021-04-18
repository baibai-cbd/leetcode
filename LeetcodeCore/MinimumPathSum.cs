using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MinimumPathSum
    {
        // 64. Minimum Path Sum
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            var newGrid = new int[m][];
            for (int i = 0; i < m; i++)
            {
                newGrid[i] = new int[n];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var leftSum = InGridRange(i, j - 1, m, n) ? newGrid[i][j - 1] : int.MaxValue;
                    var topSum = InGridRange(i - 1, j, m, n) ? newGrid[i - 1][j] : int.MaxValue;
                    if (leftSum == int.MaxValue && leftSum == topSum)
                        newGrid[i][j] = grid[i][j];
                    else
                        newGrid[i][j] = grid[i][j] + Math.Min(leftSum, topSum);
                }
            }

            return newGrid[m - 1][n - 1];
        }

        private bool InGridRange(int x, int y, int m, int n)
            => x >= 0 && x < m && y >= 0 && y < n;
    }
}
