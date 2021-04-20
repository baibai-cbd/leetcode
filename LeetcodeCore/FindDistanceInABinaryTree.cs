using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class FindDistanceInABinaryTree
    {
        // 1740. Find Distance in a Binary Tree
        // similar as LowestCommonAncestor problem
        public int FindDistance(TreeNode root, int p, int q)
        {
            var tupleResult = Traverse(root, p, q);
            return tupleResult.Item2;
        }

        private (bool, int, int) Traverse(TreeNode root, int p, int q)
        {
            if (root == null)
                return (false, -1, -1);

            var pDis = -1;
            var qDis = -1;
            if (root.val == p) pDis = 0;
            if (root.val == q) qDis = 0;

            var leftTuple = Traverse(root.left, p, q);
            var rightTuple = Traverse(root.right, p, q);

            if (leftTuple.Item1) return leftTuple;
            if (rightTuple.Item1) return rightTuple;

            if (leftTuple.Item2 >= 0) pDis = leftTuple.Item2 + 1;
            if (leftTuple.Item3 >= 0) qDis = leftTuple.Item3 + 1;
            if (rightTuple.Item2 >= 0) pDis = rightTuple.Item2 + 1;
            if (rightTuple.Item3 >= 0) qDis = rightTuple.Item3 + 1;

            if (pDis >= 0 && qDis >= 0)
                return (true, pDis + qDis, pDis + qDis);
            else
                return (false, pDis, qDis);
        }
    }
}
