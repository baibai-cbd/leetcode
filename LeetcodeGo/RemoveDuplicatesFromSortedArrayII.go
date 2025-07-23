package main

func removeDuplicatesII(nums []int) int {
	numsCount := 1
	currNum := nums[0]
	currNumCount := 1

	for i := 1; i < len(nums); i++ {
		if nums[i] == currNum && currNumCount >= 2 {
			nums[i] = 20000
		} else if nums[i] == currNum {
			currNumCount++
			numsCount++
		} else {
			numsCount++
			currNum = nums[i]
			currNumCount = 1
		}
	}

	placeIndex := 0
	for j := 0; j < len(nums); j++ {
		if nums[j] != 20000 {
			nums[placeIndex] = nums[j]
			placeIndex++
		}
	}

	return numsCount
}
