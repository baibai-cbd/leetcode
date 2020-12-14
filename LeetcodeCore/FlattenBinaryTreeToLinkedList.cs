using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class FlattenBinaryTreeToLinkedList
    {
        // 114. Flatten Binary Tree to Linked List
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;

            PreOrderHelper(root);
        }

        // Return the 'end leaf' of current subtree
        private TreeNode PreOrderHelper(TreeNode root)
        {
            if (root.left == null && root.right == null)
                return root;

            if (root.left == null)
            {
                return PreOrderHelper(root.right);
            }
            else if (root.right == null)
            {
                root.right = root.left;
                root.left = null;
                return PreOrderHelper(root.right);
            }
            else
            {
                var leftLeaf = PreOrderHelper(root.left);
                leftLeaf.right = root.right;
                root.right = root.left;
                root.left = null;
                return PreOrderHelper(leftLeaf.right);
            }
        }
    }
}
