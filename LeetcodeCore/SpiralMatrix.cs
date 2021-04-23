using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SpiralMatrix
    {
        // 54. Spiral Matrix
        // This solution has O(1) extra space
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


        // Easy to understand solution, but with O(n) extra space
        public IList<int> SpiralOrder2(int[][] matrix)
        {
            var result = new List<int>();
            var visited = new HashSet<(int, int)>();
            var direction = 1;
            var moveStep = (0, 1);
            var m = matrix.Length;
            var n = matrix[0].Length;
            var i = 0;
            var j = 0;

            while (true)
            {
                visited.Add((i, j));
                result.Add(matrix[i][j]);

                if (visited.Count == m * n)
                    break;

                var nextI = i + moveStep.Item1;
                var nextJ = j + moveStep.Item2;
                if ((nextI < 0 || nextI == m || nextJ < 0 || nextJ == n) || visited.Contains((i + moveStep.Item1, j + moveStep.Item2)))
                {
                    moveStep = MakeTurn(ref direction);
                    i = i + moveStep.Item1;
                    j = j + moveStep.Item2;
                }
                else
                {
                    i = nextI;
                    j = nextJ;
                }
            }

            return result;
        }

        private (int, int) MakeTurn(ref int direction)
        {
            if (direction == 1)
            {
                direction = 2;
                return (1, 0);
            }
            else if (direction == 2)
            {
                direction = 3;
                return (0, -1);
            }
            else if (direction == 3)
            {
                direction = 4;
                return (-1, 0);
            }
            else
            {
                direction = 1;
                return (0, 1);
            }
        }
    }
}
