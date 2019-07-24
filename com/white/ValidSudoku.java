package com.white;

import java.util.HashSet;

public class ValidSudoku {

    // 36. Valid Sudoku
    public static boolean isValidSudoku(char[][] board) {
        
        HashSet<Character> hs = new HashSet<>();
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (board[i][j]!='.' && hs.contains(board[i][j])) {
                    return false;
                }
                hs.add(board[i][j]);
            }
            hs.clear();
        }

        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (board[j][i]!='.' && hs.contains(board[j][i])) {
                    return false;
                }
                hs.add(board[j][i]);
            }
            hs.clear();
        }

        int[] startI = new int[] {0,0,0,3,3,3,6,6,6};
        int[] startJ = new int[] {0,3,6,0,3,6,0,3,6};
        for (int k = 0; k < 9; k++) {
            int x = startI[k];
            int y = startJ[k];
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (board[x+i][y+j]!='.' && hs.contains(board[x+i][y+j])) {
                        return false;
                    }
                    hs.add(board[x+i][y+j]);
                }
            }
            hs.clear();
        }
        return true;
    }
}