using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class InsertIntoABinarySearchTree
    {
        // 701. Insert into a Binary Search Tree
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }
            TreeNode node1 = root;
            bool insertLeft;
            while (true)
            {
                if (node1.val > val)
                {
                    if (node1.left != null)
                    {
                        node1 = node1.left;
                        continue;
                    }
                    else
                    {
                        insertLeft = true;
                        break;
                    }
                }
                if (node1.val < val)
                {
                    if (node1.right != null)
                    {
                        node1 = node1.right;
                        continue;
                    }
                    else
                    {
                        insertLeft = false;
                        break;
                    }
                }
            }

            if (insertLeft)
            {
                node1.left = new TreeNode(val);
            }
            else
            {
                node1.right = new TreeNode(val);
            }

            return root;
        }
    }
}
