using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class ValidTicTacToeState
    {
        // 794. Valid Tic-Tac-Toe State
        public bool ValidTicTacToe(string[] board)
        {
            var longString = string.Join("", board);

            int[][] winList = {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 }
            };
            var countX = 0;
            var countO = 0;
            foreach (var c in longString)
            {
                if (c == 'X')
                {
                    countX++;
                }
                if (c == 'O')
                {
                    countO++;
                }
            }
            if (countO > countX || countX - 1 > countO || countO + countX > 9)
            {
                return false;
            }

            foreach (var combo in winList)
            {
                if (longString[combo[0]] == longString[combo[1]] && longString[combo[1]] == longString[combo[2]])
                {
                    if ((longString[combo[0]] == 'O' && countX > countO) || (longString[combo[0]] == 'X' && countX == countO))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
