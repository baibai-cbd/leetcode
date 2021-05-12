using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class PalindromeLinkedList
    {
        // 234. Palindrome Linked List
        // This solution actually modify the linkedlist by reversing half of it
        public bool IsPalindrome(ListNode head)
        {
            if (head == null) 
                return false;

            var slow = head;
            var fast = head;
            var pre = slow;
            var next = slow.next;

            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                pre = slow;
                slow = next;
                next = next.next;
                slow.next = pre;
            }

            // this means odd number of linkedList nodes
            // because we start from the same middle node, the middle one can be skipped
            // while if it's even number of nodes, don't need to do anything
            if (fast.next == null)
            {
                slow = slow.next;
            }

            while (next != null)
            {
                if (next.val != slow.val)
                    return false;

                slow = slow.next;
                next = next.next;
            }
            return true;
        }



        // Nice Recursive solution
        // with functional programming idea in it
        public bool IsPalindrome2(ListNode head)
        {
            var refHead = head;
            return RecursiveHelper(head, ref refHead);
        }

        // not touching ref head when traversing the linkedlist
        // only start move the ref head when reaching the end of the linkedlist
        // by the effect of returning along the call stack, it's effectively moving both from the end(curr) and start(ref head) at the same time and converge in the middle
        private bool RecursiveHelper(ListNode curr, ref ListNode head)
        {
            if (curr.next == null)
            {
                return curr.val == head.val;
            }

            var result = RecursiveHelper(curr.next, ref head);
            head = head.next;
            return result && curr.val == head.val;
        }
    }
}
