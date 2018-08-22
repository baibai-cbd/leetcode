package com.white;

public class BinaryTreeTilt {

    public int findTilt(TreeNode root) {
        tiltTraverse(root);

        return addTree(root);
    }

    public int addTree(TreeNode t) {
        if (t==null) {
            return 0;
        }
        return (t.val + addTree(t.left) + addTree(t.right));
    }

    public int tiltTraverse(TreeNode t) {
        if (t==null) {
            return 0;
        }

        int sumLeft = tiltTraverse(t.left);

        int sumRight = tiltTraverse(t.right);

        int temp = t.val;
        t.val = Math.abs(sumLeft-sumRight);
        return temp + sumLeft + sumRight;
    }
}
