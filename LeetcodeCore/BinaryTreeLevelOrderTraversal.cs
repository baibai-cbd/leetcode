using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class BinaryTreeLevelOrderTraversal
    {
        // 102. Binary Tree Level Order Traversal
        // TODO: Try one queue solution with keeping a record of queue size as the level size
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var resultList = new List<IList<int>>();
            if (root == null)
                return resultList;
            var queue1 = new Queue<TreeNode>();
            var queue2 = new Queue<TreeNode>();
            queue1.Enqueue(root);

            while (queue1.Count > 0 || queue2.Count > 0)
            {
                TraverseLevel(resultList, queue1, queue2);
                TraverseLevel(resultList, queue2, queue1);
            }

            return resultList;
        }

        private void TraverseLevel(IList<IList<int>> resultList, Queue<TreeNode> currQueue, Queue<TreeNode> nextQueue)
        {
            if (currQueue.Count == 0)
                return;

            var list = new List<int>();
            while (currQueue.Count > 0)
            {
                var node = currQueue.Dequeue();
                list.Add(node.val);
                if (node.left != null)
                    nextQueue.Enqueue(node.left);
                if (node.right != null)
                    nextQueue.Enqueue(node.right);
            }

            resultList.Add(list);
        }
    }
}
