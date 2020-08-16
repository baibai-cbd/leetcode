using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LeetcodeCore
{
    public class NonOverlappingIntervals
    {
        // 435. Non-overlapping Intervals
        public int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;

            Array.Sort(intervals, new MyComparer());
            int end = intervals[0][1];
            int count = 1;

            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] >= end)
                {
                    end = intervals[i][1];
                    count++;
                }
            }
            return intervals.Length - count;
        }

        public class MyComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                return x[1] - y[1];
            }
        }
    }
}
