using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    // 155. Min Stack
    // This way is storing old min each time when new min generates
    // TODO: There's better solution of doing without using library Stack, rather implementing new data structure
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
}
