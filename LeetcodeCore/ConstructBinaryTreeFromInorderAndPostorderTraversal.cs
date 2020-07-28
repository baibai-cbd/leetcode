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
            var root = new TreeNode(postorder[postorder.Length - 1]);
            if (inorder.Length == 1)
                return root;

            var leftCount = Array.IndexOf(inorder, root.val);
            var rightCount = inorder.Length - leftCount - 1;
            root.left = BuildTree(inorder.Take(leftCount).ToArray(), postorder.Take(leftCount).ToArray());
            root.right = BuildTree(inorder.Skip(leftCount + 1).Take(rightCount).ToArray(), postorder.Skip(leftCount).Take(rightCount).ToArray());

            return root;
        }
    }
}
