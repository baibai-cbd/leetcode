package com.white;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class SubstringWithConcatenationOfAllWords {

    // 30. Substring with Concatenation of All Words
    public static List<Integer> findSubstring(String s, String[] words) {
        
        ArrayList<Integer> resultList = new ArrayList<>();
        if (s == null || s.isEmpty() || words == null || words.length==0) {
            return resultList;
        }
        int wordLength = words[0].length();

        HashMap<String, Integer> map = new HashMap<>();
        for (String w : words)
            map.put(w, map.containsKey(w) ? map.get(w)+1 : 1);
        
        for (int i = 0; i <= s.length()-wordLength*words.length; i++) {
            HashMap<String, Integer> copy = new HashMap<>(map);
            for (int j=0; j<words.length; j++) {
                String str = s.substring(i+j*wordLength, i+j*wordLength+wordLength);
                if (copy.containsKey(str)) {
                    int count = copy.get(str);
                    if (count==1) 
                        copy.remove(str);
                    else 
                        copy.put(str, count-1);
                    if (copy.isEmpty()) {
                        resultList.add(i);
                    }
                } else {
                    break;
                }
            }
        }

        return resultList;
    }
}