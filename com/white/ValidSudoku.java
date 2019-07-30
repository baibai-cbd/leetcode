package com.white;

import java.util.ArrayList;
import java.util.HashSet;

public class ValidSudoku {

    // 36. Valid Sudoku
    public static boolean isValidSudokuI(char[][] board) {
        
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

    // this solution doesn't improve running time
    public static boolean isValidSudokuII(char[][] board) {
        // initialization of tons of hashsets
        ArrayList<HashSet<Character>> hsHorizontal = new ArrayList<>(9);
        ArrayList<HashSet<Character>> hsVertical = new ArrayList<>(9);
        ArrayList<HashSet<Character>> hsGroup = new ArrayList<>(9);
        for (int i = 0; i < 9; i++) {
            hsHorizontal.add(new HashSet<>());
            hsVertical.add(new HashSet<>());
            hsGroup.add(new HashSet<>());
        }
        //
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                // horizontal hs
                if (board[i][j]!='.' && hsHorizontal.get(i).contains(board[i][j])) {
                    return false;
                }
                hsHorizontal.get(i).add(board[i][j]);
                // vertical ts
                if (board[i][j]!='.' && hsVertical.get(j).contains(board[i][j])) {
                    return false;
                }
                hsVertical.get(j).add(board[i][j]);
                //
                int group = mapXYtoHashGroup(j, i);
                if (board[i][j]!='.' && hsGroup.get(group).contains(board[i][j])) {
                    return false;
                }
                hsGroup.get(group).add(board[i][j]);
            }
        }
        return true;
    }

    private static int mapXYtoHashGroup(int x, int y) {
        if (x<3 && y<3) {
            return 0;
        }
        if (x>=3 && x<6 && y<3) {
            return 1;
        }
        if (x>=6 && y<3) {
            return 2;
        }
        //
        if (x<3 && y>=3 && y<6) {
            return 3;
        }
        if (x>=3 && x<6 && y>=3 && y<6) {
            return 4;
        }
        if (x>=6 && y>=3 && y<6) {
            return 5;
        }
        //
        if (x<3 && y>=6) {
            return 6;
        }
        if (x>=3 && x<6 && y>=6) {
            return 7;
        }
        if (x>=6 && y>=6) {
            return 8;
        }
        return 9;
    }
}