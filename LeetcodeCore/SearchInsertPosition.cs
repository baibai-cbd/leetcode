using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class SearchInsertPosition
    {
        // 35. Search Insert Position
        public int SearchInsert(int[] nums, int target)
        {
            return BinarySearch(nums, 0, nums.Length - 1, target);
        }

        private int BinarySearch(int[] arr, int l, int r, int x)
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
            // This return is important that (l) is the insert index of the not found value of the binary search
            return l;
        }
    }
}
