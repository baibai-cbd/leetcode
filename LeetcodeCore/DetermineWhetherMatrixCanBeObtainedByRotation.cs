using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class DetermineWhetherMatrixCanBeObtainedByRotation
    {
        // 1886. Determine Whether Matrix Can Be Obtained By Rotation
        // this solution use a direct transformation on the rotation of matrix, effectly O(1) for each cell
        public bool FindRotation(int[][] mat, int[][] target)
        {
            var n = mat.Length;
            var flags = new bool[4];
            Array.Fill(flags, true);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // 0 degree rotation
                    if (mat[i][j] != target[i][j]) flags[0] = false;
                    // 90 degree clockwise(270 counter), transpose and y-axis-flip
                    if (mat[i][j] != target[j][n - 1 - i]) flags[1] = false;
                    // 180 degree clockwise, x-axis-flip and y-axis-flip
                    if (mat[i][j] != target[n - 1 - i][n - 1 - j]) flags[2] = false;
                    // 270 degree clockwise(90 counuter), transpose and x-axis-flip
                    if (mat[i][j] != target[n - 1 - j][i]) flags[3] = false;
                }
            }

            return flags[0] || flags[1] || flags[2] || flags[3];
        }
    }
}
