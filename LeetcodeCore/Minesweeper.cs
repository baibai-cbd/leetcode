using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class Minesweeper
    {
        // 529. Minesweeper
        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            RevealCell(board, click[0], click[1]);
            return board;
        }

        public void RevealCell(char[][] board, int x, int y)
        {
            if (board[x][y] == 'M')
            {
                board[x][y] = 'X';
                return;
            }
            if (board[x][y] == 'E')
            {
                var count = 0;
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0)
                            continue;
                        if (x+i >= 0 && x+i < board.Length && y+j >=0 && y+j < board[0].Length)
                        {
                            if (board[x + i][y + j] == 'M') count++;
                        }
                    }
                }
                //
                board[x][y] = count == 0 ? 'B' : (char)(count + '0');   // (char)(count + '0') is better than count.ToString()[0]
                //
                if (board[x][y] == 'B')
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (i == 0 && j == 0)
                                continue;
                            if (x + i >= 0 && x + i < board.Length && y + j >= 0 && y + j < board[0].Length)
                            {
                                if (board[x + i][y + j] == 'E') RevealCell(board, x + i, y + j);
                            }
                        }
                    }
                }
            }
        }
    }
}
