package main

import "fmt"

func main() {

	// problem 1
	// nums := []int{2, 7, 11, 15}
	// output := twoSum(nums, 9)

	// fmt.Printf("%v", output)

	// problem 2
	l3 := &ListNode{3, nil}
	l2 := &ListNode{4, l3}
	l1 := &ListNode{2, l2}

	l6 := &ListNode{4, nil}
	l5 := &ListNode{6, l6}
	l4 := &ListNode{5, l5}

	output := addTwoNumbers(l1, l4)
	fmt.Printf("%v", output)
}
