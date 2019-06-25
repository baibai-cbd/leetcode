package com.white;

public class RemoveElement {

    // 27. Remove Element
    // needs further investigation
    public static int removeElement(int[] nums, int val) {
        if (nums==null || nums.length==0) {
            return 0;
        }

        int index = 0;
        int currFetchIndex = nums.length;
        while (index<currFetchIndex) {
            if (nums[index]==val) {
                nums[index] = nums[currFetchIndex-1];
                currFetchIndex--;
            } else {
                index++;
            }
        }

        return currFetchIndex;
    }
}