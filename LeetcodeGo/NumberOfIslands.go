package main

type Point struct {
	x int
	y int
}

func numIslands(grid [][]byte) int {
	pointMap := make(map[Point]int)
	m := len(grid)
	n := len(grid[0])
	count := 0

	for i := 0; i < m; i++ {
		for j := 0; j < n; j++ {
			if grid[i][j] == '1' {
				if _, ok := pointMap[Point{i, j}]; ok {
					continue
				} else {
					count++
					recursiveFind(grid, m, n, pointMap, i, j)
				}
			}
		}
	}

	return count
}

func recursiveFind(grid [][]byte, m int, n int, pointMap map[Point]int, i int, j int) {
	if i < 0 || i == m || j < 0 || j == n {
		return
	}
	if grid[i][j] == '0' {
		return
	}
	if _, ok := pointMap[Point{i, j}]; ok {
		return
	}

	pointMap[Point{i, j}] = 1

	recursiveFind(grid, m, n, pointMap, i, j+1)
	recursiveFind(grid, m, n, pointMap, i+1, j)
	recursiveFind(grid, m, n, pointMap, i, j-1)
	recursiveFind(grid, m, n, pointMap, i-1, j)
}
