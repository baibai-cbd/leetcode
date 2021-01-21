using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class BuildTreeWithPostfixExpression
    {
        // This problem is easy compared to build expression tree with infix expression
        public TreeNode ExpTree(char[] chars)
        {
            var stack = new Stack<TreeNode>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!IsOperator(chars[i]))
                {
                    stack.Push(new TreeNode(chars[i]));
                }
                else
                {
                    var node = new TreeNode(chars[i]);
                    var n1 = stack.Pop();
                    var n2 = stack.Pop();
                    node.right = n1;
                    node.left = n2;
                    stack.Push(node);
                }
            }
            return stack.Peek();
        }

        private bool IsOperator(char c)
            => c == '+' || c == '-' || c == '*' || c == '/';

        public class TreeNode
        {
            public char value;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(char c)
            {
                value = c;
            }
        }
    }
}
