package com.white;

import java.util.HashSet;
import java.util.List;

public class WordBreak {

    // 139. Word Break
    public boolean wordBreak(String s, List<String> wordDict) {
        
        HashSet<String> hs = new HashSet<>();
        for (String w : wordDict) {
            hs.add(w);
        }

        boolean[] flags = new boolean[s.length()+1];
        flags[0] = true;
        for (int i = 1; i <= s.length(); i++) {
            for(int j=0; j<i; j++) {
                if (flags[j] && hs.contains(s.substring(j,i))) {
                    flags[i] = true;
                    break;
                }
            }    
        }

        return flags[s.length()];
    }
} 