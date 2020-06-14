using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class CheckIfItIsAStraightLine
    {
        // 1232. Check If It Is a Straight Line
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length == 2)
                return true;

            int[] point1 = coordinates[0];
            int[] point2 = coordinates[1];

            var a = point2[1] - point1[1];
            var b = point1[0] - point2[0];
            var c = a * point1[0] + b * point1[1];

            for (int i = 2; i < coordinates.Length; i++)
            {
                if (a * coordinates[i][0] + b * coordinates[i][1] != c)
                    return false;
            }

            return true;
        }
    }
}
