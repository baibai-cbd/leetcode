using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class PathSumIII
    {
        // 437. Path Sum III
        public int PathSum(TreeNode root, int sum)
        {
            if (root == null) return 0;
            return PathSumFrom(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
        }

        private int PathSumFrom(TreeNode node, int sum)
        {
            if (node == null) return 0;
            return (node.val == sum ? 1 : 0)
                + PathSumFrom(node.left, sum - node.val) + PathSumFrom(node.right, sum - node.val);
        }
    }
}
