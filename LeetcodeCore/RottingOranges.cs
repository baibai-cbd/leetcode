using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class RottingOranges
    {
        // 994. Rotting Oranges
        public int OrangesRotting(int[][] grid)
        {
            int days = 0;
            while (RotByDay(grid))
                days++;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) return -1;
                }
            }
            return days;
        }

        private bool RotByDay(int[][] grid)
        {
            var list = new List<Tuple<int, int>>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        if (i - 1 >= 0)
                        {
                            if (grid[i - 1][j] == 1)
                                list.Add(new Tuple<int, int>(i - 1, j));
                        }
                        if (j - 1 >= 0)
                        {
                            if (grid[i][j - 1] == 1)
                                list.Add(new Tuple<int, int>(i, j - 1));
                        }
                        if (i + 1 < grid.Length)
                        {
                            if (grid[i + 1][j] == 1)
                                list.Add(new Tuple<int, int>(i + 1, j));
                        }
                        if (j + 1 < grid[i].Length)
                        {
                            if (grid[i][j + 1] == 1)
                                list.Add(new Tuple<int, int>(i, j + 1));
                        }
                    }
                }
            }

            if (list.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var t in list)
                {
                    grid[t.Item1][t.Item2] = 2;
                }
                return true;
            }
        }
    }
}
