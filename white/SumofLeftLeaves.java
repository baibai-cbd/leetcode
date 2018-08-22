package com.white;

public class SumofLeftLeaves {

    // 404. Sum of Left Leaves

    int sum;

    public int sumOfLeftLeaves(TreeNode root) {
        sum = 0;

        sumTraversal(root,false);

        return sum;
    }

    private void sumTraversal(TreeNode t, boolean add) {
        if (t==null) {
            return;
        }

        if (t.left==null && t.right==null && add) {
            sum += t.val;
            return;
        }

        sumTraversal(t.left,true);
        sumTraversal(t.right,false);
    }
}
