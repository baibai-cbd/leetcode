package com.white;

public class CountCompleteTreeNodes {

    // 222. Count Complete Tree Nodes
    private static int height(TreeNode root) {
        return root == null ? 0 : 1 + height(root.left);
    }

    public static int countNodes(TreeNode root) {
        int h = height(root);
    
        if (h < 1) {
            return 0;
        }
        if (height(root.right) == h-1) {
            return (1 << h-1) + countNodes(root.right);
        } else {
            return (1 << h-2) + countNodes(root.left);
        }
    }
}