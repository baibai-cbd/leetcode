using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class CountGoodNodesInBinaryTree
    {
        // 1448. Count Good Nodes in Binary Tree
        public int GoodNodes(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            var count = 0;

            if (root != null)
                stack.Push(new TreeNode(root.val - 1));
            else
                return 0;

            RecursiveCall(root, stack, ref count);

            return count;
        }

        private void RecursiveCall(TreeNode root, Stack<TreeNode> stack, ref int count)
        {
            if (root == null)
                return;

            if (root.val >= stack.Peek().val)
            {
                stack.Push(root);
                count++;
            }

            RecursiveCall(root.left, stack, ref count);
            RecursiveCall(root.right, stack, ref count);

            if (root.val == stack.Peek().val)
                stack.Pop();
        }
    }
}
