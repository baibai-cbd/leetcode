package com.white;

public class BinaryNumberWithAlternatingBits {

    public static boolean hasAlternatingBits(int n) {
        int a = 0xaaaaaaaa; //1010
        int b = 0x55555555; //0101

        int c = 32-Integer.numberOfLeadingZeros(n);

        if (c%2==0) {
            int d = Integer.numberOfTrailingZeros(a-n)-1;
            return d==c;
        } else {
            int e = Integer.numberOfTrailingZeros(b-n)-1;
            return e==c;
        }
    }
}
