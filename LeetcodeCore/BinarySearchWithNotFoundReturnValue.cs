using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class BinarySearchWithNotFoundReturnValue
    {
        // Binary search implementation with insertion index of not found value
        // This is the same as C#'s Array.BinarySearch() or Java's Arrays.binarySearch()
        public static int BinarySearch(int[] arr, int l, int r, int x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                if (arr[mid] == x)
                    return mid;

                if (arr[mid] > x)
                    return BinarySearch(arr, l, mid - 1, x);

                return BinarySearch(arr, mid + 1, r, x);
            }
            // This return is important that it's the insert index of the not found value of the binary search
            // namely ((-insertIndex) - 1)
            return (-1 * l) - 1;
        }
    }
}
