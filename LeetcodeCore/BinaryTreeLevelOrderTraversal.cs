using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class BinaryTreeLevelOrderTraversal
    {
        // 102. Binary Tree Level Order Traversal
        // One queue solution with keeping a record of queue size as the level size
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var resultList = new List<IList<int>>();
            if (root == null)
                return resultList;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var levelCount = queue.Count; // level count
            while (levelCount > 0)
            {
                var list = new List<int>();
                for (int i = 0; i < levelCount; i++)
                {
                    var node = queue.Dequeue();
                    list.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                resultList.Add(list);
                levelCount = queue.Count; // update level count
            }

            return resultList;
        }
    }
}
