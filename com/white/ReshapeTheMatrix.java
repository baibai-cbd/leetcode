package com.white;

public class ReshapeTheMatrix {

    // problem 566

    public static int[][] matrixReshape(int[][] nums, int r, int c) {
        if (nums.length*nums[0].length != r*c)
            return nums;
        if (nums.length == r && nums[0].length == c)
            return nums;

        int[][] newMatrix = new int[r][c];
        int p = 0;
        int q = 0;
        for (int i=0; i<r; i++) {
            for (int j=0; j<c; j++) {
                newMatrix[i][j] = nums[p][q];
                q++;
                if (q>=nums[0].length){
                    p++;
                    q=0;
                }
            }
        }
        return newMatrix;
    }
}
