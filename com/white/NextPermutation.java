package com.white;

import java.util.Arrays;

public class NextPermutation {

    // 31. Next Permutation
    public static void nextPermutation(int[] nums) {
        
        if (nums==null || nums.length<=1) {
            return;
        }

        for (int i=nums.length-2; i>=0; i--) {
            if (nums[i]<nums[i+1]) {
                int onlyLarger = Integer.MAX_VALUE;
                int onlyLargerIndex = i;
                for (int j = i+1; j < nums.length; j++) {
                    if (nums[j]<onlyLarger && nums[j]>nums[i]) {
                        onlyLarger = nums[j];
                        onlyLargerIndex = j;
                    }
                }
                swapAndSortAfter(i, onlyLargerIndex, nums);
                return;
            }
        }
        // if already highest lexicographically order
        Arrays.sort(nums);
    }

    private static void swapAndSortAfter(int frontIndex, int backIndex, int[] nums) {
        int temp = nums[backIndex];
        nums[backIndex] = nums[frontIndex];
        nums[frontIndex] = temp;
        int[] endPartArray = Arrays.copyOfRange(nums, frontIndex+1, nums.length);
        Arrays.sort(endPartArray);
        for (int i = frontIndex+1; i < nums.length; i++) {
            nums[i] = endPartArray[i-frontIndex-1];
        }
    }
}