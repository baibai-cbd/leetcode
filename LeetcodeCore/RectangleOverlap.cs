using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class RectangleOverlap
    {
        // 836. Rectangle Overlap
        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            // return false if it's not a rectangle
            if (rec1[2] - rec1[0] == 0 || rec1[3] - rec1[1] == 0)
                return false;
            if (rec2[2] - rec2[0] == 0 || rec2[3] - rec2[1] == 0)
                return false;

            var flagX = CheckOverlap((rec1[0], rec1[2]), (rec2[0], rec2[2]));
            var flagY = CheckOverlap((rec1[1], rec1[3]), (rec2[1], rec2[3]));

            return flagX && flagY;
        }

        // checking overlap of two intervals
        // can be used in lots of scenario
        private bool CheckOverlap((int, int) range1, (int, int) range2)
        {
            if (range1.Item1 <= range2.Item1 && range1.Item2 >= range2.Item2)
                return true;
            else if (range1.Item1 >= range2.Item1 && range1.Item2 <= range2.Item2)
                return true;
            else if (range1.Item1 < range2.Item1 && range1.Item2 > range2.Item1)
                return true;
            else if (range1.Item1 < range2.Item2 && range1.Item2 > range2.Item2)
                return true;
            else
                return false;
        }
    }
}
