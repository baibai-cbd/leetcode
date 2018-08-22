package com.white;

import java.util.ArrayList;

public class KeyboardRow {

    // problem 500

    public static String[] findWords(String[] words) {
        String row1 = "eiortyuqwp";
        String row2 = "asdfghjkl";
        String row3 = "zxcvbnm";

        ArrayList<String> satisfied = new ArrayList<>();


        for (int i=0; i<words.length; i++) {
            boolean flag = false;
            boolean flagOnce = false;
            char[] temp = words[i].toLowerCase().toCharArray();
            for (char c: temp) {
                if (row1.indexOf(c)==-1){
                    flag = false;
                    break;
                }
                flag = true;
                flagOnce = true;
            }

            if (flag) {
                satisfied.add(words[i]);
                continue;
            } else if (!flag && flagOnce)
                continue;

            for (char c: temp) {
                if (row2.indexOf(c)==-1){
                    flag = false;
                    break;
                }
                flag =true;
                flagOnce = true;
            }

            if (flag) {
                satisfied.add(words[i]);
                continue;
            } else if (!flag && flagOnce)
                continue;

            for (char c: temp) {
                if (row3.indexOf(c)==-1){
                    flag = false;
                    break;
                }
                flag =true;
                flagOnce = true;
            }

            if (flag) {
                satisfied.add(words[i]);
            }
        }

        return satisfied.toArray(new String[0]);
    }
}
