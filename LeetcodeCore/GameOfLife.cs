using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class GameOfLifeSolution
    {
        // 289. Game of Life
        public void GameOfLife(int[][] board)
        {

            var m = board.Length;
            var n = board[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var neighborCount = CheckNeighbors(board, m, n, i, j);

                    if (board[i][j] == 1)
                    {
                        if (neighborCount < 2 || neighborCount > 3)
                            board[i][j] = -1;
                    }
                    else
                    {
                        if (neighborCount == 3)
                            board[i][j] = 2;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == -1)
                        board[i][j] = 0;
                    if (board[i][j] == 2)
                        board[i][j] = 1;
                }
            }
        }

        private int CheckNeighbors(int[][] board, int m, int n, int i, int j)
        {
            var count = 0;
            for (int p = i - 1; p <= i + 1; p++)
            {
                for (int q = j - 1; q <= j + 1; q++)
                {
                    if (p < 0 || p >= m || q < 0 || q >= n)
                        continue;

                    if (p == i && q == j)
                        continue;

                    if (board[p][q] == 1 || board[p][q] == -1)
                        count++;
                }
            }

            return count;
        }
    }
}
