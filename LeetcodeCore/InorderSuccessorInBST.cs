using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class InorderSuccessorInBST
    {
        // 285. Inorder Successor in BST
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            return SearchWithParent(null, root, p);
        }

        private TreeNode SearchWithParent(TreeNode parent, TreeNode root, TreeNode p)
        {
            if (root == p)
            {
                if (root.right == null)
                {
                    return parent;
                }
                else
                {
                    var nextNode = root.right;
                    while (nextNode.left != null) nextNode = nextNode.left;
                    return nextNode;
                }
            }
            else if (root.val > p.val)
            {
                if (root.left != null) return SearchWithParent(root, root.left, p);
                else return null;
            }
            else
            {
                if (root.right != null) return SearchWithParent(parent, root.right, p);
                else return null;
            }
        }
    }
}
