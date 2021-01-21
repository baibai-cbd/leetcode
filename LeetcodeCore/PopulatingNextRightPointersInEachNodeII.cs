using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class PopulatingNextRightPointersInEachNodeII
    {
        // 117. Populating Next Right Pointers in Each Node II
        public Node Connect(Node root)
        {
            if (root == null) 
                return root;

            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var levelCount = queue.Count;
                for (int i = 0; i < levelCount - 1; i++)
                {
                    var curr = queue.Dequeue();
                    curr.next = queue.Peek();
                    if (curr.left != null) 
                        queue.Enqueue(curr.left);
                    if (curr.right != null) 
                        queue.Enqueue(curr.right);
                }
                var last = queue.Dequeue();
                if (last.left != null) 
                    queue.Enqueue(last.left);
                if (last.right != null) 
                    queue.Enqueue(last.right);
            }

            return root;
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}
