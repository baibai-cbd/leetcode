package com.white;

import java.util.ArrayList;

public class RegularExpressionMatching {

    //  10. Regular Expression Matching

    private static class kvp{
        char a;
        boolean isMany;

        private kvp(char c, boolean isMany) {
            this.a = c;
            this.isMany = isMany;
        }
    }

    public static boolean isMatch(String s, String p) {
        
        char[] charArr = p.toCharArray();
        ArrayList<kvp> kvps = new ArrayList<>();

        for (int i = 0; i < charArr.length; i++) {
            if (charArr[i]!='*') {
                kvps.add(new kvp(charArr[i], false));
            } else {
                kvps.get(kvps.size()-1).isMany = true;
            }
        }

        int trackIndex = 0;
        int kvpIndex = -1;
        outerloop:
        for (kvp var : kvps) {
            kvpIndex++;
            if (var.isMany) {
                while(s.charAt(trackIndex)==var.a) {
                    trackIndex++;
                    if (trackIndex==s.length()) {
                        break outerloop;
                    }
                }
            } else {
                if (s.charAt(trackIndex)!=var.a) {
                    return false;
                }
                trackIndex++;
                if (trackIndex==s.length()) {
                    break outerloop;
                }
            }
        }

        if (trackIndex < s.length()) {
            return false;
        }
        if (kvpIndex < kvps.size()-1) {
            for (int i=kvpIndex+1; i<kvps.size(); i++) {
                if (!kvps.get(i).isMany) {
                    return false;
                }
            }
        }
        
        return true;
    }
}