package com.white;

public class RemoveDuplicatesFromSortedArray {

    // 26. Remove Duplicates from Sorted Array
    public static int removeDuplicates(int[] nums) {
        if (nums==null || nums.length==0) {
            return 0;
        }
        if (nums.length==1) {
            return 1;
        }

        int currNum = nums[0];
        int currLastIndex = 0;
        int currIndex = 0;
        while(currIndex < nums.length) {
            if (nums[currIndex]==currNum) {
                currIndex++;
            } else {
                currLastIndex++;
                nums[currLastIndex] = nums[currIndex];
                currNum = nums[currIndex];
                currIndex++;
            }
        }

        return currLastIndex+1;
    }
}