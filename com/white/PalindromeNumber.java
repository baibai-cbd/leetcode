package com.white;

import java.util.ArrayList;

public class PalindromeNumber {

	// 9. Palindrome Number
	
	public static boolean isPalindrome(int x) {
        
		if (x<0)
			return false;
		
		ArrayList<Integer> arrayList = new ArrayList<>();
		int temp = x;
		
		while(temp>=10) {
			arrayList.add(temp%10);
			temp = temp/10;
		}
		arrayList.add(temp);
		
		int result=0;
		for (int i=0; i<arrayList.size(); i++) {
			result = result*10;
			result += arrayList.get(i);
		}
		
		return (result-x)==0 ? true : false;
    }
}
