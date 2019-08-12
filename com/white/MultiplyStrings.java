package com.white;

public class MultiplyStrings {

    // 43. Multiply Strings
    // Great solution, hard to think of
    public static String multiply(String num1, String num2) {
        
        int l1 = num1.length();
        int l2 = num2.length();

        int[] addArray = new int[l1+l2];

        for (int i=l1-1; i>=0; i--) {
            for (int j = l2-1; j>=0; j--) {
                int digitMult = (num1.charAt(i)-'0') * (num2.charAt(j)-'0');
                int index1 = i+j;
                int index2 = i+j+1;
                int sum = digitMult + addArray[index2];

                addArray[index1] += sum/10;
                addArray[index2] = sum%10;
            }
        }

        StringBuilder sb = new StringBuilder();
        for (int d : addArray) {
            if (sb.length()!=0 || d!=0) {
                sb.append(d);
            }
        }

        return sb.length()==0 ? "0" : sb.toString();
    }
}