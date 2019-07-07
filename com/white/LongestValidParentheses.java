package com.white;

import java.util.Arrays;

public class LongestValidParentheses {

    // 32. Longest Valid Parentheses
    // this is DP way, can try stack way next time
    public static int longestValidParentheses(String s) {
        
        if (s==null || s.length()<2) {
            return 0;
        }

        int[] dpArray = new int[s.length()];
        Arrays.fill(dpArray, 0);
        for (int i = 1; i < s.length(); i++) {
            if (s.charAt(i)==')' && s.charAt(i-1)=='(') dpArray[i] = 2;
        }

        for (int i = 2; i < s.length(); i++) {
            if (s.charAt(i) == ')' && s.charAt(i - 1) == '(') {
                dpArray[i] = dpArray[i - 2] + 2;
            }
            if (s.charAt(i) == ')' && s.charAt(i - 1) == ')') {
                if (i - dpArray[i - 1] - 1 >= 0) {
                    if (s.charAt(i - dpArray[i - 1] - 1) == '(') {
                        int temp = (i - dpArray[i - 1] - 2 < 0) ? 0 : dpArray[i - dpArray[i - 1] - 2];
                        dpArray[i] = dpArray[i - 1] + temp + 2;
                    }
                }
            }
        }

        int max = 0;
        for (int i : dpArray) {
            if (i > max)
                max = i;
        }
        return max;
    }
}