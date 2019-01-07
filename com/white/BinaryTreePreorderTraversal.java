package com.white;

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

public class BinaryTreePreorderTraversal {

	// 144. Binary Tree Preorder Traversal
	
	public static List<Integer> preorderTraversal(TreeNode root) {
        
		if (root==null) {
			return new ArrayList<Integer>();
		}
		ArrayList<Integer> arrayList = new ArrayList<>();
		Stack<TreeNode> stack = new Stack<>();
		
		preorderTraversalIterative(root, arrayList, stack);
		//preorderTraversalRecursive(root, arrayList);
		
		return arrayList;
    }
	
	
	public static void preorderTraversalIterative(TreeNode root, List<Integer> list, Stack<TreeNode> stack) {
        
		TreeNode curr = root;
		
		while (curr!=null || !stack.empty()) {
			while (curr != null) {
				stack.push(curr);
				list.add(curr.val);
				curr = curr.left;
			}
			
			curr = stack.pop();
			
			curr = curr.right;
		}
		return;
    }
	
	
	public static void preorderTraversalRecursive(TreeNode root, List<Integer> list) {
        
		if (root==null)
			return;
		
		list.add(root.val);
		
		preorderTraversalRecursive(root.left, list);
		
		preorderTraversalRecursive(root.right, list);
		
		return;
    }
}
