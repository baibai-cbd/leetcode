using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class NumberOfDistinctIslands
    {
        // 694. Number of Distinct Islands
        public int NumDistinctIslands(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            var pointHashSet = new HashSet<(int, int)>();
            var shapeHashSet = new HashSet<string>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1 && !pointHashSet.Contains((i,j)))
                    {
                        var stringBuilder = new StringBuilder();
                        DFSFind(grid, m, n, pointHashSet, i, j, stringBuilder, '*');
                        if (!shapeHashSet.Contains(stringBuilder.ToString()))
                            shapeHashSet.Add(stringBuilder.ToString());
                    }
                }
            }

            return shapeHashSet.Count;
        }

        private void DFSFind(int[][] grid, int m, int n, HashSet<(int, int)> phs, int i, int j, StringBuilder sb, char direction)
        {
            if (i < 0 || j < 0 || i >= m || j >= n)
                return;
            if (grid[i][j] == 0)
                return;
            if (phs.Contains((i, j)))
                return;

            phs.Add((i, j));
            sb.Append(direction);

            DFSFind(grid, m, n, phs, i, j + 1, sb, 'D');
            DFSFind(grid, m, n, phs, i + 1, j, sb, 'S');
            DFSFind(grid, m, n, phs, i, j - 1, sb, 'A');
            DFSFind(grid, m, n, phs, i - 1, j, sb, 'W');

            sb.Append('/');
            // need to track back to differentiate between --- and ---
            //                                             -         -
        }
    }
}
