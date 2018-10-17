package com.white;

public class ReverseInteger {

    // problem 7

    public static int reverse(int x) {
        if (x == 0) {
            return 0;
        }

        String first = Integer.toString(x);
        String second = first.replaceFirst("[0]+$", "");
        char[] charArray = second.toCharArray();
        StringBuilder sBuilder = new StringBuilder();
        int endInt = 0;
        int result = 0;

        if (charArray[0]=='-') {
            endInt = 1;
            sBuilder.append('-');
        }

        for (int i = charArray.length-1; i >= endInt; i--)
            sBuilder.append(charArray[i]);    

        try {
            result = Integer.parseInt(sBuilder.toString());
        } catch (Exception e) {
            return 0;
        }

        return result;
    }
}