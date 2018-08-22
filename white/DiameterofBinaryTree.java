package com.white;

public class DiameterofBinaryTree {

    // 543. Diameter of Binary Tree

    public int diameterOfBinaryTree(TreeNode root) {
        if (root==null) {
            return 0;
        }

        helper(root);
        return helper2(root);
    }

    public int helper(TreeNode t) {
        if (t==null) {
            return 0;
        }
        if (t.left==null && t.right==null) {
            t.val=0;
            return 1;
        }

        int l = helper(t.left);
        int r = helper(t.right);
        t.val = l + r;
        return Math.max(l,r) + 1;
    }

    public int helper2(TreeNode t) {
        if (t==null) {
            return 0;
        }

        int l = helper2(t.left);
        int r = helper2(t.right);

        return Math.max(Math.max(l,r),t.val);
    }
}
