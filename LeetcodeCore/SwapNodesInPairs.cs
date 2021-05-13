using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SwapNodesInPairs
    {
        // 24. Swap Nodes in Pairs
        public ListNode SwapPairs(ListNode head)
        {

            var dummy = new ListNode(0, head);
            RecursiveHelper(dummy, head);
            return dummy.next;
        }

        private void RecursiveHelper(ListNode pre, ListNode curr)
        {
            if (curr == null || curr.next == null)
                return;

            pre.next = curr.next;
            curr.next = pre.next.next;
            pre.next.next = curr;

            RecursiveHelper(curr, curr.next);
        }
    }
}
