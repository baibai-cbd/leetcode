package com.white;

import java.util.HashMap;

public class TwoSum {

    // problem 1

    public static int[] twoSum(int[] nums, int target) {
        HashMap<Integer, Integer> hashMap = new HashMap<>();

        for (int i=0; i<nums.length; i++) {
            hashMap.put(nums[i],i);
        }

        for (int i=0; i<nums.length; i++) {
            int otherPart = target - nums[i];
            if (otherPart==nums[i]) {
                int j = hashMap.get(otherPart);
                if (j!=i) {
                    int[] result = new int[]{i,j};
                    return result;
                } else {
                    continue;
                }
            }
            if (hashMap.containsKey(otherPart)) {
                int[] result = new int[]{i,hashMap.get(otherPart)};
                return result;
            }
        }
        return null; // should never happen
    }
}
