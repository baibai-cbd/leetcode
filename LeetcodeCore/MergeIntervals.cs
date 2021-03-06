﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MergeIntervals
    {
        // 56. Merge Intervals
        public int[][] Merge(int[][] intervals)
        {
            var list = new List<Tuple<int, int>>();
            var resultList = new List<int[]>();

            foreach (var item in intervals)
            {
                list.Add(new Tuple<int, int>(item[0], 0));
                list.Add(new Tuple<int, int>(item[1], 2));
            }

            list.Sort(Comparer<Tuple<int, int>>.Create((a, b) =>
            {
                if (a.Item1.CompareTo(b.Item1) != 0)
                    return a.Item1.CompareTo(b.Item1);
                else
                    // this is important because this problem treats same end start point as continuous, i.e [1,3] [3,6] -> [1,6]
                    // so we want start point of second interval appear before the end of first interval after sorting
                    return a.Item2.CompareTo(b.Item2);
            }));

            var addminusFlag = 0;
            var start = 0;
            var end = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (addminusFlag == 0)
                    start = list[i].Item1;

                addminusFlag += 1 - list[i].Item2;

                if (addminusFlag == 0)
                {
                    end = list[i].Item1;
                    resultList.Add(new int[] { start, end });
                }
            }

            return resultList.ToArray();
        }
    }
}
