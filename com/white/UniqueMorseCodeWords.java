package com.white;

import java.util.HashSet;

public class UniqueMorseCodeWords {

    // problem 804
    // [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]

    public static int uniqueMorseRepresentations(String[] words) {

        String[] characterMaps = {".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
        HashSet<String> hashSet = new HashSet<>();

        for (String word: words) {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i=0; i<word.length(); i++) {
                stringBuilder.append(characterMaps[word.charAt(i)-'a']);
            }
            hashSet.add(stringBuilder.toString());
        }

        return hashSet.size();
    }
}
