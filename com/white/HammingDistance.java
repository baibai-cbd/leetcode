package com.white;

public class HammingDistance {

    // // problem 461

    public static int hammingDistance(int x, int y) {
        int z = x^y;
        int w = 0x1;
        int count = 0;
        for (int i=1; i<=32; i++) {
            if ((z & w) == 1)
                count++;
            z = z >>> 1;
        }
//        Integer.bitCount((x^y));
        return count;

    }
}
