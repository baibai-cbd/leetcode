package com.white;

public class FindFirstLastPositionInSortedArray {

    private int lowerIndex;
    private int upperIndex;
    // 34. Find First and Last Position of Element in Sorted Array
    public int[] searchRange(int[] nums, int target) {

        if (nums==null ||nums.length==0) {
            return new int[] {-1,-1};
        }
        int l = 0;
        int r = nums.length-1;
        while(l < r) {
            int mid = (l+r)/2;
            if (nums[mid] < target)
                l = mid + 1;
            else
                r = mid;
        }
        this.lowerIndex = nums[l]==target ? l : -1;

        r = nums.length-1;
        while(l < r) {
            // mid is calculated differently
            int mid = (l + r+1)/2;
            if (nums[mid] > target)
                r = mid - 1;
            else
                l = mid;
        }
        this.upperIndex = nums[l]==target ? l : -1;

        return new int[] {this.lowerIndex, this.upperIndex};
    }
}