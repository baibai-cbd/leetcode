package com.white;

public class FlippingAnImage {

    // problem 832

    public static int[][] flipAndInvertImage(int[][] A) {
        int N = A.length;
        int[][] result = new int[N][N];

        for (int k=0; k<N; k++) {
            int[] a = A[k];
            int[] aTransformed = new int[N];
            for (int i=0; i<N; i++) {
                int j = N-1-i;

                if (i>j)
                    break;

                if (a[i]==a[j]) {
                    aTransformed[i] = 1-a[i];
                    aTransformed[j] = 1-a[j];
                } else {
                    aTransformed[i] = a[i];
                    aTransformed[j] = a[j];
                }
            }
            result[k] = aTransformed;
        }
        return result;
    }
}
