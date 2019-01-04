package com.white;

import java.util.Stack;

public class LargestRectangleInHistogram {

	// 84. Largest Rectangle in Histogram
	
	public static int largestRectangleArea(int[] heights) {
        
		Stack<Integer> stack = new Stack<>();
		int maxArea = 0;
		int i = 0; 
		
		while (i<heights.length) {
			
			if (stack.empty() || heights[stack.peek()]<heights[i] ) {
				stack.push(i);
				i++;
			} else {
				int currMax = stack.pop();
				int area = heights[currMax] * (stack.empty() ? i : (i-1-stack.peek()));
				
				if (area>maxArea) {
					maxArea = area;
				}
			}
		}
		
		while (!stack.empty()) {
			int currMax = stack.pop();
			int area = heights[currMax] * (stack.empty() ? i : (i-1-stack.peek()));
			
			if (area>maxArea) {
				maxArea = area;
			}
		}
		
		return maxArea;
    }
}
