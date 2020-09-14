using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    // 57. Insert Interval
    public class InsertInterval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var indexL = -1;
            var indexR = intervals.Length;
            var indexI = 0;
            for (int i = 0; i < intervals.Length; i++)
            {
                var r = CheckOverlap(intervals[i], newInterval);
                if (r == -1)
                {
                    indexI = i;
                    break;
                }
                else if (r == 1)
                {
                    indexI = i + 1;
                    continue;
                }
                else
                {
                    indexL = indexL == -1 ? i : indexL;
                    indexR = i;
                }
            }

            var list = new List<int[]>(intervals);
            if (indexL == -1 && indexR == intervals.Length)
            {
                list.Insert(indexI, newInterval);
            }
            else
            {
                var intervalL = intervals[indexL];
                var intervalR = intervals[indexR];
                var bigInterval = new int[] { Math.Min(intervalL[0], newInterval[0]), Math.Max(intervalR[1], newInterval[1]) };
                list.RemoveRange(indexL, indexR - indexL + 1);
                list.Insert(indexL, bigInterval);
            }

            return list.ToArray();
        }

        private int CheckOverlap(int[] interval1, int[] interval2)
        {
            if (interval2[1] < interval1[0])
            {
                return -1; // interval2 not overlap and left of interval1
            }
            else if (interval2[0] > interval1[1])
            {
                return 1; // interval2 not overlap and right of interval1
            }
            else
            {
                return 0;
            }
        }
    }
}
