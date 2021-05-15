using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MaxAreaOfIslandSolution
    {
        // 695. Max Area of Island
        public int MaxAreaOfIsland(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var totalLength = m * n;
            var uf = new UnionFind(totalLength + 1);
            var maxArea = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        uf.Union(i * n + j, totalLength);
                    }
                    else
                    {
                        if (j + 1 < n && grid[i][j + 1] == 1)
                        {
                            uf.Union(i * n + j, i * n + j + 1);
                        }
                        if (i + 1 < m && grid[i + 1][j] == 1)
                        {
                            uf.Union((i + 1) * n + j, i * n + j);
                        }
                        maxArea = Math.Max(maxArea, uf.FindSize(i * n + j));
                    }
                }
            }

            return maxArea;
        }
    }
}
