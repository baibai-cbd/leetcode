using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class NumberOfIslands
    {
        // 200. Number of Islands
        public int NumIslands(char[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var index = 0;
            var hashSet = new HashSet<Tuple<int, int>>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        if (hashSet.Contains(new Tuple<int, int>(i, j)))
                        {
                            continue;
                        }
                        else
                        {
                            index++;
                            RecursiveFind(grid, m, n, hashSet, i, j);
                        }
                    }
                }
            }

            return index;
        }

        private void RecursiveFind(char[][] grid, int m, int n, HashSet<Tuple<int, int>> hs, int i, int j)
        {
            if (i < 0 || i == m || j < 0 || j == n)
                return;
            if (grid[i][j] == '0')
                return;
            if (hs.Contains(new Tuple<int, int>(i, j)))
                return;

            hs.Add(new Tuple<int, int>(i, j));

            RecursiveFind(grid, m, n, hs, i, j + 1);
            RecursiveFind(grid, m, n, hs, i + 1, j);
            RecursiveFind(grid, m, n, hs, i, j - 1);
            RecursiveFind(grid, m, n, hs, i - 1, j);
        }
    }
}
