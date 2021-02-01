using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class BalancedBinaryTree
    {
        // 110. Balanced Binary Tree
        public bool IsBalanced(TreeNode root)
        {
            return Traverse(root) != -1;
        }

        private int Traverse(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1;

            var left = Traverse(root.left);
            var right = Traverse(root.right);

            if (left == -1 || right == -1) 
                return -1;
            else if (Math.Abs(left - right) >= 2)
                return -1;
            else
                return Math.Max(left, right) + 1;
        }
    }
}
