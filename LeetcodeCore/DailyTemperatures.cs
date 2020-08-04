using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class DailyTemperaturesSolution
    {
        // 739. Daily Temperatures
        public int[] DailyTemperatures(int[] T)
        {
            if (T.Length <= 1)
                return new int[T.Length];

            var results = new int[T.Length];
            results[T.Length - 1] = 0;
            var stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(T[^1], 1)); // index operator, count 1 from end

            for (int i = T.Length-2; i >= 0; i--)
            {
                if (stack.Peek().Item1 > T[i])
                {
                    results[i] = 1;
                    stack.Push(new Tuple<int, int>(T[i], 1));
                }
                else
                {
                    int days = 1;
                    while (stack.Count > 0)
                    {
                        if (stack.Peek().Item1 <= T[i])
                            days += stack.Pop().Item2;
                        else
                            break;
                    }
                    if (stack.Count == 0)
                    {
                        stack.Push(new Tuple<int, int>(T[i], 0));
                        results[i] = 0;
                    }
                    else
                    {
                        stack.Push(new Tuple<int, int>(T[i], days));
                        results[i] = days;
                    }
                }
            }

            return results;
        }
    }
}
