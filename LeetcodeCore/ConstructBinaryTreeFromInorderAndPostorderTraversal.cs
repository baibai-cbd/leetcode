using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class ConstructBinaryTreeFromInorderAndPostorderTraversal
    {
        // 106. Construct Binary Tree from Inorder and Postorder Traversal
        // try to improve complexity next time
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0 || postorder.Length == 0)
            {
                return null;
            }

            var root = BuildTreeHelper(inorder, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1);

            return root;
        }

        private TreeNode BuildTreeHelper(int[] inorder, int[] postorder, int inorderIndex0, int inorderIndex1, int postorderIndex0, int postorderIndex1)
        {
            var root = new TreeNode(postorder[postorderIndex1]);
            if (inorderIndex0 == inorderIndex1)
                return root;

            var rootIndex = Array.IndexOf(inorder, root.val);
            var leftCount = rootIndex - inorderIndex0;
            var rightCount = inorderIndex1 - rootIndex;
            if (leftCount > 0)
            {
                root.left = BuildTreeHelper(inorder, postorder, inorderIndex0, rootIndex - 1, postorderIndex0, postorderIndex1 - 1 - rightCount);
            }
            if (rightCount > 0)
            {
                root.right = BuildTreeHelper(inorder, postorder, rootIndex + 1, inorderIndex1, postorderIndex0 + leftCount, postorderIndex1 - 1);
            }

            return root;
        }
    }
}
