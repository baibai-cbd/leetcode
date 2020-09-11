using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class UniqueBinarySearchTreesII
    {
        // 95. Unique Binary Search Trees II
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return new List<TreeNode>();

            return GenerateSubTrees(1, n);
        }

        private IList<TreeNode> GenerateSubTrees(int i, int j)
        {
            var list = new List<TreeNode>();
            if (i > j)
            {
                list.Add(null);
                return list;
            }

            if (i == j)
            {
                list.Add(new TreeNode(i));
                return list;
            }

            for (int k = i; k <= j; k++)
            {
                var leftNodes = GenerateSubTrees(i, k - 1);
                var rightNodes = GenerateSubTrees(k + 1, j);
                foreach (var LNode in leftNodes)
                {
                    foreach (var RNode in rightNodes)
                    {
                        var currNode = new TreeNode(k);
                        currNode.left = LNode;
                        currNode.right = RNode;
                        list.Add(currNode);
                    }
                }
            }
            return list;
        }
    }
}
