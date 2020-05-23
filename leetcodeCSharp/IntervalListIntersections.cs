using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class IntervalListIntersections
    {
        // 986. Interval List Intersections
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            if (A == null || B == null || A.Length == 0 || B.Length == 0)
            {
                return new int[0][];
            }

            var result = new List<int[]>();
            var aPointer = 0;
            var bPointer = 0;
            while (aPointer < A.Length && bPointer < B.Length)
            {
                var tempResult = OverlapHelper(A[aPointer], B[bPointer], out int flag);
                if (Math.Abs(flag) == 1)
                {
                    result.Add(tempResult);
                }
                if (flag < 0)
                {
                    aPointer++;
                }
                else if (flag > 0)
                {
                    bPointer++;
                }
            }

            return result.ToArray();
        }

        private int[] OverlapHelper(int[] a, int[] b, out int flag)
        {
            if (a[1] < b[0])
            {
                flag = -2;
                return null;
            }
            else if (a[0] > b[1])
            {
                flag = 2;
                return null;
            }
            else
            {
                var leftPoint = a[0] <= b[0] ? b[0] : a[0];
                var incrementBool = a[1] <= b[1];
                var rightPoint = incrementBool ? a[1] : b[1];
                flag = incrementBool ? -1 : 1;
                return new int[] { leftPoint, rightPoint };
            }
        }
    }
}
