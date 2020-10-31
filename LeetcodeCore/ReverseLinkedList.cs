using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ReverseLinkedList
    {
        // 206. Reverse Linked List
        // Iterative
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return head;
            var prev = (ListNode)null;
            var curr = head;

            while (curr.next != null)
            {
                var temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }

            curr.next = prev;
            return curr;
        }

        // Recursive
        public ListNode ReverseList2(ListNode head)
        {
            if (head == null)
                return head;

            return RecursiveReverse(null, head);
        }

        private ListNode RecursiveReverse(ListNode prev, ListNode curr)
        {
            if (curr.next == null)
            {
                curr.next = prev;
                return curr;
            }

            var newCurr = curr.next;
            curr.next = prev;
            return RecursiveReverse(curr, newCurr);
        }
    }
}
