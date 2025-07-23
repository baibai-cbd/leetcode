package main

// 88. Merge Sorted Array
func merge(nums1 []int, m int, nums2 []int, n int) {
	index1 := m - 1
	index2 := n - 1
	newIndex := m + n

	for index1 >= 0 || index2 >= 0 {
		newIndex--

		if index1 < 0 {
			nums1[newIndex] = nums2[index2]
			index2--
			continue
		}
		if index2 < 0 {
			nums1[newIndex] = nums1[index1]
			index1--
			continue
		}

		if nums1[index1] >= nums2[index2] {
			nums1[newIndex] = nums1[index1]
			index1--
		} else {
			nums1[newIndex] = nums2[index2]
			index2--
		}
	}
}
