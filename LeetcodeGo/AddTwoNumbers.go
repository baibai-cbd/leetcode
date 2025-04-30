package main

type ListNode struct {
	Val  int
	Next *ListNode
}

func addTwoNumbers(l1 *ListNode, l2 *ListNode) *ListNode {
	c := 0
	s := 0
	currDigit := 0
	head := &ListNode{0, nil}
	currNode := head

	for l1 != nil || l2 != nil || c != 0 {
		s = c
		if l1 != nil {
			s += l1.Val
			l1 = l1.Next
		}
		if l2 != nil {
			s += l2.Val
			l2 = l2.Next
		}
		c = s / 10
		currDigit = s % 10
		newNode := &ListNode{currDigit, nil}
		currNode.Next = newNode
		currNode = currNode.Next
	}

	return head.Next
}
