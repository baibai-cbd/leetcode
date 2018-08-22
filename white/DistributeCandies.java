package com.white;

import java.util.HashSet;

public class DistributeCandies {

    // problem 575

    public static int distributeCandies(int[] candies) {
        HashSet<Integer> set = new HashSet<>();
        for (int i: candies) {
            if (!set.contains(i))
                set.add(i);
        }

        return (set.size()>(candies.length/2)) ? candies.length/2 : set.size();
    }
}
