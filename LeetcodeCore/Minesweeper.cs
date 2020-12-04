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
                if (x-1 >= 0 && y-1 >= 0)
                {
                    if (board[x - 1][y - 1] == 'M') count++;
                }
                if (x-1 >= 0)
                {
                    if (board[x - 1][y] == 'M') count++;
                }
                if (x-1 >= 0 && y+1 < board[0].Length)
                {
                    if (board[x - 1][y + 1] == 'M') count++;
                }
                if (y-1 >= 0)
                {
                    if (board[x][y - 1] == 'M') count++;
                }
                if (y+1 < board[0].Length)
                {
                    if (board[x][y + 1] == 'M') count++;
                }
                if (x+1 < board.Length && y-1 >= 0)
                {
                    if (board[x + 1][y - 1] == 'M') count++;
                }
                if (x+1 < board.Length)
                {
                    if (board[x + 1][y] == 'M') count++;
                }
                if (x+1 < board.Length && y+1 < board[0].Length)
                {
                    if (board[x + 1][y + 1] == 'M') count++;
                }
                //
                board[x][y] = count == 0 ? 'B' : count.ToString()[0];
                //
                if (board[x][y] == 'B')
                {
                    if (x - 1 >= 0 && y - 1 >= 0)
                    {
                        if (board[x - 1][y - 1] == 'E') RevealCell(board, x - 1, y - 1);
                    }
                    if (x - 1 >= 0)
                    {
                        if (board[x - 1][y] == 'E') RevealCell(board, x - 1, y);
                    }
                    if (x - 1 >= 0 && y + 1 < board[0].Length)
                    {
                        if (board[x - 1][y + 1] == 'E') RevealCell(board, x - 1, y + 1);
                    }
                    if (y - 1 >= 0)
                    {
                        if (board[x][y - 1] == 'E') RevealCell(board, x, y - 1);
                    }
                    if (y + 1 < board[0].Length)
                    {
                        if (board[x][y + 1] == 'E') RevealCell(board, x, y + 1);
                    }
                    if (x + 1 < board.Length && y - 1 >= 0)
                    {
                        if (board[x + 1][y - 1] == 'E') RevealCell(board, x + 1, y - 1);
                    }
                    if (x + 1 < board.Length)
                    {
                        if (board[x + 1][y] == 'E') RevealCell(board, x + 1, y);
                    }
                    if (x + 1 < board.Length && y + 1 < board[0].Length)
                    {
                        if (board[x + 1][y + 1] == 'E') RevealCell(board, x + 1, y + 1);
                    }
                }
            }
        }
    }
}
