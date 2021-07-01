using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SearchA2DMatrix
    {
        // 74. Search a 2D Matrix
        public bool SearchMatrix(int[][] matrix, int target)
        {
            var left = 0;
            var right = matrix.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (matrix[mid][0] == target)
                    return true;

                if (matrix[mid][0] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            // the left index is in range [0,matrix.Length], thus minus 1 to get correct row number
            var row = Math.Max(0, left - 1);
            var rowIndex = Array.BinarySearch(matrix[row], target);
            return rowIndex >= 0;
        }
    }
}
