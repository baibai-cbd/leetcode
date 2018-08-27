package com.white;

import java.util.HashSet;

public class JewelsAndStones {

    // problem 771

    public int numJewelsInStones(String J, String S) {
        HashSet<Character> hashSet = new HashSet<>();

        for (char c: J.toCharArray()) {
            hashSet.add(c);
        }

        int sum = 0;

        for (char c: S.toCharArray()) {
            if (hashSet.contains(c))
                sum++;
        }

        return sum;
    }
}
