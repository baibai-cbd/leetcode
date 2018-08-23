package com.white;

public class SameTree {

    // 100. Same Tree

    public boolean isSameTree(TreeNode p, TreeNode q) {
        ConstructStringfromBinaryTree con = new ConstructStringfromBinaryTree();

        String s1 = con.tree2str(p);
        con.sb = new StringBuilder();
        String s2 = con.tree2str(q);

        return (s1.equals(s2));
    }
}
