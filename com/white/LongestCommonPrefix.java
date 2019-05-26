package com.white;

public class LongestCommonPrefix {

    // 14. Longest Common Prefix
    // There are many solutions, can checkout recursive, divide and conquer, binary search

    public static String longestCommonPrefix(String[] strs) {
        
        if (strs.length==0) {
            return "";
        }
        if (strs.length==1) {
            return strs[0];
        }

        StringBuilder sb = new StringBuilder();
        int index = 0;
        
        outerloop:
        while (true) {
            char c = '0';
            for (String s : strs) {
                if (s.length()>index) {
                    if (c == '0') {
                        c = s.charAt(index);
                    } else if(c != s.charAt(index)){
                        break outerloop;
                    }
                } else {
                    break outerloop;
                }
            }
            index++;
            sb.append(c);
        }

        return sb.toString();
    }
}