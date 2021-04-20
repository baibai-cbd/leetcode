using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class AllNodesDistanceKInBinaryTree
    {
        // 863. All Nodes Distance K in Binary Tree
        // Basically build a graph yourself, then do BFS
        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            var results = new List<int>();
            var queue = new Queue<TreeNodeFull>();
            var visited = new HashSet<int>();

            var targetFull = (TreeNodeFull)default;
            var transformedRoot = TraverseTreeNodeFull(null, root, target, ref targetFull);

            if (targetFull == null)
                return results;

            var count = -1;
            queue.Enqueue(targetFull);
            visited.Add(targetFull.val);
            while (queue.Count > 0)
            {
                var queueSize = queue.Count;
                count++;
                if (count == K)
                {
                    for (int i = 0; i < queueSize; i++)
                    {
                        var currNode = queue.Dequeue();
                        results.Add(currNode.val);
                    }
                    break;
                }
                else
                {
                    for (int i = 0; i < queueSize; i++)
                    {
                        var currNode = queue.Dequeue();
                        visited.Add(currNode.val);
                        if (currNode.parent != null && !visited.Contains(currNode.parent.val)) queue.Enqueue(currNode.parent);
                        if (currNode.left != null && !visited.Contains(currNode.left.val)) queue.Enqueue(currNode.left);
                        if (currNode.right != null && !visited.Contains(currNode.right.val)) queue.Enqueue(currNode.right);
                    }
                }
            }

            return results;
        }

        private TreeNodeFull TraverseTreeNodeFull(TreeNodeFull parent, TreeNode root, TreeNode target, ref TreeNodeFull targetFull)
        {
            if (root == null)
                return null;

            var newRoot = new TreeNodeFull();
            newRoot.parent = parent;
            newRoot.val = root.val;
            if (ReferenceEquals(root,target))
                targetFull = newRoot;

            newRoot.left = TraverseTreeNodeFull(newRoot, root.left, target, ref targetFull);
            newRoot.right = TraverseTreeNodeFull(newRoot, root.right, target, ref targetFull);
            return newRoot;
        }

        public class TreeNodeFull
        {
            public TreeNodeFull parent;
            public TreeNodeFull left;
            public TreeNodeFull right;
            public int val;
        }
    }
}
