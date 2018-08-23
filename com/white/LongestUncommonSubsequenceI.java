package com.white;

public class LongestUncommonSubsequenceI {

    // problem 521

    public static int findLUSlength(String a, String b) {
        return a.equals(b) ? -1 : Math.max(a.length(), b.length());
    }
}
