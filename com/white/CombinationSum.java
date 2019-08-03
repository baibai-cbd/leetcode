package com.white;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class CombinationSum {
    
    // 39. Combination Sum
    // very good solution generally for this kind of questions, backtracking
    public static List<List<Integer>> combinationSum(int[] candidates, int target) {
        
        List<List<Integer>> lists = new ArrayList<>();
        Arrays.sort(candidates);
        backtrack(lists, new ArrayList<>(), candidates, target, 0);
        return lists;
    }

    private static void backtrack(List<List<Integer>> lists, List<Integer> currList, int[] nums, int remains, int index) {
        if (remains<0) return;
        else if (remains==0) {
            lists.add(new ArrayList<>(currList));
        } else {
            for (int i = index; i < nums.length; i++) {
               currList.add(nums[i]);
               backtrack(lists, currList, nums, remains-nums[i], i);
               currList.remove(currList.size()-1); 
            }
        }
    }
}