package com.white;

public class ListNode {

    int val;
    ListNode next;
    ListNode(int x) {
        val = x;
    }

    public static void printListNode(ListNode head) {
		ListNode curr = head;
    	
    	while(curr != null) {
    		System.out.println(curr.val + "->");
    		curr = curr.next;
    	}
    	
    	System.out.println("null");
	}
}
