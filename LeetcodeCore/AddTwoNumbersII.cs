using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class AddTwoNumbersII
    {
        // 445. Add Two Numbers II
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var newL1 = ReverseLinkedList(l1);
            var newL2 = ReverseLinkedList(l2);
            var dummy = new ListNode(0);
            var currNode = dummy;
            var increment = 0;
            while (newL1 != null || newL2 != null || increment != 0)
            {
                var sum = (newL1 == null ? 0 : newL1.val) + (newL2 == null ? 0 : newL2.val) + increment;
                
                currNode.next = new ListNode(sum % 10);
                currNode = currNode.next;

                increment = sum / 10;
                newL1 = newL1 == null ? newL1 : newL1.next;
                newL2 = newL2 == null ? newL2 : newL2.next;
            }

            return ReverseLinkedList(dummy.next);
        }

        private ListNode ReverseLinkedList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var currNode = head;
            var nextNode = head.next;
            currNode.next = null;
            while (nextNode != null)
            {
                var temp = nextNode.next;
                nextNode.next = currNode;
                currNode = nextNode;
                nextNode = temp;
            }
            return currNode;
        }
    }
}
