using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ImplementQueueUsingStacks
    {
        // 232. Implement Queue using Stacks
        // Two stacks solution, with O(1) average complexity
    }

    public class MyQueue
    {
        private Stack<int> _pushStack;
        private Stack<int> _popStack;

        /** Initialize your data structure here. */
        public MyQueue()
        {
            _pushStack = new Stack<int>();
            _popStack = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            _pushStack.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            if (_popStack.Count > 0)
            {
                return _popStack.Pop();
            }
            else
            {
                while (_pushStack.Count > 0)
                {
                    _popStack.Push(_pushStack.Pop()); // Once the elements are moved to the popstack, their relative positions are fixed, so no need to move them, but only waiting them to be poped
                }
                return _popStack.Pop();
            }
        }

        /** Get the front element. */
        public int Peek()
        {
            if (_popStack.Count > 0)
            {
                return _popStack.Peek();
            }
            else
            {
                while (_pushStack.Count > 0)
                {
                    _popStack.Push(_pushStack.Pop());
                }
                return _popStack.Peek();
            }
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return _pushStack.Count == 0 && _popStack.Count == 0;
        }
    }
}
