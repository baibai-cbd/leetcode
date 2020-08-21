using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ReorderListSolution
    {
        // 143. Reorder List
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null) return;

            //Find the middle of the list
            ListNode p1 = head;
            ListNode p2 = head;
            while (p2.next != null && p2.next.next != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;
            }

            //Reverse the half after middle  1->2->3->4->5->6 to 1->2->3->6->5->4
            ListNode preMid = p1;
            ListNode midHead = p1.next;
            while (midHead.next != null) // push midHead onwards and insert current into after preMid
            {
                ListNode current = midHead.next;
                midHead.next = current.next;
                current.next = preMid.next;
                preMid.next = current;
            }

            //Start reorder one by one  1->2->3->6->5->4 to 1->6->2->5->3->4
            p1 = head;
            p2 = preMid.next;
            while (p1 != preMid) // insert p2 into after p1 and before p1.next, updating p2 to be next node 
            {
                preMid.next = p2.next;
                p2.next = p1.next;
                p1.next = p2;
                p1 = p2.next;
                p2 = preMid.next;
            }
        }
    }
}
