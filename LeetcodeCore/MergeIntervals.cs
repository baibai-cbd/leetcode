using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MergeIntervals
    {
        // 56. Merge Intervals
        public int[][] Merge(int[][] intervals)
        {
            var stack = new Stack<Tuple<int, int>>();
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
                    return a.Item2.CompareTo(b.Item2);
            }));

            var addminusFlag = 0;
            for (int i = 0; i < list.Count; i++)
            {
                addminusFlag += 1 - list[i].Item2;
                stack.Push(list[i]);

                if (addminusFlag == 0 && stack.Count > 0)
                {
                    var end = stack.Peek();
                    var start = stack.Peek();
                    while (stack.Count > 0)
                        start = stack.Pop();

                    resultList.Add(new int[] { start.Item1, end.Item1 });
                }
            }

            return resultList.ToArray();
        }
    }
}
