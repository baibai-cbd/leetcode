package com.white;

public class LongestPalindromicSubstring {

    // problem 5
    // too much corner cases, not ideal

    public static String longestPalindrome(String s) {

        if (s.length()==1)
            return s;

        if (s.length()==2) {
            if (s.charAt(0)==s.charAt(1))
                return s;
            else
                return s.substring(1);
        }

        String result;

        if (s.length()==0)
            result = "";
        else
            result = s.substring(0,1);

        for (int i=1; i<s.length()-1 ; i++) {
            int j = i-1;
            int k = i+1;
            int l = i-1;
            int m = i+1;

            if (s.charAt(j)==s.charAt(i)) {
                k--;
                while (j>=0 && k<s.length()) {
                    if (s.charAt(j)==s.charAt(k)) {
                        if (result.length() <= (k-j)+1)
                            result = s.substring(j, k + 1);
                        j--;
                        k++;
                    } else {
                        break;
                    }
                }
            } else if (s.charAt(k)==s.charAt(i)) {
                j++;
                while (j>=0 && k<s.length()) {
                    if (s.charAt(j)==s.charAt(k)) {
                        if (result.length() <= (k-j)+1)
                            result = s.substring(j, k + 1);
                        j--;
                        k++;
                    } else {
                        break;
                    }
                }
            }

            if (s.charAt(l)==s.charAt(m)) {
                while (l>=0 && m<s.length()) {
                    if (s.charAt(l)==s.charAt(m)) {
                        if (result.length() <= (m-l)+1)
                            result = s.substring(l, m + 1);
                        l--;
                        m++;
                    } else {
                        break;
                    }
                }
            }
        }

        return result;
    }

}
