using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class ConstructBinarySearchTreeFromPreorderTraversal
    {
        // 1008. Construct Binary Search Tree from Preorder Traversal
        // Not the optimal solution, this is O(n^2)
        public TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder.Length == 0)
                return null;

            var root = new TreeNode(preorder[0]);
            if (preorder.Length == 1)
                return root;

            int i = 1;
            while (i < preorder.Length && preorder[i] < root.val)
            {
                i++;
            }
            var leftLength = i - 1;
            var rightLength = preorder.Length - i;
            if (leftLength != 0)
            {
                int[] arrLeft = new int[leftLength];
                Array.Copy(preorder, 1, arrLeft, 0, leftLength);
                root.left = BstFromPreorder(arrLeft);
            }
            if (rightLength != 0)
            {
                int[] arrRight = new int[rightLength];
                Array.Copy(preorder, i, arrRight, 0, rightLength);
                root.right = BstFromPreorder(arrRight);
            }
            return root;
        }


        // Without extra space
        public TreeNode BstFromPreorder1(int[] preorder)
        {
            if (preorder.Length == 0)
                return null;

            return BstFromPreorderWithIndex(preorder, 0, preorder.Length - 1);
        }

        private TreeNode BstFromPreorderWithIndex(int[] preorder, int start, int end)
        {
            var root = new TreeNode(preorder[start]);
            if (start == end)
                return root;

            int i = start + 1;
            while (i <= end && preorder[i] < root.val)
            {
                i++;
            }

            var leftLength = i - 1 - start;
            var rightLength = end + 1 - i;

            if (leftLength != 0)
            {
                root.left = BstFromPreorderWithIndex(preorder, start + 1, start + leftLength);
            }
            if (rightLength != 0)
            {
                root.right = BstFromPreorderWithIndex(preorder, end - rightLength + 1, end);
            }

            return root;
        }
    }
}
