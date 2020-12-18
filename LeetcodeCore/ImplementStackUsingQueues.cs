using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ImplementStackUsingQueues
    {
        // 225. Implement Stack using Queues
        // O(n) solution
    }

    public class MyStack
    {
        private Queue<int> queue1;
        private Queue<int> queue2;
        /** Initialize your data structure here. */
        public MyStack()
        {
            queue1 = new Queue<int>();
            queue2 = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            queue1.Enqueue(x);
            if (queue1.Count > 1)
                queue2.Enqueue(queue1.Dequeue());
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            if (queue1.Count == 0)
            {
                for (int i = 1; i <= queue2.Count - 1; i++)
                {
                    queue2.Enqueue(queue2.Dequeue());
                }
                queue1.Enqueue(queue2.Dequeue());
            }
            return queue1.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            if (queue1.Count == 0)
            {
                for (int i = 1; i <= queue2.Count - 1; i++)
                {
                    queue2.Enqueue(queue2.Dequeue());
                }
                queue1.Enqueue(queue2.Dequeue());
            }
            return queue1.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return queue1.Count == 0 && queue2.Count == 0;
        }
    }
}
