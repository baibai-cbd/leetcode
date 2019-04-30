package com.white;

public class StringToIntegerATOI {

	// 8. String to Integer (atoi)
	
	public static int myAtoi(String str) {
        
		if (str==null) {
			return 0;
		}
		str = str.trim();
		if (str.equals("")) {
			return 0;
		}
		
		StringBuilder sb = new StringBuilder(str);
		boolean positive = true;
		if (sb.charAt(0)=='-' || sb.charAt(0)=='+') {
			positive = sb.charAt(0)=='-' ? false : true;
			sb.deleteCharAt(0);
			if (sb.length()==0) {
				return 0;
			}
		}
		
		if (sb.charAt(0)>'9' || sb.charAt(0)<'0') {
			return 0;
		}
		
		int endIndex = 0;
		
		for (int i=0; i<sb.length(); i++) {
			if (sb.charAt(i)<'0' || sb.charAt(i)>'9') {
				break;
			} else {
				endIndex++;
			}
		}
		
		String forParse;
		
		if (!positive) {
			sb.insert(0, '-');
			forParse = sb.substring(0, endIndex+1);
		} else {
			forParse = sb.substring(0, endIndex);
		}
		
		int result;
		
		try {
			result = Integer.parseInt(forParse);
		} catch (NumberFormatException e) {
			if (positive) {
				return Integer.MAX_VALUE;
			} else {
				return Integer.MIN_VALUE;
			}
		}
		
		return result;
    }
}
