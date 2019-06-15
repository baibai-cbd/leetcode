package com.white;

import java.util.Arrays;

public class ThreeSumClosest {

    // 16. 3Sum Closest
    public static int threeSumClosest(int[] nums, int target) {

        int result = simpleThreeSum(nums, 0, 1, nums.length-1);
        Arrays.sort(nums);
        for (int i = 0; i < nums.length-2; i++) {
            int head = i+1;
            int tail = nums.length-1;
            while (head < tail) {
                int sum = simpleThreeSum(nums, i, head, tail);
                if (sum==target) {
                    return target;
                }

                if (sum > target) {
                    tail--;
                } else {
                    head++;
                }

                if (Math.abs(sum-target)< Math.abs(result-target)) {
                    result = sum;
                }
            }
        }
        return result;
    }

    private static int simpleThreeSum(int[] arr, int i, int j, int k) {
        return arr[i] + arr[j] + arr[k];
    }
}