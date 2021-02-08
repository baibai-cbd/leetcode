using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class UniquePathsII
    {
        // 63. Unique Paths II
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var x = obstacleGrid.Length;
            var y = obstacleGrid[0].Length;
            // handle special cases that start point or end point is obstacle
            if (obstacleGrid[0][0] == 1 || obstacleGrid[x - 1][y - 1] == 1)
                return 0;

            obstacleGrid[0][0] = -1;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        obstacleGrid[i][j] = 0;
                    }
                    else if (obstacleGrid[i][j] == 0)
                    {
                        var temp = 0;
                        if (i - 1 >= 0)
                        {
                            temp += obstacleGrid[i - 1][j];
                        }
                        if (j - 1 >= 0)
                        {
                            temp += obstacleGrid[i][j - 1];
                        }
                        obstacleGrid[i][j] = temp;
                    }
                    else
                    {
                        obstacleGrid[i][j] *= -1; 
                    }
                }
            }

            return obstacleGrid[x - 1][y - 1];
        }
    }
}
