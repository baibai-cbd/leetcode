using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MinimumKnightMoves
    {
        // 1197. Minimum Knight Moves
        private readonly Tuple<int, int>[] _moveArr = new Tuple<int, int>[]
        {   new Tuple<int, int>(1, 2), new Tuple<int, int>(-1, -2),
            new Tuple<int, int>(2, 1), new Tuple<int, int>(-2, -1),
            new Tuple<int, int>(-1, 2), new Tuple<int, int>(1, -2),
            new Tuple<int, int>(-2, 1), new Tuple<int, int>(2, -1)
        };

        public int MinKnightMoves(int x, int y)
        {
            if (x == 0 && y == 0) return 0;

            var queue = new Queue<Tuple<int, int>>();
            var hashSet = new HashSet<Tuple<int, int>>();
            var count = -1;
            queue.Enqueue(new Tuple<int, int>(0, 0));
            var bestMove = new Tuple<int, int>(0, 0);

            while (true)
            {
                count++;
                var currQueueSize = queue.Count;
                for (int i = 0; i < currQueueSize; i++)
                {
                    var currPoint = queue.Dequeue();
                    if (hashSet.Contains(currPoint))
                        continue;
                    else
                        hashSet.Add(currPoint);

                    if (currPoint.Item1 == x && currPoint.Item2 == y)
                        return count;

                    // last cells permits free roam, because sometimes need to move backwards to reach exact cell
                    if (Within5x5(x, y, currPoint.Item1, currPoint.Item2))
                    {
                        foreach (var move in _moveArr)
                            queue.Enqueue(new Tuple<int, int>(currPoint.Item1 + move.Item1, currPoint.Item2 + move.Item2));

                        continue;
                    }

                    // one move can change absolute distance at most by 3, thus 1 move away from the best move means it can be ruled out
                    if (AbsDistance(x, y, currPoint.Item1, currPoint.Item2) - AbsDistance(x, y, bestMove.Item1, bestMove.Item2) >= 3)
                        continue;

                    if (AbsDistance(x, y, bestMove.Item1, bestMove.Item2) - AbsDistance(x, y, currPoint.Item1, currPoint.Item2) > 0)
                        bestMove = currPoint;

                    foreach (var move in _moveArr)
                    {
                        // check the move before adding to queue, only add to queue if absolute distance gets smaller
                        if (AbsDistance(x, y, currPoint.Item1, currPoint.Item2) > AbsDistance(x, y, currPoint.Item1 + move.Item1, currPoint.Item2 + move.Item2))
                        {
                            queue.Enqueue(new Tuple<int, int>(currPoint.Item1 + move.Item1, currPoint.Item2 + move.Item2));
                        }
                    }
                }
            }
        }

        private bool Within5x5(int x, int y, int a, int b)
            => Math.Abs(x - a) <= 2 && Math.Abs(y - b) <= 2;

        private int AbsDistance(int x, int y, int a, int b)
            => Math.Abs(x - a) + Math.Abs(y - b);
    }
}
