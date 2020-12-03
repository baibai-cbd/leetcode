using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class DistributeCoinsInBinaryTree
    {
        // 979. Distribute Coins in Binary Tree
        public int DistributeCoins(TreeNode root)
        {
            var stepsCount = 0;
            TraverseHelper(root, ref stepsCount);
            return stepsCount;
        }

        private int TraverseHelper(TreeNode root, ref int count)
        {
            if (root == null)
                return 0;

            var leftRequest = TraverseHelper(root.left, ref count);
            var rightRequest = TraverseHelper(root.right, ref count);
            count += Math.Abs(leftRequest) + Math.Abs(rightRequest);
            return root.val - 1 + leftRequest + rightRequest;
        }
    }
}
