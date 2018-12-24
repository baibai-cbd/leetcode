package com.white;

import java.util.ArrayList;

public class ReverseNodesInKGroup {
	
	// 25. Reverse Nodes in k-Group
	
	public static ListNode reverseKGroup(ListNode head, int k) {
        
		if (head==null || k<=1) {
			return head;
		}
		
		ListNode dummy = new ListNode(0);
		ListNode groupHead = head;
		ListNode groupTail = dummy;
		ListNode curr = head;
		
		ArrayList<ListNode> kNodes = new ArrayList<>(k);
		
		while (true) {
			if (curr==null)
				break;
			
			for (int i = 0; i < k; i++) {
				kNodes.add(curr);
				if (curr.next == null) {
					curr = curr.next;
					break;
				}
				curr = curr.next;
			}

			if (kNodes.size() < k) {
				if (groupTail==dummy) {
					dummy.next = head;
				} else {
					groupTail.next = kNodes.get(0);
				}
				break;
			} else {
				groupHead = kNodes.get(k-1);
				ListNode temp = groupHead;
				for (int i=k-2; i>=0; i--) {
					temp.next = kNodes.get(i);
					temp = temp.next;
				}
				kNodes.clear();
				groupTail.next = groupHead;
				groupTail = temp;
				groupTail.next = null;
			}
		}
		
		return dummy.next;
    }
}
