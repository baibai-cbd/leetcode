using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class AddTwoNumbersSolution
    {
        // 2. Add Two Numbers
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var a = l1.val;
            var b = l2.val;
            var c = 0;
            var dummy = new ListNode(0);
            var curr = dummy;

            while (a != 0 || b != 0 || c != 0 || l1 != null || l2 != null)
            {
                var sum = a + b + c;
                var mod = sum % 10;
                curr.next = new ListNode(mod);
                curr = curr.next;
                c = sum / 10;
                l1 = l1?.next;
                l2 = l2?.next;
                a = l1 == null ? 0 : l1.val;
                b = l2 == null ? 0 : l2.val;
            }

            return dummy.next;
        }
    }
}
