package com.white;

public class MaximumDepthOfBinaryTree {

    public static int maxDepth(TreeNode root) {
        if (root==null) {
            return 0;
        }
        if (root.left==null && root.right==null) {
            return 1;
        } else if (root.left==null) {
            return 1+maxDepth(root.right);
        } else if (root.right==null) {
            return 1+maxDepth(root.left);
        } else {
            int l = maxDepth(root.left);
            int r = maxDepth(root.right);
            return 1 + ((l>r) ? l : r);
        }
    }


    class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}
