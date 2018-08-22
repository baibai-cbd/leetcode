package com.white;

public class MaxAreaOfIsland {

    // problem 695

    private static int[][] inside;

    public static int maxAreaOfIsland(int[][] grid) {
        inside = grid;
        int max = 0;
        int temp;
        for (int i=0; i<grid[0].length; i++) {
            for (int j=0; j<grid.length; j++) {
                if (grid[j][i] == 1) {
                    temp = wanderer(i,j);
                    max = (max>temp) ? max : temp;
                }
            }
        }
        return max;
    }

    public static int wanderer(int i, int j) {
        if (inside[j][i]==0) {
            return 0;
        } else {
            inside[j][i] = 0;
            return 1 + wanderer(Math.min(inside[0].length-1,i+1),j) + wanderer(Math.max(0,i-1),j) + wanderer(i,Math.min(inside.length-1,j+1)) + wanderer(i,Math.max(0,j-1));
        }
    }


}
