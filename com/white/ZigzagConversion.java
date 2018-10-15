package com.white;

public class ZigzagConversion {

    // problem 6

    public static String convert(String s, int numRows) {
        if (s==null || s.length()==0)
            return "";

        if (numRows==1)
            return s;

        StringBuilder sb = new StringBuilder(s.length());

        for (int i = 0; i < numRows; i++) {
            int index = i;
            int rowIndex = i;
            boolean top = true;
            boolean changed = true;

            while(index<s.length()) {
                if (changed)
                    sb.append(s.charAt(index));
                
                int step = 0;
                
                if (top) {
                    step = Math.max(0,((numRows-rowIndex-1) + (numRows-rowIndex-2)+1));
                    top = !top;
                    if (step==0)
                        changed = false;
                    else
                        changed = true;
                } else {
                    step = Math.max(0,(rowIndex+(rowIndex-1)+1));
                    top = !top;
                    if (step==0)
                        changed = false;
                    else
                        changed = true;
                }
                index += step;
            }
        }

        return sb.toString();
    }
}