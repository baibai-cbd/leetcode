using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class BattleshipsInABoard
    {
        // 419. Battleships in a Board
        public int CountBattleships(char[][] board)
        {
            var count = 0;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == 'X')
                    {
                        count++;
                        DFSHelper(board, i, j);
                    }
                }
            }
            return count;
        }

        private void DFSHelper(char[][] board, int x, int y)
        {
            // Because each battleship is separated by at least one cell, 
            // we don't need to consider the direction when DFS, 
            // every adjacent cell must belongs to the same ship
            board[x][y] = '.';
            if (x - 1 >= 0 && board[x-1][y] == 'X')
            {
                DFSHelper(board, x - 1, y);
            }
            else if (y - 1 >= 0 && board[x][y-1] == 'X')
            {
                DFSHelper(board, x, y - 1);
            }
            else if (x + 1 < board.Length && board[x+1][y] == 'X')
            {
                DFSHelper(board, x + 1, y);
            }
            else if (y + 1 < board[0].Length && board[x][y+1] == 'X')
            {
                DFSHelper(board, x, y + 1);
            }
        }
    }
}
