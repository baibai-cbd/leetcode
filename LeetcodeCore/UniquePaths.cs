using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class UniquePathsSolution
    {
        // 62. Unique Paths
        public int UniquePaths(int m, int n)
        {
            var grid = new int[m][];
            for (int i = 0; i < m; i++)
            {
                grid[i] = new int[n];
            }

            grid[0][0] = 1;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var temp = grid[i][j];
                    if (i - 1 >= 0)
                        temp += grid[i - 1][j];
                    if (j - 1 >= 0)
                        temp += grid[i][j - 1];
                    grid[i][j] = temp;
                }
            }

            return grid[m - 1][n - 1];
        }
    }
}
