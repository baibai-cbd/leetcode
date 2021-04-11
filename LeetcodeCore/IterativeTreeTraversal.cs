using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class IterativeTreeTraversal
    {
        public static void IterativePostorderTraverse(TreeNode root)
        {
            if (root == null)
                return;

            var stack1 = new Stack<TreeNode>();
            var stack2 = new Stack<TreeNode>();
            
            stack1.Push(root);
            while (stack1.Count > 0)
            {
                var node = stack1.Pop();
                stack2.Push(node);
                if (node.left != null)
                    stack1.Push(node.left);
                if (node.right != null)
                    stack1.Push(node.right);
            }
            while (stack2.Count > 0)
            {
                Console.WriteLine(stack2.Pop().val);
            }
        }

        public static void IterativeInorderTraverse(TreeNode root)
        {
            if (root == null)
                return;

            var stack = new Stack<TreeNode>();
            var currNode = root;

            while (stack.Count > 0 || currNode != null)
            {
                while (currNode != null)
                {
                    stack.Push(currNode);
                    currNode = currNode.left;
                }
                currNode = stack.Pop();
                Console.WriteLine(currNode.val);
                currNode = currNode.right;
            }
        }

        public static void IterativePreorderTraverse(TreeNode root)
        {
            if (root == null)
                return;

            var stack = new Stack<TreeNode>();
            var currNode = root;

            while (stack.Count > 0 || currNode != null)
            {
                while (currNode != null)
                {
                    Console.WriteLine(currNode.val);
                    stack.Push(currNode);
                    currNode = currNode.left;
                }
                currNode = stack.Pop();
                currNode = currNode.right;
            }
        }
    }
}
