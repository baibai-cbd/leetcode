using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MergeTwoSortedLists
    {
        // 21. Merge Two Sorted Lists
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            var dummy = new ListNode(0);
            var currHead = dummy;

            while (l1 != null || l2 != null)
            {
                if (l1 == null)
                {
                    currHead.next = l2;
                    l2 = l2.next;
                }
                else if (l2 == null)
                {
                    currHead.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    if (l1.val < l2.val)
                    {
                        currHead.next = l1;
                        l1 = l1.next;
                    }
                    else
                    {
                        currHead.next = l2;
                        l2 = l2.next;
                    }
                }
                currHead = currHead.next;
                currHead.next = null;
            }

            return dummy.next;
        }
    }
}
