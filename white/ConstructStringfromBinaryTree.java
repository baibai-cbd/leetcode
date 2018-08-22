package com.white;

public class ConstructStringfromBinaryTree {

    StringBuilder sb = new StringBuilder();

    public String tree2str(TreeNode t) {
        traversal(t);
        String output = sb.toString();
        if (output.length()==2) {
            return "";
        }
        output = output.substring(1, output.length() - 1);
        return output;
    }

    private void traversal(TreeNode t) {
        if (t==null) {
            sb.append("()");
            return;
        }

        sb.append("("+t.val);

        if (t.left!=null && t.right==null) {
            traversal(t.left);
        }

        if (t.left==null && t.right!=null) {
            traversal(t.left);
            traversal(t.right);
        }

        if (t.left!=null && t.right!=null) {
            traversal(t.left);
            traversal(t.right);
        }

        sb.append(")");
        return;
    }
}
