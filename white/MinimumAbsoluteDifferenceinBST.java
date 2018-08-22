package com.white;

import java.util.ArrayList;

public class MinimumAbsoluteDifferenceinBST {

    // 530. Minimum Absolute Difference in BST

    ArrayList<Integer> arrayList;

    public int getMinimumDifference(TreeNode root) {
        arrayList = new ArrayList<>();

        inorderTraversal(root);

        int minimumDifference = Integer.MAX_VALUE;
        for (int i=0; i<arrayList.size()-1; i++) {
            int temp = Math.abs(arrayList.get(i)-arrayList.get(i+1));
            if (temp<minimumDifference) {
                minimumDifference = temp;
            }
        }
        return minimumDifference;
    }

    private void inorderTraversal(TreeNode t) {
        if (t==null) {
            return;
        }

        inorderTraversal(t.left);

        arrayList.add(t.val);

        inorderTraversal(t.right);

        return;
    }
}
