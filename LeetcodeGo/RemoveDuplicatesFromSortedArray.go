package main

// 26. Remove Duplicates from Sorted Array
func removeDuplicates(nums []int) int {
    uniqueCount := 1
    currNum := nums[0]

    for i := 1; i < len(nums); i++ {
        if nums[i] == currNum {
            nums[i] = 200
        } else {
            uniqueCount++
            currNum = nums[i]
        }
    }

    placeIndex := 0
    for j := 0; j < len(nums); j++ {
        if nums[j] != 200 {
            nums[placeIndex] = nums[j]
            placeIndex++
        }
    }

    return uniqueCount
}