package main

import "fmt"

func main() {

	// problem 1
	// nums := []int{2, 7, 11, 15}
	// output := twoSum(nums, 9)

	// fmt.Printf("%v", output)

	// problem 2
	// l3 := &ListNode{3, nil}
	// l2 := &ListNode{4, l3}
	// l1 := &ListNode{2, l2}

	// l6 := &ListNode{4, nil}
	// l5 := &ListNode{6, l6}
	// l4 := &ListNode{5, l5}

	// output := addTwoNumbers(l1, l4)
	// fmt.Printf("%v", output)

	a := [5]byte{}
	doSomething(a)
	fmt.Println(a)

	b := []byte{2, 2, 2, 2, 2}
	doSomethingSlice(b)
	fmt.Println(b)

	c := []byte{3, 3, 3, 3, 3}
	doSomethingSlicePointer(&c)
	fmt.Println(c)
}

func doSomething(a [5]byte) {
	a[0] = 1
}

func doSomethingSlice(b []byte) {
	b[0] = 1
}

func doSomethingSlicePointer(c *[]byte) {
	(*c)[0] = 1
}
