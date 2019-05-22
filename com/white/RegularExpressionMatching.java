package com.white;

public class RegularExpressionMatching {

    //  10. Regular Expression Matching

    public static boolean isMatch(String s, String p) {
        
        if (p.isEmpty()) {
            if (s.isEmpty()) {
                return true;
            } else {
                return false;
            }
        }
        
        boolean[][] dpArr = new boolean[s.length()+1][p.length()+1];

        dpArr[0][0] = true;

        for (int i = 1; i < dpArr[0].length; i++) {
            if (p.charAt(i-1)=='*') {
                dpArr[0][i] = dpArr[0][i-2];
            }
        }

        for (int i = 1; i < dpArr.length; i++) {
            for (int j = 1; j < dpArr[0].length; j++) {
                if (p.charAt(j-1)=='.' || p.charAt(j-1)==s.charAt(i-1)) {
                    dpArr[i][j] = dpArr[i-1][j-1];
                } else if (p.charAt(j-1)=='*') {
                    dpArr[i][j] = dpArr[i][j-2];
                    if (p.charAt(j-2)=='.' || p.charAt(j-2)==s.charAt(i-1)) {
                        dpArr[i][j] = dpArr[i][j] || dpArr[i-1][j];
                    }
                } else {
                    dpArr[i][j] = false;
                }
            }
        }
        return dpArr[s.length()][p.length()];
    }
}