package com.white;

import java.util.HashMap;

public class RemoveDuplicatesFromSortedListII {

	// 82. Remove Duplicates from Sorted List II
	
	// This solution works for unsorted list as well
	// but performance not optimal for sorted list
	
	public static ListNode deleteDuplicates(ListNode head) {
        
		if (head==null || head.next==null) {
			return head;
		}
		
		ListNode dummy = new ListNode(0);
		HashMap<Integer, Boolean> hashMap = new HashMap<>();
		ListNode curr = head;
		
		while (curr!=null) {
			if (hashMap.containsKey(curr.val)) {
				hashMap.put(curr.val, false);
			} else {
				hashMap.put(curr.val, true);
			}
			curr = curr.next;
		}
		
		ListNode resultNode = dummy;
		curr = head;
		
		while (curr!=null) {
			if (hashMap.get(curr.val)) {
				resultNode.next = curr;
				curr = curr.next;
				resultNode = resultNode.next;
			} else {
				curr = curr.next;
			}
		}
		
		resultNode.next = null;
		
		return dummy.next;
    }
}
