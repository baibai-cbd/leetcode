package com.white;

public class IslandPerimeter {

    // problem 463

    public static int islandPerimeter(int[][] grid) {
        int perimeter = 0;
        boolean[] flags = new boolean[grid[0].length];
        boolean flagLastCell = false;
        for (int i=0; i< grid.length; i++) {
            for (int j=0; j<grid[0].length; j++) {
                if (grid[i][j]==1) {
                    perimeter += 4;
                    if (flagLastCell) {
                        perimeter -= 2;
                    }
                    if (flags[j]) {
                        perimeter -= 2;
                    }
                    flagLastCell = true;
                    flags[j] = true;
                } else {
                    flagLastCell = false;
                    flags[j] = false;
                }
            }
            flagLastCell = false;
        }
        return perimeter;
    }
}
