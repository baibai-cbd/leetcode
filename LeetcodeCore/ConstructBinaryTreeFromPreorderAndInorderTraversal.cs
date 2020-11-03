using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        // 105. Construct Binary Tree from Preorder and Inorder Traversal
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null || preorder.Length == 0 || inorder.Length == 0)
                return null;

            return BuildTreeHelper(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
        }

        private TreeNode BuildTreeHelper(int[] preorder, int[] inorder, int preorderIndex0, int preorderIndex1, int inorderIndex0, int inorderIndex1)
        {
            if (preorderIndex0 > preorderIndex1 || inorderIndex0 > inorderIndex1)
                return null;

            var root = new TreeNode(preorder[preorderIndex0]);
            if (inorderIndex0 == inorderIndex1)
                return root;

            var rootIndex = Array.IndexOf(inorder, root.val);
            var leftCount = rootIndex - inorderIndex0;
            var rightCount = inorderIndex1 - rootIndex;

            root.left = BuildTreeHelper(preorder, inorder, preorderIndex0 + 1, preorderIndex1 - rightCount, inorderIndex0, rootIndex - 1);
            root.right = BuildTreeHelper(preorder, inorder, preorderIndex0 + 1 + leftCount, preorderIndex1, rootIndex + 1, inorderIndex1);
            return root;
        }
    }
}
