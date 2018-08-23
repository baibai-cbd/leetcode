package com.white;

import java.util.ArrayList;

public class TwoSumIV {

    public static boolean findTarget(TreeNode root, int k) {
        if (root==null || (root.left==null && root.right==null)) {
            return false;
        }

        ArrayList<Integer> arrayList = new ArrayList<>();
        traversal(root,arrayList);
        for (Integer i: arrayList) {
            int anchor = k-i;
            if (anchor==i) {
                continue;
            }
            if ((findPartialTarget(root,anchor))==true) {
                return true;
            }
        }
        return false;
    }

    private static void traversal(TreeNode root, ArrayList<Integer> arrayList) {
        if (root==null) {
            return;
        }
        arrayList.add(root.val);
        traversal(root.left,arrayList);
        traversal(root.right,arrayList);
    }

    private static boolean findPartialTarget(TreeNode root, int t) {
        if (root==null) {
            return false;
        }

        if (root.val==t) {
            return true;
        }

        if (t<root.val) {
            return findPartialTarget(root.left, t);
        } else {
            return findPartialTarget(root.right, t);
        }

        //return false;
    }
}
