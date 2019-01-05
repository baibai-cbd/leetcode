package com.white;

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

public class BinaryTreeZigzagLevelOrderTraversal {

	// 103. Binary Tree Zigzag Level Order Traversal
	
	public static List<List<Integer>> zigzagLevelOrder(TreeNode root) {
        
		ArrayList<List<Integer>> bigList = new ArrayList<>();
		
		if (root==null)
			return bigList;
		
		Stack<TreeNode> stack1 = new Stack<>();
		Stack<TreeNode> stack2 = new Stack<>();
		
		stack1.push(root);
		
		while (!stack1.empty() || !stack2.empty()) {
			
			ArrayList<Integer> smallList = new ArrayList<>();
			
			if (!stack1.empty()) {
				while (!stack1.empty()) {
					TreeNode temp = stack1.pop();
					smallList.add(temp.val);
					if (temp.left!=null)
						stack2.push(temp.left);
					if (temp.right!=null)
						stack2.push(temp.right);
				}
				bigList.add(smallList);
			} else {
				while (!stack2.empty()) {
					TreeNode temp = stack2.pop();
					smallList.add(temp.val);
					if (temp.right!=null)
						stack1.push(temp.right);
					if (temp.left!=null)
						stack1.push(temp.left);
				}
				bigList.add(smallList);
			}
		}
		
		return bigList;
    }
}
