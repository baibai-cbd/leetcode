package com.white;

import java.util.HashSet;

public class PrimeNumberSetBits {

    // problem 762
    // easy way done, do it another way next time (bit manipulation way)

    public static int countPrimeSetBits(int L, int R) {
        // under 1M, bit counts under 20 (inclusive)
        int[] primes = {2,3,5,7,11,13,17,19};

        HashSet<Integer> hs = new HashSet<>();
        for (int i:primes) {
            hs.add(i);
        }

        int sum = 0;

        for (int i=L; i<=R; i++) {
            if (hs.contains(Integer.bitCount(i)))
                sum++;
        }

        return sum;
    }
}
