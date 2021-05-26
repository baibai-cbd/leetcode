using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class TrappingRainWaterII
    {
        // 407. Trapping Rain Water II
        // This visualization video is amazing -> https://www.youtube.com/watch?v=cJayBq38VYw
        public int TrapRainWater(int[][] heightMap)
        {
            var m = heightMap.Length;
            var n = heightMap[0].Length;
            var visited = new bool[m][];
            var pq = new PriorityQueue<(int, int, int)>(Comparer<(int, int, int)>.Create((a, b) => a.Item1.CompareTo(b.Item1)));
            var currMax = 0;
            var result = 0;

            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            for (int i = 0; i < m; i++)
            {
                pq.Push((heightMap[i][0], i, 0));
                visited[i][0] = true;
                pq.Push((heightMap[i][n - 1], i, n - 1));
                visited[i][n - 1] = true;
            }

            for (int i = 0; i < n; i++)
            {
                pq.Push((heightMap[0][i], 0, i));
                visited[0][i] = true;
                pq.Push((heightMap[m - 1][i], m - 1, i));
                visited[m - 1][i] = true;
            }

            while (pq.Count > 0)
            {
                // only updating currMax when Popping
                var cell = pq.Pop();
                if (cell.Item1 > currMax)
                    currMax = cell.Item1;

                // handle the water increment when reaching neighbor cells
                // also add the neighbor cells to visited
                if (cell.Item2 - 1 >= 0)
                {
                    if (!visited[cell.Item2 - 1][cell.Item3])
                    {
                        if (heightMap[cell.Item2 - 1][cell.Item3] < currMax)
                            result += currMax - heightMap[cell.Item2 - 1][cell.Item3];

                        pq.Push((heightMap[cell.Item2 - 1][cell.Item3], cell.Item2 - 1, cell.Item3));
                        visited[cell.Item2 - 1][cell.Item3] = true;
                    }
                }

                if (cell.Item2 + 1 < m)
                {
                    if (!visited[cell.Item2 + 1][cell.Item3])
                    {
                        if (heightMap[cell.Item2 + 1][cell.Item3] < currMax)
                            result += currMax - heightMap[cell.Item2 + 1][cell.Item3];

                        pq.Push((heightMap[cell.Item2 + 1][cell.Item3], cell.Item2 + 1, cell.Item3));
                        visited[cell.Item2 + 1][cell.Item3] = true;
                    }
                }

                if (cell.Item3 - 1 >= 0)
                {
                    if (!visited[cell.Item2][cell.Item3 - 1])
                    {
                        if (heightMap[cell.Item2][cell.Item3 - 1] < currMax)
                            result += currMax - heightMap[cell.Item2][cell.Item3 - 1];

                        pq.Push((heightMap[cell.Item2][cell.Item3 - 1], cell.Item2, cell.Item3 - 1));
                        visited[cell.Item2][cell.Item3 - 1] = true;
                    }
                }

                if (cell.Item3 + 1 < n)
                {
                    if (!visited[cell.Item2][cell.Item3 + 1])
                    {
                        if (heightMap[cell.Item2][cell.Item3 + 1] < currMax)
                            result += currMax - heightMap[cell.Item2][cell.Item3 + 1];

                        pq.Push((heightMap[cell.Item2][cell.Item3 + 1], cell.Item2, cell.Item3 + 1));
                        visited[cell.Item2][cell.Item3 + 1] = true;
                    }
                }
            }

            return result;
        }
    }
}
