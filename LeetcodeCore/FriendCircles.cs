using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class FriendCircles
    {
        // 547. Friend Circles
        public int FindCircleNum(int[][] M)
        {
            var visited = new int[M.Length];
            var groupCount = M.Length;
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == 0)
                {
                    DFS(M, visited, i, ref groupCount);
                }
            }
            return groupCount;
        }

        private void DFS(int[][] M, int[] visited, int i, ref int groupCount)
        {
            for (int j = 0; j < visited.Length; j++)
            {
                if (M[i][j] == 1 && visited[j] == 0)
                {
                    visited[j] = 1;
                    if (i != j) groupCount--;
                    DFS(M, visited, j, ref groupCount);
                }
            }
        }
    }
}
