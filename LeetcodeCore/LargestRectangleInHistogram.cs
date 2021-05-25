using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LargestRectangleInHistogram
    {
        // 84. Largest Rectangle in Histogram
        // Monotonic stack idea is hard to grasp
        public int LargestRectangleArea(int[] heights)
        {
            var stack = new Stack<int>();
            var maxArea = 0;
            var i = 0;

            while (i < heights.Length)
            {
                if (stack.Count == 0 || heights[i] > heights[stack.Peek()])
                {
                    stack.Push(i);
                    i++;
                }
                else
                {
                    var currMax = stack.Pop();
                    var currArea = heights[currMax] * (stack.Count == 0 ? i : (i - 1 - stack.Peek()));
                    maxArea = Math.Max(maxArea, currArea);
                }
            }

            while (stack.Count > 0)
            {
                var currMax = stack.Pop();
                var currArea = heights[currMax] * (stack.Count == 0 ? i : (i - 1 - stack.Peek()));
                maxArea = Math.Max(maxArea, currArea);
            }

            return maxArea;
        }
    }
}
