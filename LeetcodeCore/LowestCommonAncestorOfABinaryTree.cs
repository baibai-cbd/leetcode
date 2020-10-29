using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LowestCommonAncestorOfABinaryTree
    {
        // 236. Lowest Common Ancestor of a Binary Tree
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            if (root == p || root == q)
                return root;

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            if (left == null && right != null)
                return right;
            else if (left != null && right == null)
                return left;
            else if (left != null && right != null)
                return root;
            else
                return null;
        }
    }
}
