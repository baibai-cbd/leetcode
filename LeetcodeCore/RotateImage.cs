using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class RotateImage
    {
        // 48. Rotate Image
        // Diagonally flip it and vertically flip it to solve this next time
        public void Rotate(int[][] matrix)
        {
            var n = matrix.Length;
            if (n == 1)
                return;

            // diagonally flipping
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++) // mind the loop condition should stop at the flipping axis
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            // vertically flipping
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n/2; j++) // mind the loop condition should stop at the flipping axis
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - 1 - j];
                    matrix[i][n - 1 - j] = temp;
                }
            }
        }
    }
}
