using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class OddEvenLinkedList
    {
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var dummyHead = new ListNode(0);
            dummyHead.next = head;
            var counter = 2;
            var oddTail = head;
            var evenHead = new ListNode(1);
            var evenTail = evenHead;
            var currNode = head.next;
            while (currNode != null)
            {
                if (counter % 2 == 0)
                {
                    evenTail.next = currNode;
                    evenTail = currNode;
                }
                else
                {
                    oddTail.next = currNode;
                    oddTail = currNode;
                }
                currNode = currNode.next;
                counter++;
            }
            oddTail.next = evenHead.next;
            evenTail.next = null;
            return dummyHead.next;
        }
    }
}
