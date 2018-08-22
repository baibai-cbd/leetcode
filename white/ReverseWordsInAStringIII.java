package com.white;

public class ReverseWordsInAStringIII {

    // problem 557
    // sub optimal, needs improvements

    public static String reverseWords(String s) {
        String[] sa = s.split(" ");
        for (int i=0; i<sa.length; i++) {
            sa[i] = ReverseString.reverseString(sa[i]);
        }

        String sNew = sa[0];
        for (int i=1; i<sa.length; i++) {
            sNew = sNew + " " + sa[i];
        }

        return sNew;
    }
}
