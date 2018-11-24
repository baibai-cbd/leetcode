package com.white;

import java.util.ArrayList;

public class MergeKSortedLists {
	
	// problem 23
	// 
	// This is a naive way, seek smallest among the heads, attach it to the result LinkedList.
	//
	// There should be a better way to combine 2 LinkedLists each time, because combining 2 LLs is O(n)
	public static ListNode mergeKLists(ListNode[] lists) {
		if (lists.length==0) {
			return null;
		}
		
		ListNode resultListHead = new ListNode(0);
		ListNode currResult = resultListHead;
		ArrayList<ListNode> nodeList = new ArrayList<>(lists.length);
		for (ListNode node : lists) {
			if (node==null)
				continue;
			nodeList.add(node);
		}
		
		while (!nodeList.isEmpty()) {
			int minValue = Integer.MAX_VALUE;
			int minIndex = -1;
			for (int i=0; i<nodeList.size(); i++) {
				ListNode curr = nodeList.get(i);
				if (curr.val<minValue) {
					minIndex = i;
					minValue = curr.val;
				}
			}
			//
			currResult.next = nodeList.get(minIndex);
			currResult = currResult.next;
			//
			if (nodeList.get(minIndex).next==null) {
				nodeList.remove(minIndex);
			} else {
				nodeList.set(minIndex, nodeList.get(minIndex).next);
			}
		}
		
		return resultListHead.next;
    }
}
