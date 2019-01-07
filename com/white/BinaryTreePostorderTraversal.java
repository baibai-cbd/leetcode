package com.white;

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

public class BinaryTreePostorderTraversal {

	// 145. Binary Tree Postorder Traversal
	
	public static List<Integer> postorderTraversal(TreeNode root) {
        
		if (root==null) {
			return new ArrayList<Integer>();
		}
		ArrayList<Integer> arrayList = new ArrayList<>();
		Stack<TreeNode> stack = new Stack<>();
		
		postorderTraversalIterative(root, arrayList, stack);
		//postorderTraversalRecursive(root, arrayList);
		
		return arrayList;
    }
	
	
	public static void postorderTraversalIterative(TreeNode root, List<Integer> list, Stack<TreeNode> stack) {
        
		TreeNode curr = root;
		TreeNode record = null;
		TreeNode parent;
		
		while (curr!=null || !stack.empty()) {
			while (curr != null) {
				stack.push(curr);
				curr = curr.left;
			}
			
			parent = stack.peek();
			if (parent.right!=null) {
				if (record==parent.right) {
					curr = stack.pop();
					record = curr;
					list.add(curr.val);
					curr = null;
				} else {
					curr = parent.right;
				}
			} else {
				curr = stack.pop();
				record = curr;
				list.add(curr.val);
				curr = null;
			}
		}
		return;
    }
	
	
	public static void postorderTraversalRecursive(TreeNode root, List<Integer> list) {
        
		if (root==null)
			return;
		
		postorderTraversalRecursive(root.left, list);
		
		postorderTraversalRecursive(root.right, list);
		
		list.add(root.val);
		
		return;
    }
}
