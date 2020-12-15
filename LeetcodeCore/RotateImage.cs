using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class RotateImage
    {
        // 48. Rotate Image
        // TODO: Try to diagonally flip it and vertically flip it to solve this next time
        public void Rotate(int[][] matrix)
        {
            if (matrix.Length == 1)
                return;

            if (matrix.Length % 2 == 1)
            {
                int halfLength = matrix.Length / 2;
                int[] center = { halfLength, halfLength };
                for (int i = -halfLength; i < 0; i++)
                {
                    for (int j = i; j < -i; j++)
                    {
                        int[] point1 = { i, j };
                        int[] point2 = Clockwise90Transformation(point1);
                        int[] point3 = Clockwise90Transformation(point2);
                        int[] point4 = Clockwise90Transformation(point3);
                        //
                        var temp = matrix[center[0] + point4[0]][center[1] + point4[1]];
                        //
                        matrix[center[0] + point4[0]][center[1] + point4[1]] = matrix[center[0] + point3[0]][center[1] + point3[1]];
                        matrix[center[0] + point3[0]][center[1] + point3[1]] = matrix[center[0] + point2[0]][center[1] + point2[1]];
                        matrix[center[0] + point2[0]][center[1] + point2[1]] = matrix[center[0] + point1[0]][center[1] + point1[1]];
                        matrix[center[0] + point1[0]][center[1] + point1[1]] = temp;
                    }
                }
            }
            else
            {
                var halfLength = matrix.Length / 2;
                int[] center1 = { halfLength - 1, halfLength - 1 };
                int[] center2 = { halfLength - 1, halfLength };
                int[] center3 = { halfLength, halfLength };
                int[] center4 = { halfLength, halfLength - 1 };

                for (int i = -(halfLength - 1); i <= 0; i++)
                {
                    for (int j = -(halfLength - 1); j <= 0; j++)
                    {
                        int[] point1 = { i, j };
                        int[] point2 = Clockwise90Transformation(point1);
                        int[] point3 = Clockwise90Transformation(point2);
                        int[] point4 = Clockwise90Transformation(point3);
                        //
                        var temp = matrix[center4[0] + point4[0]][center4[1] + point4[1]];
                        //
                        matrix[center4[0] + point4[0]][center4[1] + point4[1]] = matrix[center3[0] + point3[0]][center3[1] + point3[1]];
                        matrix[center3[0] + point3[0]][center3[1] + point3[1]] = matrix[center2[0] + point2[0]][center2[1] + point2[1]];
                        matrix[center2[0] + point2[0]][center2[1] + point2[1]] = matrix[center1[0] + point1[0]][center1[1] + point1[1]];
                        matrix[center1[0] + point1[0]][center1[1] + point1[1]] = temp;
                    }
                }
            }
        }

        private int[] Clockwise90Transformation(int[] coordinates)
        {
            return new int[] { coordinates[1], coordinates[0] * -1 };
        }
    }
}
