using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeCore
{
    public class TaskScheduler
    {
        // 621. Task Scheduler
        // Go ahead and understand this
        public int LeastInterval(char[] tasks, int n)
        {
            int[] c = new int[26];
            foreach (var t in tasks)
            {
                c[t - 'A']++;
            }
            Array.Sort(c);
            int i = 25;
            while (i >= 0 && c[i] == c[25]) i--;

            return Math.Max(tasks.Length, (c[25] - 1) * (n + 1) + 25 - i);
        }
    }
}
