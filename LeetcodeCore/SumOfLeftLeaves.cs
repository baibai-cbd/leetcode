using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SumOfLeftLeavesSolution
    {
        // 404. Sum of Left Leaves
        public int SumOfLeftLeaves(TreeNode root)
        {
            var sum = TraverseWithFlag(root, false);
            return sum;
        }

        private int TraverseWithFlag(TreeNode node, bool isLeft)
        {
            var r = 0;
            if (node == null)
                return r;

            if (node.left == null && node.right == null && isLeft)
                r += node.val;

            r += TraverseWithFlag(node.left, true);
            r += TraverseWithFlag(node.right, false);

            return r;
        }
    }
}
