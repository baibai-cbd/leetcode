package com.white;

public class RemoveNthNodeFromEndOfList {
	
	// 19 Remove Nth Node From End of List
	
	public static ListNode removeNthFromEnd(ListNode head, int n) {
        
		if (head == null) {
			return null;
		}
		
		ListNode dummy = new ListNode(0);
		dummy.next = head;
		
		ListNode delPrev = dummy;
		ListNode delNext = head.next;
		ListNode iterator = head;
		int count = 1;
		
		while(iterator != null) {
			if (iterator.next != null) {
				if (count < n) {
					count++;
					iterator = iterator.next;
				} else {
					delPrev = delPrev.next;
					delNext = delNext.next;
					iterator = iterator.next;
				}
			} else {
				break;
			}
		}
		
		delPrev.next = delNext;
		return dummy.next;
    }
}
