package com.white;

public class JudgeRouteCircle {

    // // problem 657

    public static boolean judgeCircle(String moves) {
        char[] ms = moves.toCharArray();
        int x=0,y=0;
        for (char m : ms) {
            System.out.println(m);
            switch (m) {
                case 'U':
                    y++;
                    break;
                case 'D':
                    y--;
                    break;
                case 'L':
                    x--;
                    break;
                case 'R':
                    x++;
                    break;
            }
        }
        if (x==0 && y==0) {
            return true;
        } else {
            return false;
        }
    }
}
