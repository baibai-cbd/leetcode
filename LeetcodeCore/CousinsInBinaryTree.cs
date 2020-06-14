using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class CousinsInBinaryTree
    {
        // 993. Cousins in Binary Tree
        public bool IsCousins(TreeNode root, int x, int y)
        {
            if (root.val == x || root.val == y)
                return false;
            var tupleX = new Tuple<int, int, int>(x, int.MinValue, 0);
            var tupleY = new Tuple<int, int, int>(y, int.MaxValue, 0);
            TraverseHelper(root, 1, 0, ref tupleX, ref tupleY);
            return tupleX.Item2 == tupleY.Item2 && tupleX.Item3 != tupleY.Item3;
        }

        private void TraverseHelper(TreeNode node, int depth, int parentVal, ref Tuple<int,int,int> t1, ref Tuple<int,int,int> t2)
        {
            if (node == null)
                return;

            if (node.val == t1.Item1)
                t1 = new Tuple<int,int,int>(t1.Item1, depth, parentVal);
            if (node.val == t2.Item1)
                t2 = new Tuple<int,int,int>(t2.Item1, depth, parentVal);

            TraverseHelper(node.left, depth + 1, node.val, ref t1, ref t2);
            TraverseHelper(node.right, depth + 1, node.val, ref t1, ref t2);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
