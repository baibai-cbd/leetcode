package com.white;

public class LinkedListCycleII {
	
	// 142. Linked List Cycle II
	// Not best solution, work on the best solution next time

	public static ListNode detectCycle(ListNode head) {
        
		if (head==null) {
			return head;
		}
		
		ListNode anchor = head;
		ListNode inLoop = detectLoop(head);
		if (inLoop==null) {
			return null;
		}
		if (inLoop==anchor) {
			return anchor;
		}
		ListNode curr = inLoop.next;
		
		while (true) {
			while (curr != inLoop) {
				if (curr == anchor) {
					return anchor;
				} else {
					curr = curr.next;
				}
			}
			anchor = anchor.next;
			if (anchor==curr) {
				return anchor;
			}
			curr = curr.next;
		}
    }
	
	private static ListNode detectLoop(ListNode node) {
		// if no loop, return null
		// if loop exists, return a node in the loop
		ListNode fast = node;
		ListNode slow = node;
		
		while (slow != null && fast != null && fast.next != null) { 
            slow = slow.next; 
            fast = fast.next.next;
            
            if (slow == fast) { 
                return fast;
            }
		}
		return null;
	}
}
