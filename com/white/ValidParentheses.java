package com.white;

import java.util.HashMap;
import java.util.Map;
import java.util.Stack;

public class ValidParentheses {

    // 20. Valid Parentheses
    public static boolean isValid(String s) {
        if (s.equals("")) {
            return true;
        }
        if (s==null || s.length()==1) {
            return false;
        }
        Map<Character, Character> map = new HashMap<>();
        map.put(')', '(');
        map.put('}', '{');
        map.put(']', '[');

        Stack<Character> stack = new Stack<>();
        for (char c : s.toCharArray()) {
            if (c=='{' || c=='[' || c=='(') {
                stack.push(c);
            } else {
                if (stack.empty())
                    return false;
                if (stack.pop()!=map.get(c)) {
                    return false;
                }
            }
        }

        if (stack.empty())
            return true;
        else
            return false;
    }
}