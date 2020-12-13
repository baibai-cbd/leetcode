using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    // 155. Min Stack
    // This way is storing old min each time when new min generates
    public class MinStack
    {
        private Stack<int> _stack;
        private int _min;

        public MinStack()
        {
            _stack = new Stack<int>();
            _min = int.MaxValue;
        }

        public void Push(int x)
        {
            if (x <= _min)
            {
                _stack.Push(_min);
                _min = x;
            }
            _stack.Push(x);
        }

        public void Pop()
        {
            if (_stack.Pop() == _min)
                _min = _stack.Pop();
        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _min;
        }
    }

    // There's better solution of doing without using library Stack, rather implementing new data structure
    // Use LinkedList nodes
    public class MinStack2
    {
        private NodeWithMin head;

        public MinStack2()
        {
        }

        public void Push(int x)
        {
            if (head == null)
                head = new NodeWithMin(x, x, null);
            else
                head = new NodeWithMin(x, Math.Min(x, head.min), head);
        }

        public void Pop()
        {
            head = head.next;
        }

        public int Top()
        {
            return head.val;
        }

        public int GetMin()
        {
            return head.min;
        }
    }

    public class NodeWithMin
    {
        public int val;
        public int min;
        public NodeWithMin next;

        public NodeWithMin(int val, int min, NodeWithMin next)
        {
            this.val = val;
            this.min = min;
            this.next = next;
        }
    }
}
