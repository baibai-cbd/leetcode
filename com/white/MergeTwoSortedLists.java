package com.white;

public class MergeTwoSortedLists {

    // 21. Merge Two Sorted Lists
    // can try optimizing for memory usage
    public static ListNode mergeTwoLists(ListNode l1, ListNode l2) {
        if (l1==null) {
            return l2;
        }
        if (l2==null) {
            return l1;
        }

        ListNode dummyHead = new ListNode(0);
        ListNode currResult = dummyHead;

        while (l1!=null && l2!=null) {
            if (l1.val<l2.val) {
                currResult.next = l1;
                l1 = l1.next;
                currResult = currResult.next;
            } else {
                currResult.next = l2;
                l2 = l2.next;
                currResult = currResult.next;
            }
        }

        if (l1==null) {
            currResult.next = l2;
        } else {
            currResult.next = l1;
        }

        return dummyHead.next;
    }
}