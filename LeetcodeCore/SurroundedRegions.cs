using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SurroundedRegions
    {
        // 130. Surrounded Regions
        // This solution with Union-find, very hard-core algorithm
        public void Solve(char[][] board)
        {
            var m = board.Length;
            var n = board[0].Length;
            var totalLength = m * n;
            var uf = new UnionFind(totalLength + 1); // one extra cell for initial connectivity

            // input perimeter cells
            for (int i = 0; i < n; i++)
            {
                if (board[0][i] == 'O')
                    uf.Union(i, totalLength);
                if (board[m - 1][i] == 'O')
                    uf.Union((m - 1) * n + i, totalLength);
            }
            for (int j = 0; j < m; j++)
            {
                if (board[j][0] == 'O')
                    uf.Union(j * n, totalLength);
                if (board[j][n - 1] == 'O')
                    uf.Union(j * n + n - 1, totalLength);
            }

            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (board[x][y] != 'O') continue;
                    if (x - 1 >= 0 && board[x - 1][y] == 'O') uf.Union(x * n + y, (x - 1) * n + y);
                    if (x + 1 < m && board[x + 1][y] == 'O') uf.Union(x * n + y, (x + 1) * n + y);
                    if (y - 1 >= 0 && board[x][y - 1] == 'O') uf.Union(x * n + y, x * n + y - 1);
                    if (y + 1 < n && board[x][y + 1] == 'O') uf.Union(x * n + y, x * n + y + 1);
                }
            }

            for (int x = 1; x < m-1; x++)
            {
                for (int y = 1; y < n-1; y++)
                {
                    if (board[x][y] == 'O' && !uf.Connected(x * n + y, totalLength))
                        board[x][y] = 'X';
                }
            }
        }
    }
}
