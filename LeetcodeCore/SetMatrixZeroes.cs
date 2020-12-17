using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SetMatrixZeroes
    {
        // 73. Set Matrix Zeroes
        // TODO: Try O(1) solution next time
        public void SetZeroes(int[][] matrix)
        {
            var rows = new bool[matrix.Length];
            var columns = new bool[matrix[0].Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows[i] = true;
                        columns[j] = true;
                    }
                }
            }
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i])
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                        matrix[i][j] = 0;
                }
            }
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i])
                {
                    for (int j = 0; j < matrix.Length; j++)
                        matrix[j][i] = 0;
                }
            }
        }
    }
}
