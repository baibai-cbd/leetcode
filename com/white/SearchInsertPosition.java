package com.white;

public class SearchInsertPosition {

    // 35. Search Insert Position
    public static int searchInsert(int[] nums, int target) {
        
        if (nums.length==0) {
            return 0;
        }
        return binarySearchWithInsertIndex(nums, 0, nums.length-1, target);
    }

    private static int binarySearchWithInsertIndex(int arr[], int l, int r, int x) {
        if (r >= l) {
            int mid = l + (r - l) / 2;

            if (arr[mid] == x)
                return mid;

            if (arr[mid] > x)
                return binarySearchWithInsertIndex(arr, l, mid - 1, x);

            return binarySearchWithInsertIndex(arr, mid + 1, r, x);
        }
        return r+1;
    }
}