package com.white;

public class ContainerWithMostWater {

    //  11. Container With Most Water

    public static int maxArea(int[] height) {
        
        int maxArea = 0;

        int head = 0;
        int tail = height.length-1;

        while (head < tail) {
            int currArea = calcArea(head, height[head], tail, height[tail]);
            if (currArea >= maxArea) {
                maxArea = currArea;
            }
            if (height[head] <= height[tail]) {
                head++;
            } else {
                tail--;
            }
        }

        return maxArea;
    }

    private static int calcArea(int i, int a, int j, int b) {
        return a>=b ? (j-i)*b : (j-i)*a;
    }
}