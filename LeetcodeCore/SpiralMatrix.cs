using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SpiralMatrix
    {
        // 54. Spiral Matrix
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var results = new List<int>();
            if (matrix == null || matrix.Length == 0)
                return results;
            var directionNum = 0;
            var position1 = new Tuple<int, int>(0, 0);
            var position2 = new Tuple<int, int>(matrix.Length - 1, matrix[0].Length - 1);
            while (true)
            {
                if (position1.Item1 > position2.Item1 || position1.Item2 > position2.Item2)
                {
                    break;
                }
                var tempList = TraverseStep(matrix, results, position1, position2, directionNum);
                position1 = tempList[0];
                position2 = tempList[1];
                directionNum = directionNum == 3 ? 0 : directionNum + 1;
            }
            return results;
        }

        private IList<Tuple<int, int>> TraverseStep(int[][] matrix, IList<int> results, Tuple<int, int> position1, Tuple<int, int> position2, int direction)
        {
            IList<Tuple<int, int>> newPositions;
            switch (direction)
            {
                case 0:
                    for (int i = position1.Item2; i <= position2.Item2; i++)
                    {
                        results.Add(matrix[position1.Item1][i]);
                    }
                    newPositions = new List<Tuple<int, int>>
                    {
                        new Tuple<int, int>(position1.Item1 + 1, position1.Item2),
                        position2
                    };
                    return newPositions;
                case 1:
                    for (int i = position1.Item1; i <= position2.Item1; i++)
                    {
                        results.Add(matrix[i][position2.Item2]);
                    }
                    newPositions = new List<Tuple<int, int>>
                    {
                        position1,
                        new Tuple<int, int>(position2.Item1, position2.Item2 - 1)
                    };
                    return newPositions;
                case 2:
                    for (int i = position2.Item2; i >= position1.Item2; i--)
                    {
                        results.Add(matrix[position2.Item1][i]);
                    }
                    newPositions = new List<Tuple<int, int>>
                    {
                        position1,
                        new Tuple<int, int>(position2.Item1 - 1, position2.Item2)
                    };
                    return newPositions;
                case 3:
                    for (int i = position2.Item1; i >= position1.Item1; i--)
                    {
                        results.Add(matrix[i][position1.Item2]);
                    }
                    newPositions = new List<Tuple<int, int>>
                    {
                        new Tuple<int, int>(position1.Item1, position1.Item2 + 1),
                        position2
                    };
                    return newPositions;
                default:
                    return null;
            }
        }
    }
}
