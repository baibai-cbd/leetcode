using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class CyclicallyRotatingAGrid
    {
        // 1914. Cyclically Rotating a Grid
        public int[][] RotateGrid(int[][] grid, int k)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            int p = 0;

            while (m > 0 && n > 0)
            {
                RotateByK(grid, p, p, m, n, k);
                m -= 2;
                n -= 2;
                p++;
            }

            return grid;
        }

        private void RotateByK(int[][] grid, int i, int j, int m, int n, int k)
        {
            var queue = new Queue<int>();
            var total = m * 2 + n * 2 - 4;
            var finalK = k % total;
            if (finalK == 0)
                return;

            var rightBound = j + n - 1;
            for (; j < rightBound; j++) queue.Enqueue(grid[i][j]);
            var lowerBound = i + m - 1;
            for (; i < lowerBound; i++) queue.Enqueue(grid[i][j]);
            var leftBound = j - n + 1;
            for (; j > leftBound; j--) queue.Enqueue(grid[i][j]);
            var upperBound = i - m + 1;
            for (; i > upperBound; i--) queue.Enqueue(grid[i][j]);

            while (finalK > 0)
            {
                var temp = queue.Dequeue();
                queue.Enqueue(temp);
                finalK--;
            }

            for (; j < rightBound; j++) grid[i][j] = queue.Dequeue();
            for (; i < lowerBound; i++) grid[i][j] = queue.Dequeue();
            for (; j > leftBound; j--) grid[i][j] = queue.Dequeue();
            for (; i > upperBound; i--) grid[i][j] = queue.Dequeue();
        }
    }
}
