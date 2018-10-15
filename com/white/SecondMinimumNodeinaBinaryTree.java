package com.white;

public class SecondMinimumNodeinaBinaryTree {

    // 671. Second Minimum Node in a Binary Tree

    int candidate;
    int rootVal;

    public int findSecondMinimumValue(TreeNode root) {
        if (root==null) {
            return -1;
        }
        candidate = Integer.MAX_VALUE;
        rootVal = root.val;

        helper(root);

        if (candidate==Integer.MAX_VALUE) {
            return -1;
        } else {
            return candidate;
        }
    }

    private void helper(TreeNode t) {
        if (t==null) {
            return;
        }

        if (t.val>rootVal && t.val<candidate) {
            candidate = t.val;
        }

        helper(t.left);
        helper(t.right);
    }
}
