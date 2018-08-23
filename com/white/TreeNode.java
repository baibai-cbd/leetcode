package com.white;

    // problem 617

public class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
    TreeNode(int x) { val = x; }

    //

    public static TreeNode mergeTrees(TreeNode t1, TreeNode t2) {
        if (t1==null) {
            return t2;
        } else if (t2==null) {
            return t1;
        }
        if (t1.left != null && t2.left!=null) {
            mergeTrees(t1.left, t2.left);
        }
        if (t1.right!= null && t2.right!=null) {
            mergeTrees(t1.right, t2.right);
        }
        t1.val += t2.val;
        if(t1.left!=null || t2.left !=null)
            t1.left = (t1.left==null) ? t2.left: t1.left;
        if(t1.right!=null || t2.right!=null)
            t1.right = (t1.right==null) ? t2.right: t1.right;
        return t1;
    }
}
