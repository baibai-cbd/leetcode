package com.white;

public class ReverseLinkedListII {

	// 92. Reverse Linked List II
	
	public static ListNode reverseBetween(ListNode head, int m, int n) {
        
		if (head==null || head.next==null || m==n || m<=0 || m>n) {
			return head;
		}
		
		ListNode dummy = new ListNode(0);
		dummy.next = head;
		ListNode prev = dummy;
		ListNode curr = head;
		ListNode after = head.next;
		
		for (int count=1;  count<=n-1; count++) {
			if (count>=m) {
				curr.next = after.next;
				after.next = prev.next;
				prev.next = after;
				//
				after = curr.next;
			} else {
				prev = prev.next;
				curr = curr.next;
				if (after.next!=null) {
					after = after.next;
				} else {
					break;
				}
			}
		}
		
		return dummy.next;
    }
}
