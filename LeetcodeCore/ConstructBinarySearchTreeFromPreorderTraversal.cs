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
    }
}
