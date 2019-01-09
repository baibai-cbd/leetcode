package com.white;

import java.util.Stack;

public class EvaluateReversePolishNotation {

	// 150. Evaluate Reverse Polish Notation
	
	public static int evalRPN(String[] tokens) {
        
		Stack<String> stack = new Stack<>();
		int a,b,c;
		
		for (String s : tokens) {
			switch (s) {
			case "+":
				a = Integer.parseInt(stack.pop());
				b = Integer.parseInt(stack.pop());
				c = a + b;
				stack.push(Integer.toString(c));
				break;

			case "-":
				a = Integer.parseInt(stack.pop());
				b = Integer.parseInt(stack.pop());
				c = b - a;
				stack.push(Integer.toString(c));
				break;
				
			case "*":
				a = Integer.parseInt(stack.pop());
				b = Integer.parseInt(stack.pop());
				c = a * b;
				stack.push(Integer.toString(c));
				break;
				
			case "/":
				a = Integer.parseInt(stack.pop());
				b = Integer.parseInt(stack.pop());
				c = b / a;
				stack.push(Integer.toString(c));
				break;
				
			default:
				stack.push(s);
				break;
			}
		}
		
		return Integer.parseInt(stack.pop());
    }
}
