package com.white;

public class DivideTwoIntegers {

    // 29. Divide Two Integers
    // lots of corner cases
    public static int divide(int dividend, int divisor) {
        if (dividend == Integer.MIN_VALUE && divisor == -1)
            return Integer.MAX_VALUE;
        if (divisor == Integer.MIN_VALUE) {
            if (dividend == Integer.MIN_VALUE) return 1;
            else return 0;
        }

        boolean sign = true;
        if (dividend < 0 && divisor > 0) {
            divisor = -divisor;
            sign = false;
        }
        if (dividend > 0 && divisor < 0) {
            divisor = -divisor;
            sign = false;
        }

        int result = 0;
        if (dividend<0) {
            while (dividend <= divisor) {
                int shift = 0;
                while (dividend <= divisor<<shift && divisor<<shift <= divisor && shift<32) {
                    shift++;
                }
                result += (1<<(shift-1));
                dividend -= (divisor<<(shift-1));
            }
        } else {
            while (dividend >= divisor) {
                int shift = 0;
                while (dividend >= divisor<<shift && divisor<<shift >= divisor) {
                    shift++;
                }
                result += (1<<(shift-1));
                dividend -= (divisor<<(shift-1));
            }
        }

        return sign ? result : (~result)+1;
    }
}