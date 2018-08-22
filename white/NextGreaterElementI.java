package com.white;

import java.util.HashMap;

public class NextGreaterElementI {

    // problem 496

    public static int[] nextGreaterElement(int[] nums1, int[] nums2) {
        HashMap<Integer,Integer> hm2 = new HashMap<>();
        for (int i=0; i<nums2.length; i++) {
            hm2.put(nums2[i],i);
        }

        int[] result = new int[nums1.length];
        for (int i=0; i<nums1.length; i++) {
            int index = hm2.get(nums1[i]);
            if (index == nums2.length-1) {
                result[i] = -1;
                continue;
            }
            for (int j=index+1; j<nums2.length; j++) {
                if (nums2[j]>nums1[i]) {
                    result[i] = nums2[j];
                    break;
                }
                if (j == nums2.length-1) {
                    result[i] = -1;
                }
            }
        }

        return result;
    }
}
