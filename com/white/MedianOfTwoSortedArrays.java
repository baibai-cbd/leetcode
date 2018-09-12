package com.white;

import java.util.ArrayList;
import java.util.Collections;

public class MedianOfTwoSortedArrays {

    // problem 4

    //    public static double findMedianSortedArrays(int[] nums1, int[] nums2) {
//
//        int m = nums1.length;
//        int n = nums2.length;
//
//        if (m==0) {
//            return getSingleArrayMedian(nums2, 0);
//        }
//
//        if (n==0) {
//            return getSingleArrayMedian(nums1, 0);
//        }
//
//        if (nums1[m-1]<=nums2[0]) {
//            if (m>n) {
//                return getSingleArrayMedian(nums1,n);
//            } else if (m==n) {
//                return ((double) (nums1[m-1] + nums2[0])) / 2;
//            } else {
//                return getSingleArrayMedian(nums2,-m);
//            }
//        }
//
//        if (nums1[0]>=nums2[n-1]) {
//            if (m>n) {
//                return getSingleArrayMedian(nums1,-n);
//            } else if (m==n) {
//                return ((double) (nums1[0] + nums2[n-1])) / 2;
//            } else {
//                return getSingleArrayMedian(nums2,m);
//            }
//        }
//
//        double medianIndex;
//
//        if ((m+n)%2==0)
//            medianIndex = (double) (m+n)/2 - 0.5;
//        else
//            medianIndex = (m + n) / 2;
//
//
//
//        return 0;
//    }
//

//
//    private static double getMedianOfTwoInterleavedArray(int[] arr1, int[]arr2, double medianIndex) {
//        int x1 = 0;
//        int y1 = arr1.length;
//        int x2 = 0;
//        int y2 = arr2.length;
//
//        while ((y1-x1>1 || y2-x2>1) && x1+x2+1<=medianIndex) {
//            int mid1 = (y1+x1)/2;
//            int mid2 = (y2+x2)/2;
//            if (arr1[mid1]>=arr2[mid2]) {
//                if (arr1[mid1]>=arr2[(mid2+y2)/2]) {
//                    x2 = mid2;
//                } else {
//                    y1 = mid1;
//                }
//            } else {
//                if (arr1[mid1]<=arr2[(x2+mid2)/2]) {
//                    y2 = mid2;
//                } else {
//                    x1 = mid1;
//                }
//            }
//        }
//    }

    public static double findMedianSortedArrays(int[] nums1, int[] nums2) {
        int nums1Pointer = 0;
        int nums2Pointer = 0;

        int m = nums1.length;
        int n = nums2.length;

        if (m == 0) {
            return getSingleArrayMedian(nums2, 0);
        }

        if (n == 0) {
            return getSingleArrayMedian(nums1, 0);
        }

        if (nums1[m - 1] <= nums2[0]) {
            if (m > n) {
                return getSingleArrayMedian(nums1, n);
            } else if (m == n) {
                return ((double) (nums1[m - 1] + nums2[0])) / 2;
            } else {
                return getSingleArrayMedian(nums2, -m);
            }
        }

        if (nums1[0] >= nums2[n - 1]) {
            if (m > n) {
                return getSingleArrayMedian(nums1, -n);
            } else if (m == n) {
                return ((double) (nums1[0] + nums2[n - 1])) / 2;
            } else {
                return getSingleArrayMedian(nums2, m);
            }
        }

        double medianIndex;

        if ((m + n) % 2 == 0)
            medianIndex = (double) (m + n) / 2 - 0.5;
        else
            medianIndex = (m + n) / 2;

        while (nums1Pointer + nums2Pointer + 1 < medianIndex) {
            if (nums1[nums1Pointer] <= nums2[nums2Pointer]) {
                if (nums1Pointer==m-1) {
                    return getSingleArrayMedian(nums2, -m);
                }
                nums1Pointer++;
            } else {
                if (nums2Pointer==n-1) {
                    return getSingleArrayMedian(nums1, -n);
                }
                nums2Pointer++;
            }
        }
        //
        ArrayList<Integer> arrayList = new ArrayList<>(4);
        arrayList.add(nums1[nums1Pointer]);
        arrayList.add(nums2[nums2Pointer]);
        if (nums1Pointer!=m-1)
            arrayList.add(nums1[nums1Pointer+1]);
        if (nums2Pointer!=n-1)
            arrayList.add(nums2[nums2Pointer+1]);
        Collections.sort(arrayList);
        //
        if (nums1Pointer + nums2Pointer + 1 == medianIndex) {
            return arrayList.get(1);
        } else {
            return ((double) arrayList.get(0) + arrayList.get(1)) / 2;
        }
    }

    private static double getSingleArrayMedian(int[] array, int offset) {
        int l = array.length + offset;

        if (l % 2 == 0) {
            double median = ((double) (array[l / 2] + array[(l / 2) - 1])) / 2;
            return median;
        } else {
            return (double) array[l / 2];
        }
    }
}
