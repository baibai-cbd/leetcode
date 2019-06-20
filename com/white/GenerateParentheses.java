package com.white;

import java.util.ArrayList;
import java.util.List;

public class GenerateParentheses {

    // 22. Generate Parentheses
    public static List<String> generateParenthesis(int n) {
        
        List<String> result = new ArrayList<String>();
        if (n == 0) {
            return result;
        }
        helper(result, "", n, n);
        return result;
    }

    // Amazing solution, need to learn more about it
    private static void helper(List<String> res, String present, int left, int right) {
        if (right == 0) {
            res.add(present);
        }
        if (left > 0) {
            helper(res, present + "(", left - 1, right);
        }
        if (right > left) {
            helper(res, present + ")", left, right - 1);
        }
    }
}