package com.white;

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

public class BinaryTreeInorderTraversal {

	// 94. Binary Tree Inorder Traversal
	
	public static List<Integer> inorderTraversal(TreeNode root) {
        
		if (root==null) {
			return new ArrayList<Integer>();
		}
		ArrayList<Integer> arrayList = new ArrayList<>();
		Stack<TreeNode> stack = new Stack<>();
		
		inorderTraversalIterative(root, arrayList, stack);
		//inorderTraversalRecursive(root, arrayList);
		
		return arrayList;
    }
	
	public static void inorderTraversalIterative(TreeNode root, List<Integer> list, Stack<TreeNode> stack) {
        
		TreeNode curr = root;
		
		while (curr!=null || !stack.empty()) {
			while (curr != null) {
				stack.push(curr);
				curr = curr.left;
			}
			
			curr = stack.pop();
			list.add(curr.val);
			
			curr = curr.right;
		}
		return;
    }
	
	public static void inorderTraversalRecursive(TreeNode root, List<Integer> list) {
        
		if (root==null)
			return;
		
		inorderTraversalRecursive(root.left, list);
		
		list.add(root.val);
		
		inorderTraversalRecursive(root.right, list);
		
		return;
    }
}
