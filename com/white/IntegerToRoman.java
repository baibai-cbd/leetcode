package com.white;

public class IntegerToRoman {

    // 12. Integer to Roman

    public static String intToRoman(int num) {
        
        StringBuilder sb = new StringBuilder();
        int digit = 1;
        while (num > 0) {
            sb.insert(0, getRomanString(digit, num%10));
            num = num/10;
            digit = digit*10;
        }

        return sb.toString();
    }

    private static String getRomanString(int digit, int value) {
        switch (digit) {
            case 1:
                return getRomanStringByDigit(value, "I", "V", "X");
            case 10:
                return getRomanStringByDigit(value, "X", "L", "C");
            case 100:
                return getRomanStringByDigit(value, "C", "D", "M");
            case 1000:
                return getRomanStringByDigit(value, "M", "Q", "P");
            default:
                return "";
        }
    }

    private static String getRomanStringByDigit(int value, String i, String v, String x) {
        switch (value) {
            case 4:
                return i+v;
            case 9:
                return i+x;
            case 1:
                return i;
            case 2:
                return i+i;
            case 3:
                return i+i+i;
            case 7:
                return v+i+i;
            case 5:
                return v;
            case 6:
                return v+i;
            case 8:
                return v+i+i+i;
            default:
                return "";
        }
    }
}
