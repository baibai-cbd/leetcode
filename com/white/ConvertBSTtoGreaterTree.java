package com.white;

import java.util.ArrayList;

public class ConvertBSTtoGreaterTree {

    ArrayList<Integer> arrayList = new ArrayList<>();

    public TreeNode convertBST(TreeNode root) {
        addTraversal(root);
        //
        changeTraversal(root);
        return root;
    }

    private void addTraversal(TreeNode t) {
        if (t==null) {
            return;
        }
        addTraversal(t.left);
        arrayList.add(t.val);
        addTraversal(t.right);
    }

    private void changeTraversal(TreeNode t) {
        if (t==null) {
            return;
        }

        int val = t.val;
        int sum = t.val;
        for (int i=arrayList.size()-1; i>=0; i--) {
            int temp = arrayList.get(i);
            if (temp==val) {
                break;
            }
            sum += temp;
        }
        t.val = sum;

        changeTraversal(t.left);
        changeTraversal(t.right);
    }
}
