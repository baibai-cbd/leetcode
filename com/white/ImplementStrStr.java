package com.white;

public class ImplementStrStr {

    // 28. Implement strStr()
    // This is a brute force slow solution,
    // try using KMP & Boyer-Moore next time
    public static int strStr(String haystack, String needle) {
        
        if (needle.isEmpty()) {
            return 0;
        }

        outerloop:
        for (int i = 0; i < haystack.length(); i++) {
            if (haystack.charAt(i) == needle.charAt(0)) {
                int j = 1;
                while (j<needle.length() && i+j<haystack.length()) {
                    if (haystack.charAt(i+j) == needle.charAt(j)) {
                        j++;
                    } else {
                        continue outerloop;
                    }
                }
                if (j==needle.length()) {
                    return i;
                }
            }
        }
        return -1;
    }
}