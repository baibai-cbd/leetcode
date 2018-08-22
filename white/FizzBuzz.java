package com.white;

import java.util.ArrayList;
import java.util.List;

public class FizzBuzz {

    // problem 412

    public static List<String> fizzBuzz(int n) {
        ArrayList<String> result = new ArrayList<>(n);
        int fizzFlag = 0;
        int buzzFlag = 0;
        for (int i=1; i<=n; i++) {
            fizzFlag++;
            buzzFlag++;
//            result.add(Integer.valueOf(i).toString());
            if (buzzFlag == 5) {
                if (fizzFlag == 3) {
                    result.add("FizzBuzz");
                    fizzFlag = 0;
                    buzzFlag = 0;
                } else {
                    result.add("Buzz");
                    buzzFlag = 0;
                }
            } else if (fizzFlag == 3) {
                result.add("Fizz");
                fizzFlag = 0;
            } else {
                result.add(Integer.valueOf(i).toString());
            }
        }

        return result;
    }
}
