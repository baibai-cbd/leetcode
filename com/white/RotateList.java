package com.white;

public class RotateList {

	// 61. Rotate List
	
	public static ListNode rotateRight(ListNode head, int k) {
        
		if (head==null) {
			return null;
		}
		
		ListNode dummy = new ListNode(0);
		int count = 1;
		ListNode curr = head;
		
		while (curr.next != null) {
			count++;
			curr = curr.next;
		}
		
		if (count<=1 || k%count==0 || k==0) {
			return head;
		}
		
		int newK = k % count;
		ListNode breakPoint = head;
		
		for (int i=0; i<count-newK-1; i++) {
			breakPoint = breakPoint.next;
		}
		
		ListNode newHead = breakPoint.next;
		dummy.next = newHead;
		breakPoint.next = null;
		
		curr.next = head;
		
		return dummy.next;
    }
}
