using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ValidateBinarySearchTree
    {
        // 98. Validate Binary Search Tree
        public bool IsValidBST(TreeNode root)
        {
            var list = new List<int>();

            InorderTraverse(root, list);

            if (list.Count <= 1)
                return true;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] <= list[i-1])
                {
                    return false;
                }
            }

            return true;
        }

        private void InorderTraverse(TreeNode root, IList<int> list)
        {
            if (root == null)
                return;

            InorderTraverse(root.left, list);
            list.Add(root.val);
            InorderTraverse(root.right, list);
        }
    }
}
