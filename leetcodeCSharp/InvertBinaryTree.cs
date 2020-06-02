using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class InvertBinaryTree
    {
        // 226. Invert Binary Tree
        public TreeNode InvertTree(TreeNode root)
        {
            InvertTraverse(root);
            return root;
        }

        private void InvertTraverse(TreeNode node)
        {
            if (node == null)
                return;

            InvertTraverse(node.left);
            InvertTraverse(node.right);

            var temp = node.left;
            node.left = node.right;
            node.right = temp;
        }
    }
}
