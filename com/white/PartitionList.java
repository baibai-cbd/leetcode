package com.white;

public class PartitionList {

	// 86. Partition List
	
	public static ListNode partition(ListNode head, int x) {
        
		if (head==null || head.next==null) {
			return head;
		}
		
		ListNode part1 = new ListNode(0);
		ListNode part1tail = part1;
		ListNode part2 = new ListNode(0);
		ListNode part2tail = part2;
		ListNode curr = head;
		
		while (curr!=null) {
			if (curr.val<x) {
				part1tail.next = curr;
				part1tail = part1tail.next;
			} else {
				part2tail.next = curr;
				part2tail = part2tail.next;
			}
			curr = curr.next;
		}
		
		if (part1.next==null) {
			return part2.next;
		} else if (part2.next==null) {
			return part1.next;
		} else {
			part2tail.next = null;
			part1tail.next = part2.next;
			return part1.next;
		}
    }
}
