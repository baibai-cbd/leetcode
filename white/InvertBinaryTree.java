package com.white;

import java.util.LinkedList;
import java.util.Queue;

public class InvertBinaryTree {

    public TreeNode invertTree(TreeNode root) {
        Queue<TreeNode> queue = new LinkedList<>();

        if (root==null) {
            return null;
        }

        queue.offer(root);

        while(!queue.isEmpty()) {
            int size = queue.size();
            for (int i=0; i<size; i++) {
                TreeNode current = queue.poll();
                TreeNode temp = current.left;
                current.left = current.right;
                current.right = temp;
                if (current.left!=null) {
                    queue.offer(current.left);
                }
                if (current.right!=null) {
                    queue.offer(current.right);
                }
            }
        }

        return root;
    }
}
