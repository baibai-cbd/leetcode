using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class MiddleOfTheLinkedList
    {
        // 876. Middle of the Linked List
        public ListNode MiddleNode(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var moveFlag = false;

            var pointer1 = head;
            var pointer2 = head;

            while (pointer1.next != null)
            {
                pointer1 = pointer1.next;
                if (moveFlag)
                {
                    pointer2 = pointer2.next;
                }
                moveFlag = !moveFlag;
            }

            return moveFlag ? pointer2.next : pointer2;
        }
    }
}
