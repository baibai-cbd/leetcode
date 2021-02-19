using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class DeleteNodeInABST
    {
        // 450. Delete Node in a BST
        // Move the root towards the target node
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return null;

            if (root.val < key)
            {
                root.right = DeleteNode(root.right, key);
                return root;
            }
            else if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
                return root;
            }
            else
            {
                // found the node
                if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }

                var maxInLeft = FindMaxInLeft(root.left);
                var newNode = new TreeNode(maxInLeft.val, root.left, root.right);
                newNode.left = DeleteNode(root.left, maxInLeft.val);
                return newNode;
            }
        }

        private TreeNode FindMaxInLeft(TreeNode left)
        {
            var node = left;
            while (node.right != null)
                node = node.right;

            return node;
        }
    }
}
