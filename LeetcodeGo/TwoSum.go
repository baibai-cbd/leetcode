package main

// 1. Two Sum
func twoSum(nums []int, target int) []int {
	m := make(map[int]int)
	r := make([]int, 2)

	for i := 0; i < len(nums); i++ {
		m[target-nums[i]] = i
	}

	for j := 0; j < len(nums); j++ {
		val, ok := m[nums[j]]

		if ok && val != j {
			r = []int{val, j}
		}
	}

	return r
}
