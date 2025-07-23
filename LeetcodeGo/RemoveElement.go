package main

// 27. Remove Element
func removeElement(nums []int, val int) int {
	index1 := 0
	index2 := len(nums) - 1

	for index1 <= index2 {
		if nums[index1] == val {
			swap(nums, index1, index2)
			index2--
		} else if nums[index1] != val {
			index1++
		}
	}

	return index1
}

func swap(nums []int, a int, b int) {
	temp := nums[a]
	nums[a] = nums[b]
	nums[b] = temp
}
