package com.white;

public class RemoveDuplicatesFromSortedList {

	// 83. Remove Duplicates from Sorted List
	
	public static ListNode deleteDuplicates(ListNode head) {
        
		if (head==null || head.next==null) {
			return head;
		}
		
		ListNode first = head.next;
		ListNode second = head;
		int tempValue = head.val;
		
		while (first!=null) {
			if (first.val==tempValue) {
				first = first.next;
				second.next = first;
			} else {
				second = first;
				tempValue = second.val;
			}
		}
		
		return head;
    }
}
