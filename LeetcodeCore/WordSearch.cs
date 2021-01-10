using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class WordSearch
    {
        // 79. Word Search
        public bool Exist(char[][] board, string word)
        {
            var list = new List<Tuple<int, int>>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == word[0]) list.Add(new Tuple<int, int>(i, j));
                }
            }

            if (list.Count == 0) return false;

            foreach (var point in list)
            {
                var result = DFS(board, word, 0, point.Item1, point.Item2);
                if (result) return true;
            }

            return false;
        }

        private bool DFS(char[][] board, string word, int wordIndex, int i, int j)
        {
            if (board[i][j] != word[wordIndex]) return false;
            if (board[i][j] == word[wordIndex] && wordIndex == word.Length - 1) return true;
            // bitwise operation to mark visited cell
            board[i][j] = (char)(board[i][j] ^ 0b1111_1111);
            //
            if (j + 1 < board[0].Length)
            {
                if (DFS(board, word, wordIndex + 1, i, j + 1)) return true;
            }
            if (i + 1 < board.Length)
            {
                if (DFS(board, word, wordIndex + 1, i + 1, j)) return true;
            }
            if (j - 1 >= 0)
            {
                if (DFS(board, word, wordIndex + 1, i, j - 1)) return true;
            }
            if (i - 1 >= 0)
            {
                if (DFS(board, word, wordIndex + 1, i - 1, j)) return true;
            }
            // if visited cells don't produce a true result, revert the cell to original status
            board[i][j] = (char)(board[i][j] ^ 0b1111_1111);
            //
            return false;
        }
    }
}
