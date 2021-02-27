using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ConvertBinarySearchTreeToSortedDoublyLinkedList
    {
        // 426. Convert Binary Search Tree to Sorted Doubly Linked List
        public Node TreeToDoublyList(Node root)
        {
            if (root == null)
                return null;

            var result = ConvertSubTree(root);
            return result.Item1;
        }

        private ValueTuple<Node, Node> ConvertSubTree(Node root)
        {
            if (root.left == null && root.right == null)
            {
                root.left = root;
                root.right = root;
                return new ValueTuple<Node, Node>(root, root);
            }

            ValueTuple<Node, Node> leftTuple;
            ValueTuple<Node, Node> rightTuple;
            if (root.left != null && root.right == null)
            {
                leftTuple = ConvertSubTree(root.left);
                leftTuple.Item1.left = root;
                leftTuple.Item2.right = root;
                root.left = leftTuple.Item2;
                root.right = leftTuple.Item1;
                return (leftTuple.Item1, root);  // usage of tuple shorthand, (a, b) is same as ValueTuple<type1, type2>(a, b)
            }
            else if (root.left == null && root.right != null)
            {
                rightTuple = ConvertSubTree(root.right);
                rightTuple.Item1.left = root;
                rightTuple.Item2.right = root;
                root.right = rightTuple.Item1;
                root.left = rightTuple.Item2;
                return (root, rightTuple.Item2);
            }
            else
            {
                leftTuple = ConvertSubTree(root.left);
                rightTuple = ConvertSubTree(root.right);
                leftTuple.Item2.right = root;
                root.left = leftTuple.Item2;
                rightTuple.Item1.left = root;
                root.right = rightTuple.Item1;
                leftTuple.Item1.left = rightTuple.Item2;
                rightTuple.Item2.right = leftTuple.Item1;
                return (leftTuple.Item1, rightTuple.Item2);
            }
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
                left = null;
                right = null;
            }

            public Node(int _val, Node _left, Node _right)
            {
                val = _val;
                left = _left;
                right = _right;
            }
        }
    }
}
