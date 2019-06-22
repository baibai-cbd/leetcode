package com.white;

public class SwapNodesInPairs {

    // 24. Swap Nodes in Pairs
    // To clarify, if there's odd number of nodes,
    // the left-out one would not be swapped with any other node.
    
    // There should be better ways to write this
    public static ListNode swapPairs(ListNode head) {
        
        if (head==null) {
            return head;
        }
        ListNode dummyHead = new ListNode(0);
        ListNode curr = head;
        ListNode prev = dummyHead;
        ListNode next = curr.next;
        prev.next = curr;
        int count = 1;

        while (next!=null) {
            if (count==0) {
                prev = prev.next;
                curr = curr.next;
                next = next.next;
                count++;
            } else {
                prev.next = next;
                curr.next = next.next;
                next.next = curr;

                prev = prev.next;
                next = curr.next;
                count--;
            }
        }

        return dummyHead.next;
    }
}