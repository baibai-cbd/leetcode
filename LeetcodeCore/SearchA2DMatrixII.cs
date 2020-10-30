using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class SearchA2DMatrixII
    {
        // 240. Search a 2D Matrix II
        // TODO: There is better way, just to scan from top-right and achieve O(m+n)
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0)
                return false;

            var rowCount = matrix.GetLength(0);
            var columnCount = matrix.GetLength(1);

            var leftIndex = Array.BinarySearch(Enumerable.Range(0, rowCount).Select(x => matrix[x, 0]).ToArray(), target);
            var rightIndex = Array.BinarySearch(Enumerable.Range(0, rowCount).Select(x => matrix[x, columnCount-1]).ToArray(), target);
            
            if (leftIndex >= 0 || rightIndex >= 0)
                return true;
            leftIndex = (leftIndex + 1) * -1;
            rightIndex = (rightIndex + 1) * -1;

            var result = -1;
            for (int i = rightIndex; i < leftIndex; i++)
            {
                result = Array.BinarySearch(Enumerable.Range(0, columnCount).Select(x => matrix[i, x]).ToArray(), target);
                if (result >= 0)
                    return true;
            }

            return false;
        }
    }
}
