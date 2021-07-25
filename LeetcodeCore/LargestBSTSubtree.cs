using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LargestBSTSubtreeSolution
    {
        // 333. Largest BST Subtree
        public int LargestBSTSubtree(TreeNode root)
        {

            if (root == null)
                return 0;

            var result = TraverseForBST(root);
            return result.Item3;
        }

        private (int, int, int) TraverseForBST(TreeNode root)
        {
            if (root == null)
                return (int.MaxValue, int.MinValue, 0);

            var left = TraverseForBST(root.left);
            var right = TraverseForBST(root.right);

            if (root.val > left.Item2 && root.val < right.Item1)
                // pretty hard to get the min, max here right, just remember if subtree is one node, then root.val is both min & max
                return (Math.Min(left.Item1, root.val), Math.Max(right.Item2, root.val), left.Item3 + right.Item3 + 1);
            else
                return (int.MinValue, int.MaxValue, Math.Max(left.Item3, right.Item3));
        }
    }
}
