package com.white;

public class SurfaceArea3DShapes {

    // problem 892

    public static int surfaceArea(int[][] grid) {
        int N = grid.length;
        int sum = 0;

        for (int i = 0; i<N; i++) {
            for (int j = 0; j < N; j++) {
                int currentHeight = grid[i][j];
                int singleTowerArea;

                if (currentHeight==0) {
                    singleTowerArea = 0;
                } else {
                    int north = (i - 1 >= 0) ? grid[i - 1][j] : 0;
                    int south = (i + 1 < N) ? grid[i + 1][j] : 0;
                    int west = (j - 1 >= 0) ? grid[i][j - 1] : 0;
                    int east = (j + 1 < N) ? grid[i][j + 1] : 0;

                    singleTowerArea = (2 + currentHeight * 4) - ((north < currentHeight) ? north : currentHeight) - ((south < currentHeight) ? south : currentHeight) - ((west < currentHeight) ? west : currentHeight) - ((east < currentHeight) ? east : currentHeight);
                }

                sum += singleTowerArea;
            }
        }

        return sum;
    }
}
