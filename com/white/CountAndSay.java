package com.white;

public class CountAndSay {

    // 38. Count and Say
    // Description in leetcode is really bad
    // Basically means iteratively count & speak out the string with all numbers
    public static String countAndSay(int n) {
        
        StringBuilder sb = new StringBuilder();
        String curr = "1";
        if (n==1) {
            return curr;
        }

        for (int i = 1; i < n; i++) {
            char currChar = curr.charAt(0);
            int count = 0;
            for (int j=0; j<curr.length(); j++) {
                if (curr.charAt(j) == currChar) {
                    count++;
                } else {
                    sb.append(count);
                    sb.append(currChar);
                    currChar = curr.charAt(j);
                    count = 1;
                }
            }
            sb.append(count);
            sb.append(currChar);
            curr = sb.toString();
            sb = new StringBuilder();
        }
        return curr;
    }
}