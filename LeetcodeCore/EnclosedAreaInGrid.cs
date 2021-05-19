using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class EnclosedAreaInGrid
    {
        // Comes up with this problem my self, idea is simple
        // any 0 enclosed by non-0 numbers(4-way) is counted as enclosed area, any 0 cell has a path towards the 4 boundaries are not enclosed
        // calculate the enclosed area in the grid
        public static int[][] _grid = new int[][]
        {
            new int[] { 0, 1, 0, 0, 0 },
            new int[] { 1, 0, 1, 0, 0 },
            new int[] { 0, 1, 0, 1, 0 },
            new int[] { 0, 0, 1, 0, 1 },
            new int[] { 0, 0, 0, 1, 0 }
        };

        public int CalculateEnclosedArea(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var totalCells = m * n;
            var uf = new UnionFind(totalCells + 3);

            // uf[totalCells] -> 0 cell that is not enclosed,
            // uf[totalCells + 1] -> wall cells(value >= 1),
            // uf[totalCells + 2] -> enclosed 0 cells

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] > 0)
                        uf.Union(i * n + j, totalCells + 1);

                    if (grid[i][j] == 0)
                    {
                        if (i == 0 || j == 0 || i == m-1 || j == n - 1)
                        {
                            uf.Union(i * n + j, totalCells);
                        }

                        if (i+1 < m && grid[i+1][j] == 0)
                        {
                            uf.Union(i * n + j, (i + 1) * n + j);
                        }
                        if (j+1 < n && grid[i][j+1] == 0)
                        {
                            uf.Union(i * n + j, i * n + j + 1);
                        }
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0 && !uf.Connected(i * n + j, totalCells))
                        uf.Union(i * n + j, totalCells + 2);
                }
            }

            return uf.FindSize(totalCells + 2) - 1;
        }
    }
}
