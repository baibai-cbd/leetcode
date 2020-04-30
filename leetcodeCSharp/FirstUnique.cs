using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class FirstUnique
    {
        private readonly Dictionary<int,int> dict = new Dictionary<int, int>();
        private readonly Queue<int> queue = new Queue<int>();

        public FirstUnique(int[] nums)
        {
            foreach (var i in nums)
            {
                Add(i);
            }
        }

        public int ShowFirstUnique()
        {
            return queue.Count == 0 ? -1 : queue.Peek();
        }

        public void Add(int value)
        {
            if (dict.ContainsKey(value))
            {
                dict[value] += 1;
                if (queue.Count == 0)
                    return;
                if (queue.Peek() == value)
                {
                    while (dict[queue.Peek()] > 1)
                    {
                        queue.Dequeue();
                        if (queue.Count == 0)
                            return;
                    }
                }
            }
            else
            {
                dict.Add(value, 1);
                queue.Enqueue(value);
            }
        }
    }
}
