using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class VerticalOrderTraversalOfABinaryTree
    {
        // 987. Vertical Order Traversal of a Binary Tree
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            var list = new List<CoordinatedTreeNode>();
            var queue = new Queue<CoordinatedTreeNode>();
            var result = new List<IList<int>>();
            
            var newRoot = new CoordinatedTreeNode(root.val, 0, 0, root.left, root.right);
            queue.Enqueue(newRoot);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                list.Add(node);
                if (node.left != null) 
                    queue.Enqueue(new CoordinatedTreeNode(node.left.val, node._x - 1, node._y - 1, node.left.left, node.left.right));
                if (node.right != null)
                    queue.Enqueue(new CoordinatedTreeNode(node.right.val, node._x + 1, node._y - 1, node.right.left, node.right.right));
            }

            list.Sort();

            int i = 0;
            int j = 0;
            while (j < list.Count)
            {
                while (list[j]._x == list[i]._x)
                {
                    j++;
                    if (j == list.Count) 
                        break;
                }
                result.Add(list.GetRange(i, j - i).Select(n => n.val).ToArray());
                i = j;
            }

            return result;
        }
    }

    public class CoordinatedTreeNode : TreeNode, IComparable<CoordinatedTreeNode>
    {
        public int _x;
        public int _y;

        public CoordinatedTreeNode(int val, int x, int y, TreeNode left, TreeNode right) : base(val, left, right)
        {
            _x = x;
            _y = y;
        }

        public int CompareTo(CoordinatedTreeNode other)
        {
            if (_x < other._x)
                return -1;
            if (_x > other._x)
                return 1;
            if (_y > other._y)
                return -1;
            if (_y < other._y)
                return 1;
            return val - other.val;
        }
    }
}
