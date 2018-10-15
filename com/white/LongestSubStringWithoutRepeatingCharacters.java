package com.white;

public class LongestSubStringWithoutRepeatingCharacters {

    // problem 3

    // dynamic programming solution with O(n^2) space complexity
    // not ideal

//    public static int lengthOfLongestSubstring(String s) {
//
//        int[][] dynamicMatrix = new int[s.length()][s.length()];
//
//        char[] charArray = s.toCharArray();
//
//        return dynamicCheck(charArray,0,charArray.length-1, dynamicMatrix);
//    }
//
//    public static int dynamicCheck(char[] array, int start, int end, int[][]matrix) {
//        if (start>end || start<0 || end>=array.length)
//            return 0;
//
//        if (matrix[start][end]>0 && matrix[start][end]<=array.length)
//            return matrix[start][end];
//
//        if (start==end) {
//            matrix[start][end] = 1;
//            return 1;
//        }
//
//        int left1 = dynamicCheck(array,start+1, end, matrix);
//        int right1 = dynamicCheck(array, start, end-1, matrix);
//
//        if (left1==1 && right1==1) {
//            if (array[start]!=array[end]) {
//                matrix[start][end] = 2;
//                return 2;
//            } else {
//                matrix[start][end] = 1;
//                return 1;
//            }
//        }
//
//        if (left1>right1) {
//            matrix[start][end] = left1;
//            return left1;
//        } else if (right1>left1) {
//            matrix[start][end] = right1;
//            return right1;
//        } else {
//            if (left1==(end-start) && (array[start]!=array[end])) {
//                matrix[start][end] = left1 + 1;
//                return matrix[start][end];
//            } else {
//                matrix[start][end] = left1;
//                return left1;
//            }
//        }
//    }

    public static int lengthOfLongestSubstring(String s) {

        int[] mapIndex = new int[256];

        int i = 0;
        int j = 0;
        int n = s.length();
        int result = 0;

        for (; i<n; i++) {
            while (j<n) {
                if (mapIndex[s.charAt(j)]==0) {
                    mapIndex[s.charAt(j)] = j + 1 ;
                    result = Math.max(result, j-i+1);
                    j++;
                } else {
                    mapIndex[s.charAt(i)] = 0;
                    break;
                }
            }
        }
        return result;
    }
}
