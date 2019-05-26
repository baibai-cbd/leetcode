package com.white;

import java.util.HashMap;

public class RomanToInteger {

    // 13. Roman to Integer

    public static int romanToInt(String s) { 
        HashMap<Character, Integer> hashMap = new HashMap<>();
        hashMap.put('I', 1);
        hashMap.put('V', 5);
        hashMap.put('X', 10);
        hashMap.put('L', 50);
        hashMap.put('C', 100);
        hashMap.put('D', 500);
        hashMap.put('M', 1000);

        int sum = 0;
        int last = 0;
        for (int i = 0; i < s.length(); i++) {
            int curr = hashMap.get(s.charAt(i));
            sum += curr;
            if (curr > last) {
                sum = sum - 2*last;
            }
            last = curr;
        }
        return sum;
    }
}