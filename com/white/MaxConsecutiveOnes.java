package com.white;

public class MaxConsecutiveOnes {

    // problem 485

    public static int findMaxConsecutiveOnes(int[] nums) {
        int countMax=0;
        int countCurr=0;
        for (int i: nums) {
            if (i==0) {
                countMax = (countMax>=countCurr) ? countMax : countCurr;
                countCurr = 0;
            } else {
                countCurr++;
            }
        }
        return (countMax>=countCurr) ? countMax : countCurr;
    }
}
