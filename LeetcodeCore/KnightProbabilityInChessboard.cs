using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class KnightProbabilityInChessboard
    {
        // 688. Knight Probability in Chessboard
        // DP with dictionary solution
        // TODO: try DP with pure 3-dimensional array, compare performance
        private readonly Tuple<int,int>[] _moveArr = new Tuple<int, int>[]
        {   new Tuple<int, int>(1, 2), new Tuple<int, int>(-1, -2), 
            new Tuple<int, int>(2, 1), new Tuple<int, int>(-2, -1), 
            new Tuple<int, int>(-1, 2), new Tuple<int, int>(1, -2), 
            new Tuple<int, int>(-2, 1), new Tuple<int, int>(2, -1) 
        };
        private readonly Dictionary<string, double> _probabilityDict = new Dictionary<string, double>();

        public double KnightProbability(int N, int K, int r, int c)
        {
            if (K == 0)
                return IsMoveInbound(N, r, c) ? 1.0 : 0.0;

            if (_probabilityDict.TryGetValue($"{N},{K},{r},{c}", out double storedP))
            {
                return storedP;
            }
            else
            {
                double currP = 0.0;
                for (int i = 0; i < _moveArr.Length; i++)
                {
                    if (IsMoveInbound(N, r + _moveArr[i].Item1, c + _moveArr[i].Item2))
                    {
                        currP += 0.125 * KnightProbability(N, K - 1, r + _moveArr[i].Item1, c + _moveArr[i].Item2);
                    }
                }
                _probabilityDict.Add($"{N},{K},{r},{c}", currP);
                return currP;
            }
        }

        private bool IsMoveInbound(int N, int r, int c)
        {
            return r >= 0 && c >= 0 && r < N && c < N;
        }
    }
}
