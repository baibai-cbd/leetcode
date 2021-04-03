using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class CountGoodNodesInBinaryTree
    {
        // 1448. Count Good Nodes in Binary Tree
        // max at different levels of the call stack implicitly keep records of the current max value
        public int GoodNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            var count = 0;
            RecursiveCall(root, root.val - 1, ref count);

            return count;
        }

        private void RecursiveCall(TreeNode root, int max, ref int count)
        {
            if (root == null)
                return;

            if (root.val >= max)
            {
                max = root.val;
                count++;
            }

            RecursiveCall(root.left, max, ref count);
            RecursiveCall(root.right, max, ref count);
        }
    }
}
