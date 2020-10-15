using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class BinaryTreeZigzagLevelOrderTraversal
    {
        // 103. Binary Tree Zigzag Level Order Traversal
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var resultList = new List<IList<int>>();
            if (root == null)
                return resultList;
            var stack1 = new Stack<TreeNode>();
            var stack2 = new Stack<TreeNode>();
            var flag = true;    // flag can be extracted as an input, to determine which way of zigzag it goes
            stack1.Push(root);

            while (stack1.Count != 0 || stack2.Count != 0)
            {
                if (stack1.Count != 0)
                {
                    resultList.Add(TraverseALevel(stack1, stack2, flag).ToList());
                    flag = !flag;
                }
                else if (stack2.Count != 0)
                {
                    resultList.Add(TraverseALevel(stack2, stack1, flag).ToList());
                    flag = !flag;
                }
            }

            return resultList;
        }

        private IEnumerable<int> TraverseALevel(Stack<TreeNode> giveStack, Stack<TreeNode> takeStack, bool flag)
        {
            while (giveStack.Count != 0)
            {
                var node = giveStack.Pop();
                if (flag)
                {
                    if (node.left != null) takeStack.Push(node.left);
                    if (node.right != null) takeStack.Push(node.right);
                }
                else
                {
                    if (node.right != null) takeStack.Push(node.right);
                    if (node.left != null) takeStack.Push(node.left);
                }
                yield return node.val;
            }
        }
    }
}
