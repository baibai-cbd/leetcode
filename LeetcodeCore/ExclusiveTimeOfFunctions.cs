using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ExclusiveTimeOfFunctions
    {
        // 636. Exclusive Time of Functions
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            var stack = new Stack<(int, bool, int)>();
            var result = new int[n];
            var currTime = 0;

            foreach (var s in logs)
            {
                var arr = s.Split(':');
                // treating timestamp specially because of unconsistent start/end timestamp (end timestamp is at end of a second while start is at start of a second)
                var currLog = (int.Parse(arr[0]), arr[1] == "start", arr[1] == "start" ? int.Parse(arr[2]) : int.Parse(arr[2]) + 1);
                if (stack.Count > 0)
                {
                    var lastLog = stack.Peek();
                    // condition below is not same event or same event id but a recursive one(both "start" event)
                    if (lastLog.Item1 != currLog.Item1 || (lastLog.Item1 == currLog.Item1 && lastLog.Item2 == currLog.Item2))
                    {
                        result[lastLog.Item1] += currLog.Item3 - currTime;
                        currTime = currLog.Item3;
                        stack.Push(currLog);
                    }
                    else
                    {
                        result[currLog.Item1] += currLog.Item3 - currTime;
                        currTime = currLog.Item3;
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(currLog);
                    currTime = currLog.Item3;
                }
            }

            return result;
        }
    }
}
