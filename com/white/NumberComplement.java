package com.white;

public class NumberComplement {

    // 476 Number Complement

    public static int findComplement(int num) {
        String s = Integer.toBinaryString(num);
        s = Integer.toBinaryString(~num).substring(32 - s.length());
        return Integer.parseInt(s,2);
    }
}
