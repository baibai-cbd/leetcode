using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class PalindromeLinkedList
    {
        // 234. Palindrome Linked List
        // TODO: there's a nice solution with recursion, try that next time
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
    }
}
