package com.white;

import java.util.ArrayList;
import java.util.List;

public class LetterCombinationsOfAPhoneNumber {

    // 17. Letter Combinations of a Phone Number
    static char[] array2 = new char[]{'a', 'b', 'c'};
    static char[] array3 = new char[]{'d', 'e', 'f'};
    static char[] array4 = new char[]{'g', 'h', 'i'};
    static char[] array5 = new char[]{'j', 'k', 'l'};
    static char[] array6 = new char[]{'m', 'n', 'o'};
    static char[] array7 = new char[]{'p', 'q', 'r', 's'};
    static char[] array8 = new char[]{'t', 'u', 'v'};
    static char[] array9 = new char[]{'w', 'x', 'y', 'z'};
    static List<String> result = new ArrayList<>();
    static StringBuilder sb = new StringBuilder();
    
    public static List<String> letterCombinations(String digits) {
        
        if (digits == null || digits.equals("")) {  // java String.equals() is so bad
            return new ArrayList<>();
        }
        sb = new StringBuilder();
        result = new ArrayList<>();
        char[] numArr = digits.toCharArray();
        DFStraverse(numArr,0);
        
        return result;
    }

    private static void DFStraverse(char[] numArr, int i) {
        if (i == numArr.length) {
            result.add(sb.toString());
            return;
        }
        switch (numArr[i]) {
            case '2':
                for (char c : array2) {
                    sb.append(c);
                    DFStraverse(numArr, i+1);
                    sb.delete(i, sb.length());
                }
                break;
        
            case '3':
                for (char c : array3) {
                    sb.append(c);
                    DFStraverse(numArr, i+1);
                    sb.delete(i, sb.length());
                }
            break;            

            case '4':
                for (char c : array4) {
                    sb.append(c);
                    DFStraverse(numArr, i+1);
                    sb.delete(i, sb.length());
                }
            break;

            case '5':
                for (char c : array5) {
                    sb.append(c);
                    DFStraverse(numArr, i+1);
                    sb.delete(i, sb.length());
                }
            break;

            case '6':
                for (char c : array6) {
                    sb.append(c);
                    DFStraverse(numArr, i+1);
                    sb.delete(i, sb.length());
                }
            break;
                
            case '7':
                for (char c : array7) {
                    sb.append(c);
                    DFStraverse(numArr, i+1);
                    sb.delete(i, sb.length());
                }
            break;

            case '8':
                for (char c : array8) {
                    sb.append(c);
                    DFStraverse(numArr, i+1);
                    sb.delete(i, sb.length());
                }
            break;

            case '9':
                for (char c : array9) {
                    sb.append(c);
                    DFStraverse(numArr, i+1);
                    sb.delete(i, sb.length());
                }
            break;

            default:
                break;
        }
    }
}