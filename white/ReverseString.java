package com.white;

public class ReverseString {

    // problem 344

    public static String reverseString(String s) {
        char[] ca = s.toCharArray();
        char[] car = new char[ca.length];
        for (int i=ca.length-1; i>=0; i--) {
            car[ca.length-1-i] = ca[i];
        }

        return String.copyValueOf(car);
    }

    public static String reverseString2(String s) {
        StringBuilder sb = new StringBuilder(s);
        return sb.reverse().toString();
    }
}
