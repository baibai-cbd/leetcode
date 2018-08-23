package com.white;

public class DetectCapital {

    // problem 520

    public static boolean detectCapitalUse(String word) {
        int lowerCaseCount = 0;
        int upperCaseCount = 0;
        boolean firstLetterUpperCase = false;
        if (word.charAt(0)<=90) {
            firstLetterUpperCase = true;
            upperCaseCount++;
        } else {
            lowerCaseCount++;
        }

        for (int i=1; i<word.length(); i++) {
            char a = word.charAt(i);
            if (a>=97){
                lowerCaseCount++;
            } else {
                upperCaseCount++;
            }
        }

        if (lowerCaseCount==0)
            return true;

        if (upperCaseCount==0)
            return true;

        if (firstLetterUpperCase && upperCaseCount==1)
            return true;

        return false;
    }
}
