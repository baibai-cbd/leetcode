package com.white;

import java.util.Stack;

public class BSTIterator{

	// 173. Binary Search Tree Iterator
	private Stack<TreeNode> stack;
	
	public BSTIterator(TreeNode root) {
		
		stack = new Stack<>();
		
		if (root==null)
			return;
		
        TreeNode curr = root;
        
        while (curr != null) {
			stack.push(curr);
			curr = curr.left;
		}
    }
    
    /** @return the next smallest number */
    public int next() {
        TreeNode r = stack.pop();
        traverseMinimum(r);
    	return r.val;
    }
    
    /** @return whether we have a next smallest number */
    public boolean hasNext() {
    	return !stack.empty();
    }
    
    private void traverseMinimum(TreeNode t) {
    	TreeNode curr = t;
    	if (curr.right==null) {
			return;
		} else {
			curr = curr.right;
			while (curr != null) {
				stack.push(curr);
				curr = curr.left;
			}
		}
    }
}
