using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class TrappingRainWater
    {
        // 42. Trapping Rain Water
        // TODO: Try the left max, right max way
        public int Trap(int[] height)
        {
            if (height == null || height.Length <= 2)
                return 0;
            var result = 0;
            var stack = new Stack<int>();
            stack.Push(height[0]);

            for (int i = 1; i < height.Length; i++)
            {
                if (height[i] > stack.Peek())
                {
                    int width = 0;
                    int bottomHeight = stack.Peek();
                    while (stack.Count != 0 && stack.Peek() <= height[i])
                    {
                        var curr = stack.Pop();
                        if (curr > bottomHeight)
                        {
                            result += (curr - bottomHeight) * width;
                            for (int j = 0; j <= width; j++)
                            {
                                stack.Push(curr); // push back the nodes if left side still has nodes
                            }
                            bottomHeight = stack.Peek();
                            width = 0;
                        }
                        else
                        {
                            width++;
                        }
                    }
                    if (stack.Count != 0)
                    {
                        result += (height[i] - bottomHeight) * width;
                        for (int k = 0; k < width; k++)
                        {
                            stack.Push(height[i]); // push back the nodes if left side still has nodes
                        }
                    }
                }
                stack.Push(height[i]);
            }

            return result;
        }
    }
}
